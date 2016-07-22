using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class GameBoard
    {
        List<GameLine> Lines { get; set; }
        public int BlackOut { get; private set; }
        public int WhiteOut { get; private set; }
        public GameBoard ()
        {
            Lines = new List<GameLine>();
            initializeBoard();
        }

        private void initializeBoard()
        {
            Lines.Add(new GameLine(LineColor.White, 2));
            Lines.Add(new GameLine(LineColor.None ,0));
            Lines.Add(new GameLine(LineColor.None, 0));
            Lines.Add(new GameLine(LineColor.None, 0));
            Lines.Add(new GameLine(LineColor.None, 0));
            Lines.Add(new GameLine(LineColor.Black, 5));
            Lines.Add(new GameLine(LineColor.None, 0));
            Lines.Add(new GameLine(LineColor.Black, 3));
            Lines.Add(new GameLine(LineColor.None, 0));
            Lines.Add(new GameLine(LineColor.None, 0));
            Lines.Add(new GameLine(LineColor.White, 5));
            Lines.Add(new GameLine(LineColor.Black, 5));
            Lines.Add(new GameLine(LineColor.None, 0));
            Lines.Add(new GameLine(LineColor.None, 0));
            Lines.Add(new GameLine(LineColor.White, 3));
            Lines.Add(new GameLine(LineColor.None, 0));
            Lines.Add(new GameLine(LineColor.White, 5));
            Lines.Add(new GameLine(LineColor.None, 0));
            Lines.Add(new GameLine(LineColor.None, 0));
            Lines.Add(new GameLine(LineColor.None, 0));
            Lines.Add(new GameLine(LineColor.None, 0));
            Lines.Add(new GameLine(LineColor.Black, 2));



        }
        private int countPieces (LineColor color)
        {
            int count = 0;
            foreach (var line in Lines)
            {
                if (line.LineColor == color)
                {
                    count += line.PiecesNumber;
                }
            }
            return count;
        }

        public void takeOut (LineColor color, int lineNumber)
        {
            if(Lines[lineNumber].LineColor == color)
            {

            }
                
        }
    }
}
