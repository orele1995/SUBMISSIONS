using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountsLib;


namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            decimal money;

            Console.WriteLine("Enter balance for the first account");
            decimal balance = Decimal.Parse(Console.ReadLine());
            Account account1 = AccountFactory.CreateAccount(balance);

            printOptions();
            choice = int.Parse(Console.ReadLine());
            while (choice != 0)
            {
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("You have " + account1.Balance + "$ in your account");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter money to deposit");
                            money = Decimal.Parse(Console.ReadLine());
                            account1.Deposit(money);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter money to withdrow");
                            money = Decimal.Parse(Console.ReadLine());
                            if (account1.Withdraw(money))
                            {
                                Console.WriteLine("you withdrow " + money + "$ from your account");
                            }
                            else
                            {
                                Console.WriteLine("you can't withdrow " + money + "$ form your account");
                            }
                            break;
                        }
                }
                printOptions();
                choice = int.Parse(Console.ReadLine());
            }

            //secod account
            Console.WriteLine("Enter balance for the second account");
            balance = Decimal.Parse(Console.ReadLine());
            Account account2 = AccountFactory.CreateAccount(balance);
           
            //transfer
            Console.WriteLine("Enter money to transfer from the first account to the second");
            money = Decimal.Parse(Console.ReadLine());
            if (account2.Transfer(account1, money))
            {
                Console.WriteLine("you transferd " + money + "$ from the first account to the second");
                Console.WriteLine("You have " + account1.Balance + "$ in the first account");
                Console.WriteLine("You have " + account2.Balance + "$ in the second account");

            }
            else
            {
                Console.WriteLine("you can't transferd " + money + "$ from the first account to the second");
                Console.WriteLine("You have " + account1.Balance + "$ in the first account");
                Console.WriteLine("You have " + account2.Balance + "$ in the second account");
            }
        }

        private static void printOptions ()
        {
            Console.WriteLine("1 - check balance");
            Console.WriteLine("2 - deposit money");
            Console.WriteLine("3 - withdrow money");
            Console.WriteLine("0 - exit");
            Console.WriteLine("Enter your choice");
        }
    }
}
