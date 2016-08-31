using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
