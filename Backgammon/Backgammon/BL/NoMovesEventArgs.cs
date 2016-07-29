namespace BL
{
    public class NoMovesEventArgs
    {
        public PlayerColor Player { get;  set; }
        public NoMovesEventArgs (PlayerColor player)
        {
            Player = player;
        }
    }
}