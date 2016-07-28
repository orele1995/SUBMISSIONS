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
        public void DrawBoard(GameBoard board, PlayerColor palyerTurn)
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
           
            Console.WriteLine();
                for (int i = 13; i <= 24; i++)
            {
                var gameLine = board[i];
                if (gameLine.LineColor == LineColor.None)
                
                    Console.Write($"|{i}: {gameLine.LineColor}|");             
                else
                    Console.Write($"|{i}: {gameLine.PiecesNumber} {gameLine.LineColor}|");
            }
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
            for (int i = 12; i > 0; i--)
            {
                var gameLine = board[i];
                if (gameLine.LineColor == LineColor.None)

                    Console.Write($"|{i}: {gameLine.LineColor}|");
                else
                    Console.Write($"|{i}: {gameLine.PiecesNumber} {gameLine.LineColor}|");
            }
            Console.WriteLine();
            
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"White out: {board.WhiteOut} Black out: {board.BlackOut}");
            Console.WriteLine($"White jail: {board.WhiteJail} Black jail: {board.BlackJail}");

            if (palyerTurn == PlayerColor.Black)
                Console.WriteLine("Its balck turn!");
            else
                Console.WriteLine("Its White turn!");
        }

        public Move DecideMove(DecideMoveState state)
        {
            int from, to;
            if (state == DecideMoveState.READY_FOR_CHOICE)
                Console.WriteLine("Enter your move!");
            else
                Console.WriteLine("Invalid move! try again!");

            Console.Write ("From: ");
            while (!int.TryParse(Console.ReadLine(), out from) || from < 1 || (from> 24 && from != 27 && from != 27) )
            {
                Console.WriteLine("Please enter a number between 1 to 24 or 26,27");
                Console.Write("From: ");
            }

            Console.Write("To: ");
            while (!int.TryParse(Console.ReadLine(), out to) || from < 0 || from > 25)
            {
                Console.WriteLine("Please enter a number between 0 to 24");
                Console.Write("To: ");
            }
            return new Move(from, to);

        }

        public void printDice ( int val1, int val2)
        {
            Console.WriteLine("Roling the dice...");
            Thread.Sleep(1000);
            Console.WriteLine($"First cube: {val1}. Second cube: {val2}.");
            if (val1 == val2)
                Console.WriteLine("DOUBLE!!!");
        }

       

    }
}
