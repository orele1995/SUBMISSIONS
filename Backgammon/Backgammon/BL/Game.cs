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
                int val1 = firstCube.GetCubeValue();
                int val2 = secondCube.GetCubeValue();
                bool doubleTurn = val1 == val2 ? true : false;
                if (player1Turn)
                {
                    Player1.MakeMove(val1);
                    Player1.MakeMove(val2);
                    if (doubleTurn)
                    {
                        Player1.MakeMove(val1);
                        Player1.MakeMove(val2);
                    }
                    checkForGameOver();
                }
                else
                {
                    Player2.MakeMove(val1);
                    Player2.MakeMove(val2);
                    if (doubleTurn)
                    {
                        Player2.MakeMove(val1);
                        Player2.MakeMove(val2);
                    }
                    checkForGameOver();
                }

            }
        }

        private void checkForGameOver()
        {

        }
    }
}
