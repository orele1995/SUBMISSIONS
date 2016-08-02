using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    class PrimeGenerator
    {
        public List<int> CulcPrime(int start, int end)
        {
            
            if (start < 2) { start = 2; } // 2 is the first prime number
            List<int> prime_numbers = new List<int>();

            Parallel.For(start, end, i =>
            {
                if (isPrime(i))
                    prime_numbers.Add(i);
            });

            
            return prime_numbers;
        }

        private bool isPrime(int num)
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
