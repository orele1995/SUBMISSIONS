using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ComputerPlayer : IPlayer
    {
        static Random rand = new Random();
        //public Func<DecideMoveState, Move> DecideMove { get; set; }
        public PlayerColor playerColor { get; set; }
        public Move MakeMove(List<Move> possibalMoves, GameBoard board)
        {
            var chosenMove = DecideMove(possibalMoves, board);
            board.MovePice(chosenMove);
            return chosenMove;
        }
        private Move DecideMove(List<Move> possibalMoves, GameBoard board)
        {
            List<Move> outMoves = new List<Move>();
            List<Move> eatMoves = new List<Move>();
            List<Move> normalMoves = new List<Move>();

            foreach (var move in possibalMoves)
            {
                if (move.To == 26 || move.To == 27)
                    outMoves.Add(move);
                else if (board[move.To].LineColor != playerColor.ToLineColor())
                    eatMoves.Add(move);
                else
                    normalMoves.Add(move);
            }
            int index;
            if (outMoves.Count > 0)
            {
                index = rand.Next(0, outMoves.Count);
                return outMoves[index];
            }
            if (eatMoves.Count > 0)
            {
                index = rand.Next(0, eatMoves.Count);
                return eatMoves[index];
            }
            index = rand.Next(0, normalMoves.Count);
            return normalMoves[index];
        }
    }
}
