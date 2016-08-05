using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UI
{
    class GameUI
    {
        public Game TheGame { get; private set; }
        public GameUI(IPlayer player1, IPlayer player2)
        {
            TheGame = new Game(player1, player2);
            TheGame.startGame += (obj, eventArgs) => OnGameStart(eventArgs.Board);
            TheGame.endMove += (obj, eventArgs) => OnEndMove(eventArgs.Board, eventArgs.PlayerTurn, eventArgs.IsLastMove, eventArgs.Moves);
            TheGame.endTurn += (obj, eventArgs) => OnEndTurn(eventArgs.Board, eventArgs.PlayerTurn);
            TheGame.dicesThrown += (obj, eventArgs) => OnDiceThrown(eventArgs.Val1, eventArgs.Val2);
            TheGame.noMoves += (obj, eventArgs) => OnNoMoves(eventArgs.Player);
            TheGame.endGame += (obj, eventArgs) => OnEndGame(eventArgs.Winner);
        }

        public void OnEndTurn(GameBoard board, PlayerColor thisTurnPalyer)
        {

            if (thisTurnPalyer == PlayerColor.Black)
                Console.WriteLine("Its Red turn!");
            else
                Console.WriteLine("Its Black turn!");
        }
        public void OnDiceThrown(int val1, int val2)
        {
            Console.WriteLine("Roling the dice...");
            Thread.Sleep(1000);
            Console.WriteLine($"First cube: {val1}. Second cube: {val2}.");
            if (val1 == val2)
                Console.WriteLine("DOUBLE!!!");
        }
        public void OnNoMoves(PlayerColor thisTurnPlayer)
        {
            if (thisTurnPlayer == PlayerColor.Black)
                Console.WriteLine("Black has no moves!");
            else
                Console.WriteLine("Red has no moves!");
        }
        public void OnGameStart(GameBoard board)
        {
            DrawBoard(board);
            Console.WriteLine("Red starts!");
        }
        public void OnEndMove(GameBoard board, PlayerColor thisTurnPalyer, bool isLastMove, int[] moves)
        {
            DrawBoard(board);
            Console.WriteLine($"[26] Black jail: {board.BlackJail}. [27] Red jail: {board.WhiteJail}");
            if (!isLastMove)
            {
                if (thisTurnPalyer == PlayerColor.Black)
                    Console.WriteLine("Its Black turn!");
                else
                    Console.WriteLine("Its Red turn!");
                Console.Write("Your moves: ");
                if (moves == null) return;
                foreach (var item in moves)
                {
                    Console.Write($" {item} ");
                }
                Console.WriteLine();
            }
        }
        public void OnEndGame(IPlayer winner)
        {
            Console.WriteLine("=============== GAME OVER!! ===============");
            if (winner.playerColor == PlayerColor.White)
                Console.WriteLine("The winner is Red!!!");
            else
                Console.WriteLine("The winner is Black!!!");
        }

        private void PrintLine(GameLine gameLine, bool isOut = false)
        {
            if (isOut)
            {
                Console.Write("| ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(string.Format("{0,2}", gameLine.PiecesNumber));
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" |");
                return;
            }
            switch (gameLine.LineColor)
            {
                case LineColor.None:
                    {
                        Console.Write(string.Format("{0,6}", "|    |"));
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
            Console.WriteLine("------------------------------------------------------------------------------");
            for (int i = 13; i <= 25; i++)
            {
                Console.Write("| ");
                Console.Write(string.Format("{0,2}", i));
                Console.Write(" |");

            }
            Console.WriteLine();
            for (int i = 13; i <= 24; i++)
                PrintLine(board[i]);
            PrintLine(board[25], true);
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------------------");
            for (int i = 12; i > 0; i--)
                PrintLine(board[i]);
            PrintLine(board[0], true);
            Console.WriteLine();
            for (int i = 12; i >= 0; i--)
            {
                Console.Write("| ");
                Console.Write(string.Format("{0,2}", i));
                Console.Write(" |");
            }
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------------------");


        }
    }
}
