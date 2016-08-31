using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            String name = "";
            int num = 0;
            Console.WriteLine("What’s your name?");
            name = Console.ReadLine();
            Console.WriteLine("Hello " + name + "!");
            Console.WriteLine("enter a number from 1 to 10");
            num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                // print the spases
                for (int j = 0; j < i; j++)
                {
                    Console.Write(" ");
                }

                Console.WriteLine(name);

            }
        }
    }
}
