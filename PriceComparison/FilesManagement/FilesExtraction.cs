using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FilesManagement
{
    public class FilesExtraction
    {
        public XmlReader ExtractFile(FileStream originalFileStream)
        {
                using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                {
                    return XmlReader.Create(decompressionStream);
                }
        }
    }
}

