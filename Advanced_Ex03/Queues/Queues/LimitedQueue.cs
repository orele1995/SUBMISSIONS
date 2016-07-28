using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queues
{
    class LimitedQueue<T>
    {
        static Semaphore s; 
        Queue<T> queue = new Queue<T>();
        public LimitedQueue (int number)
        {
          s = new Semaphore(3,3);
        }
        public void Enque(T value)
        {
            s.WaitOne();
            queue.Enqueue(value);
        }
        public T Dequeue()
        {

            T val =  queue.Dequeue();
            s.Release();
            return val;
        }
    }
}
