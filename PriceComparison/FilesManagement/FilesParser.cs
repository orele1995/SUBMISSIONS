using DatabaseManager;
using System.IO;
using System.Linq;
using System.Xml;
using System;
using System.Xml.Linq;
using System.Collections.Generic;

namespace FilesManagement
{
    public class FilesParser
    {
        public void ParseAllFiles (string directoryPath)
        {
            var filesPath = Directory.EnumerateFiles(directoryPath);
            FilesExtraction filesExtraction = new FilesExtraction();

            foreach (var filePath in filesPath)
            {
                FileStream fileStream = new FileStream(filePath, FileMode.Open);
                XDocument xml;

                if (Path.GetExtension(filePath)=="gz") // the file is zipped
                  xml = filesExtraction.ExtractFile(fileStream);
                else
                    xml = XDocument.Load(fileStream);

                if (filePath.IndexOf("Stores") != -1) // its a stores file
                    ParseStoresFile(xml);
                if (filePath.IndexOf("PriceFull") != -1) // its a prices file
                    ParseItemsFile(xml);
            }
        }

        private void ParseItemsFile(XDocument xmlDoc)
        {
            using (PricesContext context = new PricesContext())
            {
                int storeCode = int.Parse(xmlDoc.Descendants("StoreId").First().Value);
                long chainId = long.Parse(xmlDoc.Descendants("ChainId").First().Value);

                int storeId = context.Stores
                    .Where(s => s.Chain_id == chainId && s.Store_code == storeCode)
                    .Select(s => s.StoreID).First();
                var items = parseItems(xmlDoc);
                var prices = parsePrices(xmlDoc, storeId);

                foreach (var item in items)
                {
                    context.addOrUpdateItem(item);
                }
                foreach (var price in prices)
                {
                    context.addOrUpdatePrice(price);
                }
            }
        }

        private void ParseStoresFile(XDocument xmlDoc)
        {
            long chainId = long.Parse(xmlDoc.Descendants("ChainId").First().Value);
            string chainName = xmlDoc.Descendants("ChainName").First().Value;
            Chain newChain = new Chain() { ChainID = chainId, Chain_name = chainName };

            var stores = from store in xmlDoc.Descendants("Store")
                         select new Store
                         {
                             Store_code = int.Parse(store.Element("StoreId").Value),
                             Chain_id = chainId,
                             Address = store.Element("Address").Value,
                             City = store.Element("City").Value,
                             ZipCode = store.Element("ZipCode").Value
                              };

            using (PricesContext context = new PricesContext())
            {
                context.addOrUpdateChain(newChain);

                foreach (var store in stores)
                {
                    context.addOrUpdateStore(store);
                }
            }
        }

        private IEnumerable<Item> parseItems(XDocument xmlDoc)
        {
            return from item in xmlDoc.Descendants("Item")
                   select new Item
                   {
                       ItemID = long.Parse(item.Element("ItemCode").Value),
                       ItemName = item.Element("ManufacturerItemDescription").Value,
                       ManufacturerName = item.Element("ManufacturerName").Value
                   };
        }

        private IEnumerable<Price> parsePrices(XDocument xmlDoc, int storeId)
        {
            return from item in xmlDoc.Descendants("Item")
                   select new Price
                   {
                       ItemID = long.Parse(item.Element("ItemCode").Value),
                       Quantity = item.Element("Quantity").Value,
                       UnitOfMeasure = item.Element("UnitOfMeasure").Value,
                       UnitOfMeasurePrice = double.Parse(item.Element("UnitOfMeasurePrice").Value),
                       UnitQty = item.Element("UnitQty").Value,
                       ItemPrice = double.Parse(item.Element("ItemPrice").Value),
                       StoreID = storeId
                   };
        }

    }
}
