using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            LimitedQueue<int> queue = new LimitedQueue<int>(5);
            for (int i = 0; i < 20; i++)
            {
                int action = new Random().Next(0, 2);
                if (action == 0)
                {
                    var trd = new Thread((j) =>
                     {
                         try
                         {
                             Console.WriteLine($"{j}: Dequeued {queue.Dequeue()}");
                             Console.WriteLine($"{j}: {queue.Count()} ");
                         }
                         catch (InvalidOperationException ex)
                         {
                             Console.WriteLine($"{j}: queue is empty");
                         }

                     }
                        );
                    trd.Name = i.ToString();
                    trd.Start(i);
                }
                else
                {
                    int value = new Random().Next(0, 200);
                    var trd = new Thread((j) =>
                    {
                        Console.WriteLine($"{j}: Try to enqueue {value}");
                        queue.Enque(value);
                        Console.WriteLine($"{j}: Enqueued {value}");
                        Console.WriteLine($"{j}: {queue.Count()} ");


                    });
                    trd.Name = i.ToString();
                    trd.Start(i);

                }

            }
            Console.ReadLine();
        }
    }
}
