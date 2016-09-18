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
           
            Console.WriteLine(CalcPrimes(1, 30000000).Count);
            Console.WriteLine(CalcPrimes(1, 30000000).Count);
            Console.WriteLine(CalcPrimes(1, 30000000).Count);
            Console.WriteLine(CalcPrimes(1, 30000000).Count);
       
            
            Console.ReadLine();
            
        }


        public static List<int> CalcPrimes(int start, int end)
        {
            Random random = new Random();

            if (start < 2) { start = 2; } // 2 is the first prime number
            List<int> prime_numbers = new List<int>();

            Parallel.For(start, end, (i,state) =>
            {
                if (random.Next(10000000) == 0)
                {
                    state.Stop();
                    return;
                }
                if (isPrime(i))
                    prime_numbers.Add(i);
            });

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