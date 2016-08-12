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
            Job job = new Job("job",1);
            job.AddProcessToJob(Process.Start("notepad"));
            job.AddProcessToJob(Process.Start("calc"));
            Console.ReadLine(); 
            job.Kill();

            // --------  B  --------  
            try
            {
                for (int i = 0; i < 20; i++)
                {
                    Job job1 = new Job("work", 0);
                }
            }
            catch (ArgumentException ex) { Console.WriteLine(ex.Message); }

            Console.WriteLine(GC.GetTotalMemory(true));
            List<Job> jobs = new List<Job>();
          for (int i = 0; i < 20; i++)
           {
              jobs.Add(new Job("work"+i, 1024*1024*100));
              jobs[i].AddProcessToJob(Process.Start("notepad"));
              Console.WriteLine(GC.GetTotalMemory(false)); 
           
           }
          Console.WriteLine(GC.GetTotalMemory(false)); 
          Console.ReadLine(); 

        }
    }
}

