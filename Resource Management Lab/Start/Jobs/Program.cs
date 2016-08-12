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
            
           for (int i = 0; i < 20; i++)
           {
               Job job1 = new Job("work", 0);   
           }

          for (int i = 0; i < 20; i++)
           {
               Job job1 = new Job("work", 1024*1024*10);              
           }
        }
    }
}

