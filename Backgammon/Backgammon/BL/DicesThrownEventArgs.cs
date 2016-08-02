using System;

namespace BL
{
    public class DicesThrownEventArgs: EventArgs
    {
        public int Val1 { get; set; }
        public int Val2 { get; set; }
        public DicesThrownEventArgs (int val1, int val2)
        {
            Val1 = val1;
            Val2 = val2;
        }
    }
}