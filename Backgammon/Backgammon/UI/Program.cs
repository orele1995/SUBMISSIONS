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
            HumanPlayerUI humanPlayerUI = new HumanPlayerUI();
            HumanPlayer player1 = new HumanPlayer(humanPlayerUI.DecideMove);
            HumanPlayer player2 = new HumanPlayer(humanPlayerUI.DecideMove);

            Game game = new Game(player1, player2);
            game.turnStart += (obj, eventArgs) => humanPlayerUI.DrawBoard(eventArgs.Board, eventArgs.PlayerTurn);
            game.dicesThrown += (obj, eventArgs) => humanPlayerUI.printDice(eventArgs.Val1, eventArgs.Val2);
            game.Play();
            Console.WriteLine($"The winner is {game.winner}!!!");

        }
    }
}
