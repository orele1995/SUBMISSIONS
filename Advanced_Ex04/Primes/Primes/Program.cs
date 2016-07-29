using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    class Program
    {
        static void Main(string[] args)
        {
           var watch = Stopwatch.StartNew();
            Console.WriteLine(CalcPrimes(1, 500, 1).Count);
            Console.WriteLine(watch.Elapsed);
            watch.Restart();
            Console.WriteLine(CalcPrimes(1, 500, 2).Count);
            Console.WriteLine(watch.Elapsed);
            watch.Restart();
            Console.WriteLine(CalcPrimes(1, 500, 3).Count);
            Console.WriteLine(watch.Elapsed);
            watch.Restart();
            Console.WriteLine(CalcPrimes(1,500,4).Count);
            Console.WriteLine(watch.Elapsed);
            watch.Restart();
        }

        static List<int> CalcPrimes (int start, int end, int parallelism)
        {
            // int slice = (end - start) / parallelism; // check 
          
            PrimeGenerator pg = new PrimeGenerator();
           return pg.CulcPrime(start, end, parallelism);
        }

    }
}
