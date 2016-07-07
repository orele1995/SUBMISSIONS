using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnel
{
    class FileManager
    {
       
        public List<string> ReadFile (String path)
        {
             FileStream stm = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            StreamReader reader = new StreamReader(stm);

            List<String> result = new List<string>();

            try
            {
                string newLine = reader.ReadLine();
                while (newLine != null)
                {
                    result.Add(newLine);
                    newLine = reader.ReadLine();
                }
            }
            finally
            {
                reader.Close();
            }
            return result;
        } 
    }
}
