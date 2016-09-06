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
            FilesExtraction filesExtraction = new FilesExtraction();
            foreach (var directory in Directory.GetDirectories(directoryPath))
            {
                var filesPath = Directory.EnumerateFiles(directory);
                parseStoresFiles(filesPath, filesExtraction);
                parseFullPriceFiles(filesPath, filesExtraction);
                Console.WriteLine(directory);
            }          
        }

        private void parseFullPriceFiles(IEnumerable<string> filesPath, FilesExtraction filesExtraction)
        {
            foreach (var filePath in filesPath)
            {
                if (filePath.IndexOf("PriceFull") != -1) // its a prices file
                {
                    FileStream fileStream = new FileStream(filePath, FileMode.Open);
                    XDocument xml;

                    if (Path.GetExtension(filePath) == ".gz") // the file is zipped
                        xml = filesExtraction.ExtractGZFile(fileStream);
                    else if (Path.GetExtension(filePath) == ".zip")
                        xml = filesExtraction.ExtractZipFile(fileStream);
                    else
                        xml = XDocument.Load(fileStream);
                    ParsePriceFile(xml);
                }
            }
        }

        private void parseStoresFiles(IEnumerable<string> filesPath, FilesExtraction filesExtraction)
        {
            foreach (var filePath in filesPath)
            {
                if (filePath.IndexOf("Stores") != -1) // its a stores file
                {
                    FileStream fileStream = new FileStream(filePath, FileMode.Open);
                    XDocument xml;

                    if (Path.GetExtension(filePath) == ".gz") // the file is zipped
                        xml = filesExtraction.ExtractGZFile(fileStream);
                    else if (Path.GetExtension(filePath) == ".zip")
                      xml = filesExtraction.ExtractZipFile(fileStream);
                    else
                        xml = XDocument.Load(fileStream);
                    ParseStoresFile(xml);
                }
            }
        }

        private void ParsePriceFile(XDocument xmlDoc)
        {

            int storeCode = int.Parse(xmlDoc.Descendants("StoreId").First().Value);
            long chainId = long.Parse(xmlDoc.Descendants("ChainId").First().Value);

            int storeId = DBManager.TheDBManager.FindStoreIdByCodeAndChain(storeCode, chainId);
            if (storeId == 0) return; // store was not found
            var result = from item in xmlDoc.Descendants("Item")
                         let code = long.Parse(item.Element("ItemCode").Value)
                         where code > 1000000000
                         select ParseItemAndPrice(
                         code,
                         item.Element("ManufacturerItemDescription").Value,
                         item.Element("ManufacturerName").Value,
                         item.Element("Quantity").Value,
                         item.Element("UnitOfMeasure").Value,
                         double.Parse(item.Element("UnitOfMeasurePrice").Value),
                         item.Element("UnitQty").Value,
                         double.Parse(item.Element("ItemPrice").Value),
                         storeId);
            foreach (var item in result)
            {
               
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
            DBManager.TheDBManager.AddOrUpdateChain(newChain);
            DBManager.TheDBManager.AddOrUpdateStores(stores);
        }

        private bool ParseItemAndPrice(long itemID, string manufacturerItemDescription, string manufacturerName, string quantity, string unitOfMeasure, double unitOfMeasurePrice, string unitQty, double itemPrice, int storeId)
        {
            var item = new Item()
            {
                ItemID = itemID,
                ManufacturerName = manufacturerName,
                ItemName = manufacturerItemDescription
            };
            var price = new Price()
            {
                ItemID = itemID,
                ItemPrice = itemPrice,
                Quantity = quantity,
                StoreID = storeId,
                UnitOfMeasure = unitOfMeasure,
                UnitOfMeasurePrice = unitOfMeasurePrice,
                UnitQty = unitQty
            };

            DBManager.TheDBManager.AddOrUpdateItem(item);

            DBManager.TheDBManager.AddOrUpdatePrice(price);
            return true;

        }



    }
}
