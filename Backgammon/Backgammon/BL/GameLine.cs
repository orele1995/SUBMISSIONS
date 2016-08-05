using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class GameLine
    {
        public LineColor LineColor { get; private set; } = LineColor.None;
        public int PiecesNumber { get; set; } = 0;
        public bool IsColorChangable { get; private set; } = true;
        public GameLine() { }
        public GameLine(LineColor color, int piesesNumber, bool isColorChangable = true)
        {
            LineColor = color;
            PiecesNumber = piesesNumber;
            IsColorChangable = isColorChangable;

        }
        public void addOne(LineColor color)
        {
            if (LineColor == LineColor.None)
                LineColor = color;
            PiecesNumber += 1;
        }

        public static GameLine operator -- (GameLine toDec)
        {
            if (toDec.PiecesNumber!=0)
            {
                toDec.PiecesNumber -= 1;
                if (toDec.PiecesNumber == 0 && toDec.IsColorChangable)
                {
                    toDec.LineColor = LineColor.None;
                }
            }
            
            return toDec;
        }


    }
}
