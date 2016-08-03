using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Game
    {
        public EventHandler<DicesThrownEventArgs> dicesThrown;
        public EventHandler<StartGameEventArgs> startGame;
        public EventHandler<NoMovesEventArgs> noMoves;
        public EventHandler<EndTurnEventArgs> endTurn;
        public EventHandler<EndMoveEventArgs> endMove;
        public EventHandler<EndGameEventArgs> endGame;

        GameBoard board = new GameBoard();
        Cube firstCube = new Cube();
        Cube secondCube = new Cube();
        public IPlayer Player1 { get; private set; }
        public IPlayer Player2 { get; private set; }
        bool gameOver = false;
        bool player1Turn = true;
        IPlayer winner;

        public Game(IPlayer player1, IPlayer player2)
        {
            Player1 = player1;
            Player2 = player2;
            player1.playerColor = PlayerColor.White;
            player2.playerColor = PlayerColor.Black;
        }

        public void Play()
        {
            startGame?.Invoke(this, new StartGameEventArgs(board));
            while (!gameOver)
            {
                int val1 = firstCube.GetCubeValue();
                int val2 = secondCube.GetCubeValue();
                dicesThrown?.Invoke(this, new DicesThrownEventArgs(val1, val2));
                if (player1Turn)
                {
                    MakeTurn(Player1, val1, val2);
                    endTurn?.Invoke(this, new EndTurnEventArgs(board, Player1.playerColor));
                }
                else
                {
                    MakeTurn(Player2, val1, val2);
                    endTurn?.Invoke(this, new EndTurnEventArgs(board, Player2.playerColor));
                }
                player1Turn = !player1Turn;
            }
            endGame?.Invoke(this, new EndGameEventArgs(winner));
        }

        private void CheckForGameOver()
        {
            if (board.BlackOut == 15)
            {
                winner = Player2;
                gameOver = true;
                return;
            }
            if (board.WhiteOut == 15)
            {
                winner = Player1;
                gameOver = true;
                return;
            }

        }

        private void MakeTurn(IPlayer player, int val1, int val2)
        {
            if (val1 == val2)
            {
                Move move;
                for (int i = 0; i < 3; i++)
                {
                    if (gameOver) return;
                    move = TryMove(player, GetPossibalMoves(player.playerColor, val1));
                    if (move == null)
                        return;
                    int[] nextMoves = new int[3 - i];
                    for (int j = 0; j < nextMoves.Length; j++)
                        nextMoves[j] = val1;
                    endMove?.Invoke(this, new EndMoveEventArgs(board, player.playerColor, false,nextMoves));
                }
                if (gameOver) return;
                move = TryMove(player, GetPossibalMoves(player.playerColor, val1));
                if (move == null)
                    return;
                endMove?.Invoke(this, new EndMoveEventArgs(board, player.playerColor, true, null));
            }
            else
            {
                List<Move> allMoves = GetPossibalMoves(player.playerColor, val1);
                allMoves.AddRange(GetPossibalMoves(player.playerColor, val2));

                Move move = TryMove(player, allMoves);
                if (move == null)
                    return;


                if (gameOver)
                {
                    endMove?.Invoke(this, new EndMoveEventArgs(board, player.playerColor, false,null ));
                    return;
                }

                var currrentMove = GetValByMove(move, val1, val2);

                if (currrentMove == val1)
                {
                    endMove?.Invoke(this, new EndMoveEventArgs(board, player.playerColor, false, new int[] { val2 }));
                    TryMove(player, GetPossibalMoves(player.playerColor, val2));
                }
                else
                {
                    endMove?.Invoke(this, new EndMoveEventArgs(board, player.playerColor, false, new int[] { val1 }));
                    TryMove(player, GetPossibalMoves(player.playerColor, val1));
                    }
                endMove?.Invoke(this, new EndMoveEventArgs(board, player.playerColor, true, null));

            }
        }

        private Move TryMove(IPlayer player, List<Move> moves)
        {
            if (moves.Count == 0)
            {
                noMoves?.Invoke(this, new NoMovesEventArgs(player.playerColor));
                return null;
            }
            var move = player.MakeMove(moves, board);
            CheckForGameOver();
            return move;
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
        private List<Move> GetPossibalMovesBlack(int val)
        {
            List<Move> possibalMoves = new List<Move>();

            for (int i = 24; i >= val; i--)
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

            for (int i = 0; i <= 24 - val; i++)
                if (board[i].LineColor == LineColor.White)
                {
                    var toLine = board[i + val];
                    if (toLine.LineColor == LineColor.White ||
                        toLine.LineColor == LineColor.None ||
                        (toLine.LineColor == LineColor.Black && toLine.PiecesNumber == 1))
                        possibalMoves.Add(new Move(i, i + val));
                }

            if (board.CanTakeOut(PlayerColor.White))
            {
                for (int i = 25 - val; i <= 24; i++)
                    if (board[i].LineColor == LineColor.White)
                        possibalMoves.Add(new Move(i, 25));
            }
            return possibalMoves;

        }
        private int GetValByMove(Move move, int val1, int val2)
        {
            int diff;
            if (move.From == 26) // if black jail
                diff = 25 - move.To;
            else if (move.From == 27) //if white jail
                diff = move.To;
            else return Math.Abs(move.From - move.To); // if a normal move
            if (diff <= val1 && diff <= val2) return Math.Min(val1, val2);
            if (diff < val1) return val2;
            return val1;
        }

    }
}

