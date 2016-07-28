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
                    new Thread((j) =>
                    {
                        try
                        {
                            Console.WriteLine($"{j}: Dequeued {queue.Dequeue()}");
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine($"{j}: queue is empty");
                        }

                    }
                        ).Start(i);
                else
                {
                    int value = new Random().Next(0, 200);
                    new Thread((j) => {
                        Console.WriteLine($"{j}: Try to enqueue {value}");
                        queue.Enque(value);
                        Console.WriteLine($"{j}: Enqueued {value}");

                    }).Start(i);

                }

            }
            Console.ReadLine();
        }
    }
}
