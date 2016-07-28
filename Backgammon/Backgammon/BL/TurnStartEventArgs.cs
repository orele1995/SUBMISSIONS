namespace BL
{
    public class TurnStartEventArgs
    {
        public GameBoard Board { get; set; }
        public PlayerColor PlayerTurn { set; get; }
        public TurnStartEventArgs (GameBoard board, PlayerColor playerTurn)
        {
            Board = board;
            PlayerTurn = playerTurn;
        }
    }
}