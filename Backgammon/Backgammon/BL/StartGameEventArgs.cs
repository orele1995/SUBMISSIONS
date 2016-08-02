using System;

namespace BL
{
    public class StartGameEventArgs : EventArgs
    {
        public GameBoard Board { get; set; }
        public StartGameEventArgs (GameBoard board)
        {
            Board = board;
        }
    }
}