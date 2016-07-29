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
        
        public void PrintTurn(GameBoard board, PlayerColor thisTurnPalyer)
        {
            DrawBoard(board);
            Console.WriteLine($"Red out: {board.WhiteOut} Black out: {board.BlackOut}");
            Console.WriteLine($"Red jail: {board.WhiteJail} Black jail: {board.BlackJail}");

            if (thisTurnPalyer == PlayerColor.Black)
                Console.WriteLine("Its Red turn!");
            else
                Console.WriteLine("Its Black turn!");
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
        public void NoMoves (PlayerColor thisTurnPlayer)
        {
            Console.WriteLine($"{thisTurnPlayer} has no moves!");

            if (thisTurnPlayer == PlayerColor.Black)
            Console.WriteLine($"{PlayerColor.White} turn!");
            else
                Console.WriteLine($"{PlayerColor.Black} turn!");
        }
        public void StartGame ( GameBoard board)
        {
            DrawBoard(board);
            Console.WriteLine("Red starts!");
        }
        private void PrintLine(GameLine gameLine)
        {
            switch (gameLine.LineColor)
            {
                case LineColor.None:
                    {
                        Console.Write(string.Format("{0,6}", "| 0 |"));
                        break;
                    }
                case LineColor.White:
                    {
                        Console.Write("| ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(string.Format("{0,2}", gameLine.PiecesNumber));
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" |");
                        break;
                    }
                case LineColor.Black:
                    {
                        Console.Write("| ");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(string.Format("{0,2}", gameLine.PiecesNumber));
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" |");
                        break;
                    }
            }
        }
        private void DrawBoard(GameBoard board)
        {
            Console.WriteLine("------------------------------------------------------------------------");
            for (int i = 13; i <= 24; i++)
                Console.Write(string.Format("{0,6}", $"| {i} |"));
            Console.WriteLine();
            for (int i = 13; i <= 24; i++)
                PrintLine(board[i]);
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------------");
            for (int i = 12; i > 0; i--)
                PrintLine(board[i]);
            Console.WriteLine();
            for (int i = 12; i > 0; i--)
                Console.Write(string.Format("{0,6}", $"| {i} |"));
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------------");


        }
        

    }
}
