using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class Game
    {
        Action<GameBoard> drawBoard;
        GameBoard board = new GameBoard();
        Cube firstCube = new Cube();
        Cube secondCube = new Cube();
        public IPlayer Player1 { get; private set; }
        public IPlayer Player2 { get; private set; }
        bool gameOver = false;
        bool player1Turn = true;

        Game(Action<GameBoard> howToDraw, IPlayer player1, IPlayer player2)
        {
            drawBoard = howToDraw;
            Player1 = player1;
            Player2 = player2;
        }

        public void Play ()
        {
            while (! gameOver)
            {
                if (player1Turn)
                {

                }
            }
        }

    }
}
