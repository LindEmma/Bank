using Bank.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Logic
{
    internal static class CustomerMethods
    {
        public static Account CreateAccount()
        {
            Console.Write("vad ska ditt konto heta?");
            string AccountName = Console.ReadLine();
            Console.Write("Hur mycket pengar vill du lägga in på kontot?");
            decimal Balance = decimal.Parse(Console.ReadLine());

            return new Account();
            Console.Clear();
        }

        public static void Transfer()
        {
            Console.WriteLine("Vilket konto vill du föra över pengar från?");

            string transferFromAccount = Console.ReadLine();
            Console.WriteLine("Vilket konto vill du föra över pengar till?");

        }

        public static void ShowBalance(List<Account> AccountList)
        {
            if (AccountList.Count != 0)
            {
                foreach (var account in AccountList)
                {
                    account.PrintAccountInfo();
                }
            }
            else
            {
                Console.WriteLine("Du har inga konton");
            }
        }
        public static void AccountNameList(List<Account> accounts)
        {
            foreach (var accountName in accounts)
            {
                accountName.PrintAccountName();
            }
        }
    }
}
