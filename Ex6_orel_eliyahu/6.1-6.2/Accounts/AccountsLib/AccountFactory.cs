using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsLib
{
    public static class AccountFactory
    {
        private static int id_counter = 0;

        public static Account CreateAccount (decimal balance)
        {
            Account newAccount = new Account(id_counter++);
            newAccount.Deposit(balance);
            return newAccount;
        }
    }
}
