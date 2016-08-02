using System;

namespace BL
{
    public class EndTurnEventArgs: EventArgs
    {
        public GameBoard Board { get; set; }
        public PlayerColor PlayerTurn { set; get; }
        public EndTurnEventArgs(GameBoard board, PlayerColor playerTurn)
        {
            Board = board;
            PlayerTurn = playerTurn;
        }
    }
}