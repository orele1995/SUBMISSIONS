using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using System.Threading;

namespace UI
{
    class HumanPlayerUI
    {

        public Move DecideMove(DecideMoveState state)
        {
            int from, to;
            if (state == DecideMoveState.READY_FOR_CHOICE)
                Console.WriteLine("Enter your move!");
            else
                Console.WriteLine("Invalid move! try again!");

            Console.Write("From: ");
            while (!int.TryParse(Console.ReadLine(), out from) || from < 1 || (from > 24 && from != 27 && from != 26))
            {
                Console.WriteLine("Please enter a number between 1 to 24 or 26,27");
                Console.Write("From: ");
            }

            Console.Write("To: ");
            while (!int.TryParse(Console.ReadLine(), out to) || to < 0 || to > 25)
            {
                Console.WriteLine("Please enter a number between 0 to 24");
                Console.Write("To: ");
            }
            return new Move(from, to);

        }


    }
}
