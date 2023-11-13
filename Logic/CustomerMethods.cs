using Bank.Classes;
using System;
using System.Collections;
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
            Console.Write("vad ska ditt konto heta? ");
            string AccountName = Console.ReadLine();
            Console.Write("Hur mycket pengar vill du lägga in på kontot? ");
            decimal Balance = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Kontot har skapats!");
            Console.WriteLine("\nTryck på valfri knapp för att fortsätta.");
            Console.ReadKey();
            return new Account(Balance, AccountName);
        }
        public static void ShowBalance(List<Account> AccountList)
        {
            if (AccountList.Count == 0)
            {
                Console.WriteLine("Det finns inga konton");
            }
            else
            {
                foreach (var account in AccountList)
                {
                    account.PrintAccountInfo();
                }
            }
            Console.WriteLine("Tryck på valfri knapp för att gå tillbaka till menyn");
            Console.ReadKey();
        } 
        public static Account Transfer(List<Account>AccountList)
        {
            Console.WriteLine("Vilket konto vill du föra över pengar från?");
            string transferFromAccount = Console.ReadLine();
            Console.WriteLine("Vilket konto vill du föra över pengar till?");
            decimal transferToAccount = decimal.Parse(Console.ReadLine());

            var fromAccount = AccountList.Find(m => m.AccountName == transferFromAccount);
            var toAccount = AccountList.Find(t => t.Balance == transferToAccount);

            Console.WriteLine("Hur mycket vill du föra över?");
            decimal amountOfMoney = decimal.Parse(Console.ReadLine());

            fromAccount.Balance = fromAccount.Balance - amountOfMoney;
            return fromAccount;

            // hur returnerar jag toAccount??

        }

        public static void AccountHistory()
        {

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
