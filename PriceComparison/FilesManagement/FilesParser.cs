using DatabaseManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace FilesManagement
{
    class FilesParser
    {
        public void ParseAllFiles (string directoryPath)
        {
            var filesPath = Directory.EnumerateFiles(directoryPath);
            FilesExtraction filesExtraction = new FilesExtraction();

            foreach (var filePath in filesPath)
            {
                var fullPath = directoryPath + "//" + filePath;
                FileStream fileStream = new FileStream(fullPath, FileMode.Open);
                var exstactedFile =  filesExtraction.ExtractFile(fileStream);
                
            }
        }

        private void ParseItemsFile(XmlReader file)
        {
            
        }
        private void ParseStoresFile(XmlReader file)
        {

        }
        private void ParseChains(XmlReader file)
        {
            var xmlRoot = XDocument.Load(file).Root;
            int id = int.Parse(xmlRoot.Element("ChainId").Value);
            string name = xmlRoot.Element("ChainName").Value;
            Chain newChain = new Chain() { ChainID = id, Chain_name = name };
            using (PricesContext context = new PricesContext())
            {
                context.addOrUpdateChain(newChain);
            }
           
           

        }
    }
}
