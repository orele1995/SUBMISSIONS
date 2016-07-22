using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace LinqToObject
{
    class Program
    {
        static void Main(string[] args)
        {
            var processAccessChacker = new ProcessAccessChacker();

            // ***************** a *******************
            Console.WriteLine("============= Interfaces ===============");

            var types = typeof(string).Assembly.GetTypes();
            var query = from type in types
                        where type.IsInterface == true && type.IsPublic
                        orderby type.Name
                        select new
                        {
                            Name = type.Name,
                            Methods = type.GetMethods().ToArray().Length
                        };
            foreach (var item in query)
            {
                Console.WriteLine($"Name: {item.Name} Methods: {item.Methods}");
            }

            // ***************** b *******************

            Console.WriteLine("============= Processes b ===============");
            var query2 = from p in Process.GetProcesses()
                         where processAccessChacker.canAccess(p) && p.Threads.Count < 5
                         orderby p.Id
                         select new
                         {
                             Name = p.ProcessName,
                             ID = p.Id,
                             StratTime = p.StartTime,
                             BaseP = p.BasePriority //for c
                         };
            foreach (var p in query2)
            {
                Console.WriteLine($"Name: {p.Name} ID: {p.ID} StartTime: {p.StratTime}");
            }

            // ***************** c *******************

            Console.WriteLine("============= Processes c ===============");
            var query3 = from p in query2
                         group p by p.BaseP into g
                         select new
                         {
                             BaseP = g.Key,
                             processes = g
                         };

            foreach (var g in query3)
            {
                Console.WriteLine($"Priority {g.BaseP}:");
                foreach (var p in g.processes)
                {
                    Console.WriteLine($"Name: {p.Name} ID: {p.ID} StartTime: {p.StratTime}");

                }
            }


            // ***************** d *******************

            Console.WriteLine("============= Processes d ===============");
            var query4 = from p in Process.GetProcesses()
                         select p.Threads.Count;
            Console.WriteLine($"Total threads: {query4.Sum()}");


            // ***************** e *******************

            var sorceA = new A ();
            var destA = new A();
            Console.WriteLine("Before:");
            foreach (var p in destA.GetType().GetProperties())
            {
                Console.WriteLine($"sorce: {p.Name} = {p.GetValue(sorceA)}");
                Console.WriteLine($"dest: {p.Name} = {p.GetValue(destA)}");
            }
            sorceA.CopyTo(destA);
            Console.WriteLine("After:");
            foreach (var p in destA.GetType().GetProperties())
            {
                Console.WriteLine($"sorce: {p.Name} = {p.GetValue(sorceA)}");
                Console.WriteLine($"dest: {p.Name} = {p.GetValue(destA)}");
            }

        }
    }

}