using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace Jobs
{
    class Program
    {
        static void Main(string[] args)

        {

            // --------  A  --------  
            try
            {
                Job job = new Job("job");
                job.AddProcessToJob(Process.Start("notepad"));
                job.AddProcessToJob(Process.Start("calc"));
                Console.ReadLine();
                job.Kill();
            }
            catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
            catch (ObjectDisposedException ex) { Console.WriteLine(ex.ObjectName + " is disposed"); }

            // --------  B  --------  
           
            try // will cause an exception
            {
                for (int i = 0; i < 20; i++)
                {
                    Job job1 = new Job("work", 0);
                }
            }
            catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
           
            try
            {
                List<Job> jobs = new List<Job>();
                for (int i = 0; i < 20; i++)
                {
                    Job j = new Job("work" + i, 10 * 1024 * 1024);
                }
                Console.ReadLine();
            }
            catch (ArgumentException ex) { Console.WriteLine(ex.Message); }

        }
    }
}

