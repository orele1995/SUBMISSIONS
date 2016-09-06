using Ionic.Zip;
using System;
using System.IO;
using System.IO.Compression;
using System.Xml.Linq;


namespace FilesManagement
{
    public class FilesExtraction
    {
     

        public XDocument ExtractGZFile(FileStream originalFileStream)
        {
            GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress);

            return XDocument.Load(decompressionStream);
                
        }

        internal XDocument ExtractZipFile(FileStream originalFileStream)
        {

            string place = $"{Path.GetFileNameWithoutExtension(originalFileStream.Name)}.xml";
           
                var zArch = new ZipArchive(originalFileStream);
                using (var stream = zArch.GetEntry(place).Open())
                    return XDocument.Load(stream);
               
        }
    }
}

