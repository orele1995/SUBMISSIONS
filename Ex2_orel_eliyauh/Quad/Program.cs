using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quad
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Wrong number of arguments. expected 3 args.");
                return;
            }

            double a, b, c;
            if (double.TryParse(args[0], out a) == false 
                || double.TryParse(args[1], out b) == false 
                || double.TryParse(args[2], out c) == false )
            {
                Console.WriteLine("Error! can't parse the numbers");
                return;
            }

            double tempResult = b * b - 4 * a * c;
            if (tempResult < 0)
            {
                Console.WriteLine("There is no solution to this equation");
                return;
            }
            if (tempResult==0)
            {
                tempResult = (-b) / (2 * a);
                Console.WriteLine("The solution to this equation is: "+ tempResult);
                return;
            }
            
            double firstSolution, secondSolution; 
            tempResult = Math.Sqrt(tempResult);
            firstSolution = (-(b) - tempResult) / (2 * a);
            secondSolution = (-(b) + tempResult) / (2 * a);
            Console.WriteLine("There are 2 solution to this equation: " + firstSolution + ", " + secondSolution);
        }
    }
}
