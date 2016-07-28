using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimesCalculator
{
    class PrimeGenerator
    {
        public IEnumerable<int> CulcPrime(int start, int end)
        {
            if (start < 2) { start = 2; } // 2 is the first prime number
            var prime_numbers = new List<int>();
            for (int i = start; i <= end; i++)
            {
                if (isPrime(i))
                {
                    prime_numbers.Add(i);
                }
            }

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
