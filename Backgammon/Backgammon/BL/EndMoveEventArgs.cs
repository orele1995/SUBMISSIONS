namespace BL
{
    public class EndMoveEventArgs
    {
        public GameBoard Board { get; set; }
        public PlayerColor PlayerTurn { set; get; }
        public EndMoveEventArgs (GameBoard board, PlayerColor playerTurn)
        {
            Board = board;
            PlayerTurn = playerTurn;
        }
    }
}