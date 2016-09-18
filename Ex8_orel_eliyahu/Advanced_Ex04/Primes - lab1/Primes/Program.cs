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
            Console.WriteLine(CalcPrimes(1, 500, 2).Count);
            Console.WriteLine(watch.Elapsed);
            watch.Restart();
            Console.WriteLine(CalcPrimes(1, 500, 3).Count);
            Console.WriteLine(watch.Elapsed);
            watch.Restart();
            Console.WriteLine(CalcPrimes(1, 500, 4).Count);
            Console.WriteLine(watch.Elapsed);
        }

        public static List<int> CalcPrimes(int start, int end, int maxDegreeOfParallelism)
        {
            ParallelOptions pOptions = new ParallelOptions();
            pOptions.MaxDegreeOfParallelism = maxDegreeOfParallelism;

            if (start < 2) { start = 2; } // 2 is the first prime number
            List<int> prime_numbers = new List<int>();

            Parallel.For(start, end, pOptions, i =>
            {
                if (isPrime(i))
                    prime_numbers.Add(i);
            } );

            return prime_numbers;
        }

        private static bool isPrime(int num)
        {
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;

        }

    }
}
