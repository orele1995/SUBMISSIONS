using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsLib
{
   public class Account
    {
        private readonly int id;
        private decimal balance;

        public int ID
        {
            get { return id; }
        }
        public decimal Balance
        {
            get
            {
                return balance;
            }
        }

        internal Account (int _id)
        {
            id = _id;
        }
        public void Deposit (decimal money)
        {
            balance += money;
        }
        public bool Withdraw (decimal money)
        {
            if (Balance - money > 0)
            {
                balance -= money;
                return true;
            }
            return false;

        }
        public bool Transfer (Account otherAccount, decimal money)
        {
            if (otherAccount.Withdraw(money))
            {
                Deposit(money);
                return true;
            }
            return false;
        }
    }
}
