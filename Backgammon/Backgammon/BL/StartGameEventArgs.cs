namespace BL
{
    public class StartGameEventArgs
    {
        public GameBoard Board { get; set; }
        public StartGameEventArgs (GameBoard board)
        {
            Board = board;
        }
    }
}