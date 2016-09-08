using DatabaseManager;
using System.IO;
using System.Linq;
using System.Xml;
using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Text;
using PriceComperationModel;

namespace FilesManagement
{
    public class FilesParser
    {
        private const string AlreadyParsedFilesPath = "alreadyParsedFiles.txt";

        private readonly IPriceComperationDataManager _manager;

        public FilesParser(IPriceComperationDataManager dataManager)
        {
            _manager = dataManager;
        }
        public FilesParser()
        {
           var file = File.Open(AlreadyParsedFilesPath, FileMode.OpenOrCreate);
            file.Close();
        }

        public void ParseAllFiles (string directoryPath)
        {
            foreach (var directory in Directory.GetDirectories(directoryPath))
            {
                var filesPath = Directory.EnumerateFiles(directory);
                ParseFiles(filesPath, ParseStoresFile, "Stores");
                ParseFiles(filesPath, ParsePriceFile, "PriceFull");
                Console.WriteLine(directory);
            }          
        }

        private void ParseFiles(IEnumerable<string> filesPath, Action<XDocument> parseAction, string nameOfFilesToParse )
        {
            FilesExtraction filesExtraction = new FilesExtraction();

            foreach (var filePath in filesPath)
            {
                if (AlreadyParsed(filePath)) continue;
                if (filePath.IndexOf(nameOfFilesToParse, StringComparison.Ordinal) == -1) continue;
                FileStream fileStream = new FileStream(filePath, FileMode.Open);
                XDocument xml;

                if (Path.GetExtension(filePath) == ".gz") // the file is zipped
                    xml = filesExtraction.ExtractGZFile(fileStream);
                else if (Path.GetExtension(filePath) == ".zip")
                    xml = filesExtraction.ExtractZipFile(fileStream);
                else
                    xml = XDocument.Load(fileStream);
              parseAction(xml);
                AddFileToAlreadyParsedFile(filePath);
            }
        }

        private void AddFileToAlreadyParsedFile(string filePath)
        {
            var writer = new StreamWriter(AlreadyParsedFilesPath,true);

            try
            {
                writer.WriteLine(filePath);
            }
            finally
            {
                    writer.Close();
            }
        }

        private bool AlreadyParsed(string filePath)
        {
            StreamReader reader = new StreamReader(AlreadyParsedFilesPath);

            try
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains(filePath))
                    {
                        return true;
                    }
                }
                return false;

            }
            finally
            {
                reader.Close();
            }          

        }

        private void ParsePriceFile(XDocument xmlDoc)
        {
            int storeCode = int.Parse(xmlDoc.Descendants("StoreId").First().Value);
            long chainId = long.Parse(xmlDoc.Descendants("ChainId").First().Value);

            int storeId = _manager.FindStoreIdByCodeAndChain(storeCode, chainId);
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
            result.ToList();
            
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
                             ChainID = chainId,
                             Address = store.Element("Address").Value,
                             City = store.Element("City").Value,
                             ZipCode = store.Element("ZipCode").Value
                         };
            _manager.AddOrUpdateChain(newChain);
            _manager.AddOrUpdateStores(stores);
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

            _manager.AddOrUpdateItem(item);

            _manager.AddOrUpdatePrice(price);
            return true;

        }



    }
}
