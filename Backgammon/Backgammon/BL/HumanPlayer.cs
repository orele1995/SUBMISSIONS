using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class HumanPlayer : IPlayer
    {
        public Func<DecideMoveState, Move> DecideMove { get; private set; }
        public PlayerColor playerColor { get; set; }

        public Move MakeMove( List<Move> possibalMoves, GameBoard board)
        {
            Move move = DecideMove(DecideMoveState.READY_FOR_CHOICE);
            while (!ValidateMove(move, possibalMoves))
                move = DecideMove(DecideMoveState.INVALID_MOVE);
            board.MovePice(move);
            return move;         
        }
        private bool ValidateMove(Move move, List<Move> possibalMoves)
        {
            foreach (var item in possibalMoves)
            {
                if (item == move)
                    return true;
            }
            return false;
        }
        public HumanPlayer(Func<DecideMoveState, Move> decideMove)
        {
            DecideMove = decideMove;
        }
    }
}
