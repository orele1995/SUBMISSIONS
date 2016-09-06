using DatabaseManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilesManagement;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            FilesParser fp = new FilesParser();
            fp.ParseAllFiles(@"C:\Prices\bin\Prices");
        }
    }
}
