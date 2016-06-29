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
            if (money < 0)
            {
                throw new ArgumentOutOfRangeException("money can't be negative!");
            }
            balance += money;
        }
        public void Withdraw (decimal money)
        {
            if (money < 0)
            {
                throw new ArgumentOutOfRangeException("money can't be negative!");
            }

            if (Balance - money < 0)
            {
                throw new InsufficientFundsException();
            }
            balance -= money;


        }
        public bool Transfer (Account otherAccount, decimal money)
        {
            decimal balanceBeforeTrans = Balance;
            try
            {
                otherAccount.Withdraw(money);
                Deposit(money);
                
            }
            finally
            {
                Console.WriteLine("A transfer attempt has been made");
                Console.WriteLine("balance befor attempt: "+ balanceBeforeTrans);
                Console.WriteLine("balance after attempt: " + Balance);

            }
            return false;
        }
    }
}
