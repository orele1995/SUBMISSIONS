﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsLib
{
    public class InsufficientFundsException: Exception
    {
        public override string Message
        {
            get
            {
                return "You cant withdrow more money than the money that you have";
            }
        }

    }
}
