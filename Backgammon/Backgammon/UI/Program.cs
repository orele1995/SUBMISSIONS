using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            IPlayer player1;
            IPlayer player2;
            HumanPlayerUI humanPlayerUI = new HumanPlayerUI();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Choose the way you want to play:");
            Console.WriteLine("1 - Human VS Human");
            Console.WriteLine("2 - Human VS Computer");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
                Console.WriteLine("Please enter a number: 1 or 2");
            if (choice == 1)
            {
                player1 = new HumanPlayer(humanPlayerUI.DecideMove);
                player2 = new HumanPlayer(humanPlayerUI.DecideMove);
            }
            else
            {
                player1 = new HumanPlayer(humanPlayerUI.DecideMove);
                player2 = new ComputerPlayer();
            }
            GameUI gameUI = new GameUI(player1, player2);
            gameUI.TheGame.Play();

        }
    }
}
