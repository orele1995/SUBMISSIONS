using System;

namespace BL
{
    public class EndMoveEventArgs: EventArgs
    {
        public GameBoard Board { get; set; }
        public PlayerColor PlayerTurn { set; get; }
        public bool IsLastMove { set; get; }
        public int[] Moves { get; set; }

        public EndMoveEventArgs(GameBoard board, PlayerColor playerTurn, bool isLastMove, int[] moves)
        {
            Board = board;
            PlayerTurn = playerTurn;
            IsLastMove = isLastMove;
            Moves = moves;

        }
    }
}