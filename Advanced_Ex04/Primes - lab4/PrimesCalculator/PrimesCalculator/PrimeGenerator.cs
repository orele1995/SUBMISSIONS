using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrimesCalculator
{
    class PrimeGenerator
    {
        private CancellationToken cancellationToken;

        public ManualResetEvent AutoEvent { get; private set; }
        public CancellationTokenSource cancellationTokenSource { get; private set; }

        public PrimeGenerator ()  { AutoEvent = new ManualResetEvent(false);
            cancellationTokenSource = new CancellationTokenSource();
            cancellationToken = cancellationTokenSource.Token;
        }
        public IEnumerable<int> CulcPrime(int start, int end)
        {
            if (start < 2) { start = 2; } // 2 is the first prime number
            var prime_numbers = new List<int>();
            for (int i = start; i <= end; i++)
            {
                Thread.Sleep(10);

                if (AutoEvent.WaitOne(0))
                {
                    AutoEvent.Reset();
                    return prime_numbers;
                }
                if (cancellationToken.IsCancellationRequested)
                {
                    cancellationTokenSource = new CancellationTokenSource();
                    cancellationToken = cancellationTokenSource.Token;
                    return prime_numbers;
                }
                if (isPrime(i))
                {
                    prime_numbers.Add(i);
                }
            }

            return prime_numbers;
        }

        public async Task<int> CountPrimesAsync(int start, int end)
        {
          
         return ( await Task.Run(() => CulcPrime(start, end))).Count();
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
