using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace FilesManagement
{
    public class FilesExtraction
    {
        public XDocument ExtractFile(FileStream originalFileStream)
        {
            GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress);
                
                    return XDocument.Load(decompressionStream);
                
        }
    }
}

