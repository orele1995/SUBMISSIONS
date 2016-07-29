using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class ComputerPlayer : IPlayer
    {
        static Random rand = new Random();
        public Func<DecideMoveState, Move> DecideMove { get; set; }
        public PlayerColor playerColor { get; set; }
        public Move MakeMove(List<Move> possibalMoves, GameBoard board)
        {
            int index = rand.Next(0, possibalMoves.Count);
            board.MovePice(possibalMoves[index]);
            return possibalMoves[index];
        }
    }
}
