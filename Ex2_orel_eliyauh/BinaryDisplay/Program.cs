using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryDisplay
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number ");
            int number = int.Parse(Console.ReadLine());
            printResult (binaryDis(number), numOfOnes(number));
        }

        // returns a string of 0 anf 1 that represents the number
        private static String binaryDis(int number)
        {
            // מקרה קצה
            if (number == 0)
            {
                return "0";
            }

            else
            {
                string binaryNumber = "";

                // for each bit in the number, checks if it is 1 or 0
                for (int i = 1; i <= number; i *= 2)
                {
                    if ((number & i) == i)
                    {
                        binaryNumber = "1" + binaryNumber;
                    }
                    else
                    {
                        binaryNumber = "0" + binaryNumber;
                    }

                }
                return binaryNumber;
            }
        }

        // returns the number of 1 in the bynary number 
        private static int numOfOnes(int number)
        {
            int onesCounter = 0;
            while(number!=0)
            {
                if ((number & 1) == 1)
                    onesCounter++;
                number = number >> 1;

            }
            return onesCounter;
        }

        // displays the results on the consule
        private static void printResult(string binaryNum, int numOfOnes)
        {
            Console.WriteLine("The binary number is "+ binaryNum);
            Console.WriteLine("There are "+numOfOnes+" ones in the number");
        }
    }
}
