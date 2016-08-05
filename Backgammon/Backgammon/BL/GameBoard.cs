using System.Collections.Generic;

namespace BL
{
    public class GameBoard
    {
        public List<GameLine> Lines { get; private set; }
        public int BlackOut { get
            {
                return Lines[0].PiecesNumber;
            }
             private set
            {
                Lines[0].PiecesNumber = value;
            }
        }
        public int WhiteOut
        {
            get
            {
                return Lines[25].PiecesNumber;
            }
            private set
            {
                Lines[25].PiecesNumber = value;
            }
        }
        public int BlackJail
        {
            get
            {
                return Lines[26].PiecesNumber;
            }
            private set
            {
                Lines[26].PiecesNumber = value;
            }
        }
        public int WhiteJail
        {
            get
            {
                return Lines[27].PiecesNumber;
            }
            private set
            {
                Lines[27].PiecesNumber = value;
            }
        }
        public GameBoard()
        {
            Lines = new List<GameLine>();
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            Lines.Add(new GameLine(LineColor.Black, 0, false)); // black out - 0
            Lines.Add(new GameLine(LineColor.White, 2)); // 1
            Lines.Add(new GameLine(LineColor.None, 0)); // 2
            Lines.Add(new GameLine(LineColor.None, 0)); // 3
            Lines.Add(new GameLine(LineColor.None, 0)); // 4
            Lines.Add(new GameLine(LineColor.None, 0)); // 5
            Lines.Add(new GameLine(LineColor.Black, 5)); //6
            Lines.Add(new GameLine(LineColor.None, 0)); // 7
            Lines.Add(new GameLine(LineColor.Black, 3)); // 8
            Lines.Add(new GameLine(LineColor.None, 0)); // 9 
            Lines.Add(new GameLine(LineColor.None, 0)); // 10
            Lines.Add(new GameLine(LineColor.None, 0)); // 11
            Lines.Add(new GameLine(LineColor.White, 5)); // 12
            Lines.Add(new GameLine(LineColor.Black, 5)); // 13
            Lines.Add(new GameLine(LineColor.None, 0)); // 14
            Lines.Add(new GameLine(LineColor.None, 0)); // 15
            Lines.Add(new GameLine(LineColor.None, 0)); // 16 
            Lines.Add(new GameLine(LineColor.White, 3)); // 17 
            Lines.Add(new GameLine(LineColor.None, 0)); // 18
            Lines.Add(new GameLine(LineColor.White, 5)); // 19 
            Lines.Add(new GameLine(LineColor.None, 0)); // 20
            Lines.Add(new GameLine(LineColor.None, 0)); // 21
            Lines.Add(new GameLine(LineColor.None, 0)); // 22
            Lines.Add(new GameLine(LineColor.None, 0)); // 23
            Lines.Add(new GameLine(LineColor.Black, 2)); // 24
            Lines.Add(new GameLine(LineColor.White, 0, false)); // white out - 25
            Lines.Add(new GameLine(LineColor.Black, 0, false)); // black jail - 26
            Lines.Add(new GameLine(LineColor.White, 0, false)); // white jail - 27
        }
        public bool MovePice(Move move)
        {
            if (Lines[move.From].LineColor == LineColor.None)// move from an emptey line
                return false;
            if (Lines[move.To].LineColor != LineColor.None && Lines[move.From].LineColor != Lines[move.To].LineColor)
            {
                if (Lines[move.To].PiecesNumber > 1) // move to already taken line that has more then one pice 
                    return false;
                else // move to a line that has only one pice on it. eat it.
                {
                    Jail(Lines[move.To]);
                    Lines[move.To].addOne(Lines[move.From].LineColor);
                    Lines[move.From]--;
                    return true;
                }
            }

            Lines[move.To].addOne(Lines[move.From].LineColor);
            Lines[move.From]--;

            return true;
        }
        private void Jail(GameLine gameLine)
        {
            if (gameLine.LineColor == LineColor.Black)
                BlackJail++;
            else
                WhiteJail++;
            gameLine--;
        }
        public Move TryJailOut(LineColor color, int val)
        {
            int jailOutPlace;
            if (color == LineColor.Black)
            {
                jailOutPlace = 24 + 1 - val;
                if (Lines[jailOutPlace].LineColor == LineColor.Black ||
                    Lines[jailOutPlace].LineColor == LineColor.None ||
                   (Lines[jailOutPlace].LineColor == LineColor.White && Lines[jailOutPlace].PiecesNumber == 1))
                {
                    return new Move(26, jailOutPlace);
                }
            }
            if (color == LineColor.White)
            {
                jailOutPlace = val;
                if (Lines[jailOutPlace].LineColor == LineColor.White ||
                    Lines[jailOutPlace].LineColor == LineColor.None ||
                    (Lines[jailOutPlace].LineColor == LineColor.Black && Lines[jailOutPlace].PiecesNumber == 1))
                {
                    return new Move(27, jailOutPlace);
                }
            }
            return null;
        }
        public GameLine this[int index]
        {
            get
            {
                return Lines[index];
            }

        }
        public bool IsJailed(PlayerColor color)
        {
            if (color == PlayerColor.Black)
                return BlackJail != 0;
            else
                return WhiteJail != 0;
        }
        public bool CanTakeOut (PlayerColor color)
        {
            if (color == PlayerColor.Black)
            {
                for (int i = 7; i <= 25; i++)
                {
                    if (Lines[i].LineColor == LineColor.Black)
                        return false;
                }
                return true;
            }
            else
            {
                for (int i = 1; i <= 18; i++)
                {
                    if (Lines[i].LineColor == LineColor.White)
                        return false;
                }
                return true;
            }
        }


        // unused
        public void TakeOut(LineColor color, int lineNumber)
        {
            if (color == LineColor.None)
                return;
            if (Lines[lineNumber].LineColor == color)
            {
                Lines[lineNumber]--;
                if (color == LineColor.Black)
                    BlackOut++;
                else
                    WhiteOut++;

            }

        }
        public void JailOut(LineColor color, int val)
        {
            if (color == LineColor.Black)
            {
                if (Lines[23 - val].LineColor == LineColor.Black || Lines[23 - val].LineColor == LineColor.None)
                {
                    Lines[23 - val].addOne(LineColor.Black);
                    BlackJail--;
                }
            }
            if (color == LineColor.White)
            {
                if (Lines[val - 1].LineColor == LineColor.White || Lines[val - 1].LineColor == LineColor.None)
                {
                    Lines[val - 1].addOne(LineColor.White);
                    WhiteJail--;
                }
            }
        }
        private int CountPieces(LineColor color)
        {
            int count = 0;
            foreach (var line in Lines)
            {
                if (line.LineColor == color)
                {
                    count += line.PiecesNumber;
                }
            }
            return count;
        }

    }
}
