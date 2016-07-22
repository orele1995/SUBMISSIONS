using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class GameLine
    {
        public LineColor LineColor { get; private set; } 
        public int PiecesNumber { get; private set; }
        public GameLine()
        {
            LineColor = LineColor.None;
            PiecesNumber = 0;
        }
        public GameLine(LineColor color, int piesesNumber)
        {
            LineColor = color;
            PiecesNumber = piesesNumber;
        }
        public static GameLine operator ++ (GameLine toAdd)
        {
            toAdd.PiecesNumber += 1;
            return toAdd;
        }
        public static GameLine operator -- (GameLine toDec)
        {
            if (toDec.PiecesNumber!=0)
            {
                toDec.PiecesNumber -= 1;
                if (toDec.PiecesNumber == 0)
                {
                    toDec.LineColor = LineColor.None;
                }
            }
            
            return toDec;
        }

    }
}
