using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length!=2)
            {
                Console.WriteLine("2 args expected");
                Environment.Exit(1);
            }
            var path = args[0];
            var name = args[1];
            var directoryInfo = new DirectoryInfo(path);
            var files = directoryInfo.GetFiles("*" + name + "*",SearchOption.AllDirectories);
            foreach (var file in files)
            {
                Console.WriteLine(file.FullName);
                Console.WriteLine(file.Length);
                Console.WriteLine("======================");
            }

        }
    }
}
