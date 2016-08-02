using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IPlayer
    { 
       // Func<DecideMoveState, Move> DecideMove { get; set; }
        Move MakeMove( List<Move> possibalMoves,  GameBoard board);
        PlayerColor playerColor { get; set; } 
    }
}
