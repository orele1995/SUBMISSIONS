using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int secret = new Random().Next(1, 100);
            int numOfGuesses = 1, guess;
            Console.WriteLine("Enter your guess!");
            guess = int.Parse(Console.ReadLine());

            while (guess != secret && numOfGuesses <= 7)
            {
                if (guess < secret)
                {
                    Console.WriteLine("Wrong guess! Enter a bigger guess!");
                }
                else
                {
                    Console.WriteLine("Wrong guess! Enter a smaller guess!");
                }
                guess = int.Parse(Console.ReadLine());
                numOfGuesses++;
            }
            if (numOfGuesses <= 7)
                Console.WriteLine("The secret is " +secret + "! you have guessed it in " + numOfGuesses + " guesses" );
            else
                Console.WriteLine("You lost! The secret is " + secret );

        }
    }
}
