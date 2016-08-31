using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primes
{
    class Program
    {
        public static int[] CulcPrime(int start, int end)
        {
            if (start < 2) { start = 2; } // 2 is the first prime number
            ArrayList prime_numbers = new ArrayList();
            for (int i = start; i <= end; i++)
            {
                if (isPrime(i))
                {
                    prime_numbers.Add(i);
                }
            }
            int[] prime_numbers_array = new int[prime_numbers.Count];

            prime_numbers.CopyTo(prime_numbers_array);
            return prime_numbers_array;
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

        static void Main(string[] args)
        {
            int start;
            int end;
            string input;
            do
            {
                Console.WriteLine("enter start and end ( start is smaller than end!) ");
                Console.Write("start: ");
                input = Console.ReadLine();
                while (int.TryParse(input, out start) == false || start < 1)
                {
                    Console.WriteLine("error! enter a number bigger than 0");
                    input = Console.ReadLine();
                }
                Console.Write("end: ");
                input = Console.ReadLine();
                while (int.TryParse(input, out end) == false || end < 1)
                {
                    Console.WriteLine("error! enter a number bigger than 0");
                    input = Console.ReadLine();
                }
            }
            while (start > end);
            int[] primeArray = CulcPrime(start, end);
            for (int i = 0; i < primeArray.Length; i++)
            {
                Console.WriteLine(primeArray[i] + " ");
            }
        }
    }
}
