using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Game
    {
        public EventHandler<TurnStartEventArgs> turnStart;
        public EventHandler<DicesThrownEventArgs> dicesThrown;

        GameBoard board = new GameBoard();
        Cube firstCube = new Cube();
        Cube secondCube = new Cube();
        public IPlayer Player1 { get; private set; }
        public IPlayer Player2 { get; private set; }
        bool gameOver = false;
        bool player1Turn = true;
        public IPlayer winner { get; private set; }

       public Game(IPlayer player1, IPlayer player2)
        {
            Player1 = player1;
            Player2 = player2;
            player1.playerColor = PlayerColor.White;
            player2.playerColor = PlayerColor.Black;
        }

        public void Play()
        {
            while (!gameOver)
            {
                int val1 = firstCube.GetCubeValue();
                int val2 = secondCube.GetCubeValue();
                dicesThrown?.Invoke(this, new DicesThrownEventArgs(val1, val2));
                int numOfMoves = val1 == val2 ? 4 : 2;
                if (player1Turn)
                {
                    turnStart?.Invoke(this, new TurnStartEventArgs(board,Player1.playerColor));
                    MakeTurn(Player1, numOfMoves, val1, val2);
                    CheckForGameOver();
                }
                else
                {
                    turnStart?.Invoke(this, new TurnStartEventArgs(board, Player2.playerColor));
                    MakeTurn(Player2, numOfMoves, val1, val2);
                    CheckForGameOver();
                }
            }
        }

        private void CheckForGameOver()
        {
            if (board.BlackOut == 15)
            {
                winner = Player1;
                gameOver = true;
                return;
            }
            if (board.WhiteOut == 15)
            {
                winner = Player2;
                gameOver = true;
                return;
            }

        }

        private void MakeTurn(IPlayer player, int numOfMoves, int val1, int val2)
        {
            if (numOfMoves == 4)
            {
                player.MakeMove(GetPossibalMoves(player.playerColor, val1),  board);
                player.MakeMove(GetPossibalMoves(player.playerColor, val2),  board);
                player.MakeMove(GetPossibalMoves(player.playerColor, val1),  board);
                player.MakeMove(GetPossibalMoves(player.playerColor, val2),  board);
            }
            else
            {
                player.MakeMove(GetPossibalMoves(player.playerColor, val1),  board);
                player.MakeMove(GetPossibalMoves(player.playerColor, val2),  board);
            }
        }

        private List<Move> GetPossibalMoves(PlayerColor color, int val)
        {
            List<Move> possibalMoves = new List<Move>();

            if (board.IsJailed(color))
            {
                Move jailOut = board.TryJailOut(color.ToLineColor(), val);
                if (jailOut != null)
                    possibalMoves.Add(jailOut);
                return possibalMoves;
            }
            possibalMoves = color == PlayerColor.Black ? GetPossibalMovesBlack(val) : GetPossibalMovesWhite(val);
            return possibalMoves;

        }
        private List<Move> GetPossibalMovesBlack (int val)
        {
            List<Move> possibalMoves = new List<Move>();

            for (int i = 24; i < val; i--)
                if (board[i].LineColor == LineColor.Black)
                {
                    var toLine = board[i - val];
                    if (toLine.LineColor == LineColor.Black ||
                        toLine.LineColor == LineColor.None ||
                        toLine.LineColor == LineColor.White && toLine.PiecesNumber == 1)
                        possibalMoves.Add(new Move(i, i - val));
                }

            if (board.CanTakeOut(PlayerColor.Black))
            {
                for (int i = 1; i <= val; i++)               
                    if (board[i].LineColor == LineColor.Black)                   
                        possibalMoves.Add(new Move(i, 0));               
            }
            return possibalMoves;

        }
        private List<Move> GetPossibalMovesWhite(int val)
        {
            List<Move> possibalMoves = new List<Move>();

            for (int i = 0; i < board.Lines.Count - val; i++)
                if (board[i].LineColor == LineColor.White)
                {
                    var toLine = board[i + val];
                    if (toLine.LineColor == LineColor.White ||
                        toLine.LineColor == LineColor.None ||
                        (toLine.LineColor == LineColor.Black && toLine.PiecesNumber == 1 ))
                        possibalMoves.Add(new Move(i, i + val));
                }

            if (board.CanTakeOut(PlayerColor.White))
            {
                for (int i = 25 - val; i <= 24; i++)
                    if (board[i].LineColor == LineColor.Black)
                        possibalMoves.Add(new Move(i, 25));
            }
            return possibalMoves;

        }
    }
}

