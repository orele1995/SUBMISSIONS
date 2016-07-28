using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public enum LineColor { Black, White, None };
    public enum PlayerColor { Black, White };
    public static class PlayerColorExtantion
    {

        public static LineColor ToLineColor(this PlayerColor color)
        {
            if (color == PlayerColor.Black)
                return LineColor.Black;
            else
                return LineColor.White;
        }
    }



}
