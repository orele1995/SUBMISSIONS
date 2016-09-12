using DatabaseManager;
using System.IO;
using System.Linq;
using System.Xml;
using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Text;
using DatabaseManagerFactory;
using PriceComperationModel;

namespace FilesManagement
{
    public class FilesParser
    {
        private const string AlreadyParsedFilesPath = "alreadyParsedFiles.txt";

        private readonly IPriceComperationDataManager _manager;
        private static FilesParser _theParser;

        public static FilesParser TheParser
        {
            get
            {
                if (_theParser == null)
                {
                    _theParser = new FilesParser();
                }
                return _theParser;
            }
        }

        private FilesParser()
        {
           var file = File.Open(AlreadyParsedFilesPath, FileMode.OpenOrCreate);
            file.Close();
            _manager = PriceComperationDataManagerFactory.TheFactory.GetPriceComperationDataManager();

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
            var filesExtraction = new FilesExtraction();

            foreach (var filePath in filesPath)
            {
                if (IsAlreadyParsed(filePath)) continue;
                if (filePath.IndexOf(nameOfFilesToParse, StringComparison.Ordinal) == -1) continue;
                var fileStream = new FileStream(filePath, FileMode.Open);
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

        private bool IsAlreadyParsed(string filePath)
        {
            var reader = new StreamReader(AlreadyParsedFilesPath);

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
                let itemPrice = item.Element("ItemPrice")
                let quantity = item.Element("Quantity")
                let manufacturerName = item.Element("ManufacturerName")
                let mnufacturerItemDescription = item.Element("ManufacturerItemDescription")
                let itemCode = item.Element("ItemCode")
                where
                    itemCode != null && itemPrice != null && quantity != null && manufacturerName != null &&
                    mnufacturerItemDescription != null
                let code = long.Parse(itemCode.Value)
                where code > 1000000000
                select ParseItemAndPrice(
                    code,
                    mnufacturerItemDescription.Value,
                    manufacturerName.Value,
                    quantity.Value,
                    double.Parse(itemPrice.Value),
                    storeId);
            result.ToList();

        }

        private void ParseStoresFile(XDocument xmlDoc)
        {
            var chainId = long.Parse(xmlDoc.Descendants("ChainId").First().Value);
            var chainName = xmlDoc.Descendants("ChainName").First().Value;
            var newChain = new Chain { ChainID = chainId, ChainName = chainName, Stores = new List<Store>()};
            
            
            var stores = from store in xmlDoc.Descendants("Store")
                let storeId = store.Element("StoreId")
                let address = store.Element("Address")
                let city = store.Element("City")
                where city != null && storeId != null && address != null
                         select new Store
                         {
                             StoreCode = int.Parse(storeId.Value),
                             ChainID = chainId,
                             Address = address.Value,
                             City = city.Value,
                             Prices = new List<Price>()
                         };
 
            _manager.AddOrUpdateChain(newChain);
            _manager.AddOrUpdateStores(stores);
        }

        private bool ParseItemAndPrice(long itemId, string manufacturerItemDescription, string manufacturerName, string quantity,double itemPrice, int storeId)
        {
            var item = new Item
            {
                ItemID = itemId,
                ManufacturerName = manufacturerName,
                Quantity = quantity,
                ItemName = manufacturerItemDescription
               
            };
            var price = new Price
            {
                ItemID = itemId,
                ItemPrice = itemPrice,
                StoreID = storeId,
               
            };

            _manager.AddOrUpdateItem(item);

            _manager.AddOrUpdatePrice(price);
            return true;

        }

    }
}
