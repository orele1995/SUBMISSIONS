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

    }
}
