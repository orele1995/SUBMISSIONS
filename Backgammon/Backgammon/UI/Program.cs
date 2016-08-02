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
            // HumanPlayer player1 = new HumanPlayer(humanPlayerUI.DecideMove);
            // HumanPlayer player2 = new HumanPlayer(humanPlayerUI.DecideMove);
            ComputerPlayer player1 = new ComputerPlayer();
            ComputerPlayer player2 = new ComputerPlayer();

            GameUI gameUI = new GameUI(player1, player2);
            gameUI.TheGame.Play();

        }
    }
}
