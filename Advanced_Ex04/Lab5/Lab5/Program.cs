using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = Stopwatch.StartNew();

            waitTimeAsync(3000, watch).ContinueWith(t => waitTimeAsync(1000, watch));
           // waitProcess("notepad").ContinueWith(t => waitProcess("notepad"));
               Console.ReadLine();
        }

        // I know static methods aren't good but its just for the exsample... cause main cant be sync
        static async Task waitTimeAsync(int milliseconds, Stopwatch watch)
        {
            Console.WriteLine(watch.Elapsed);
            await milliseconds;
            Console.WriteLine(watch.Elapsed);
        }

        static async Task waitProcess (string fileName)
        {
            Console.WriteLine("Enter process " + fileName);
            await Process.Start(fileName);
            Console.WriteLine( "Exit process "+ fileName);
        }

    }
}
