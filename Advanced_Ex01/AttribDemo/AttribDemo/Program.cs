using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(AssemblyAnalayzer.AnalayzeAssembly(Assembly.GetExecutingAssembly())? "all approved":"not all approved");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("you cant send null to tne method");
            }
        }
    }
}
