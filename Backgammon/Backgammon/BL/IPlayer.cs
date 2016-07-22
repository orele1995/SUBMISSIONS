using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IPlayer
    {
        Func<string, Move> makeOneMove { get; set; }
        GameBoard MakeMove(int cubeNumber);
        bool ValidateMove(Move move, GameBoard board);
        PlayerColor playerColor { get; set; } 
    }
}
