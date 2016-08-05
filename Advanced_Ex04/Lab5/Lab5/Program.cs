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
           Console.WriteLine(watch.Elapsed);
            waitTimeAsync(3000, watch);
            watch.Restart();
            waitTimeAsync(1000, watch);
            Console.ReadLine();
        }

        static async void waitTimeAsync(int milliseconds, Stopwatch watch)
        {
            await milliseconds;
            Console.WriteLine(watch.Elapsed);
        }

    }
}
