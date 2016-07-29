using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Move
    {
        public int From { get; set; }
        public int To { get; set; }

        public Move (int from, int to)
        {
            From = from;
            To = to;
        }
        public override bool Equals(object obj)
        {
            Move other = obj as Move;
            if (other == null)
                return false;
            return other.From == From && other.To == To;
        }
        public override int GetHashCode()
        {
            return (From+To).GetHashCode();
        }
        public static bool operator == (Move m1, Move m2)
        {
            return Equals(m1,m2);
             
        }
        public static bool operator !=(Move m1, Move m2)
        {
            return !(m1 == m2);
        }

    }

}
