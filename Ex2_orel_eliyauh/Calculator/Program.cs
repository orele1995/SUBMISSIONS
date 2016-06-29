using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            char op;
            Double first, second, result = 0;
            Boolean wrongOp = false;
            Console.WriteLine("Enter two numbers and an operator");
            first = int.Parse(Console.ReadLine());
            op = char.Parse(Console.ReadLine());
            second = int.Parse(Console.ReadLine());
            switch (op)
            {
                case '+': 
                    result = first + second; 
                    break;
                case '-': 
                    result = first - second; 
                    break;
                case '*':
                    result = first * second;
                    break;
                case '/':
                    result = first / second;
                    break;
                default:
                    wrongOp = true;
                    break;
            }
            if (!wrongOp)
            {
                Console.WriteLine("The result is: " + result);
            }
            else
            {
                Console.WriteLine("this operation is not one of: +,-,*,/");
            }

        }

    }
}
