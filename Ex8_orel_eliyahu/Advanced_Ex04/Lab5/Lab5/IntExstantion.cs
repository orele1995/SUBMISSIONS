using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
   static class IntExstantion
    {
        public static TaskAwaiter GetAwaiter(this int millisecondsDue)
        {
            return Task.Delay(millisecondsDue).GetAwaiter();
        }
    }
}
