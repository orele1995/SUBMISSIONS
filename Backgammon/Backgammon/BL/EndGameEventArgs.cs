using System;

namespace BL
{
    public class EndGameEventArgs: EventArgs
    {
        public IPlayer Winner { get; set; }
        public EndGameEventArgs(IPlayer winner)
        { Winner = winner; } 
    }
}