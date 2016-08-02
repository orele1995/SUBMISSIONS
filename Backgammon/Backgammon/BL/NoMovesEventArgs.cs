using System;

namespace BL
{
    public class NoMovesEventArgs: EventArgs

    {
        public PlayerColor Player { get;  set; }
        public NoMovesEventArgs (PlayerColor player)
        {
            Player = player;
        }
    }
}