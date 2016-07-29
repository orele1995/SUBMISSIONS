using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SyncDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Mutex SyncFileMutex = new Mutex(false);
            SyncFileMutex.WaitOne();
            {
                Directory.CreateDirectory(@"C:\temp");
                string path = @"C:\temp\data.txt";
                StreamWriter writer = new StreamWriter(path,true);
                Console.WriteLine(System.Diagnostics.Process.GetCurrentProcess().Id);
                try
                {
                    for (int i = 0; i < 10000; i++)
                    {
                        writer.WriteLine(System.Diagnostics.Process.GetCurrentProcess().Id);
                    }
                }
                finally
                {
                    writer.Close();
                }
            }

            SyncFileMutex.ReleaseMutex();
        }
    }
}
