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
        Semaphore s;
        ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
        Queue<T> queue = new Queue<T>();
        public LimitedQueue (int number)
        {
          s = new Semaphore(3,3);
        }
        public void Enque(T value)
        {
            try
            {
                _lock.EnterWriteLock();
                s.WaitOne();
                Console.WriteLine(Thread.CurrentThread.Name + ": " + Count());
                queue.Enqueue(value);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }
        public T Dequeue()
        {
            try
            {
                _lock.EnterReadLock();
                T val = queue.Dequeue();
                Console.WriteLine(Thread.CurrentThread.Name + ": " + Count());
                s.Release();
                return val;

            }
            finally
            {
                _lock.ExitReadLock(); 
            }

           
        }
        public int Count ()
        {
            return queue.Count;
        }
    }
}
