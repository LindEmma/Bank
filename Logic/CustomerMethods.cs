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
        // method that lets user create a new Account (object). Adds it to AccountList.
        public static Account CreateAccount()
        {
            Console.Write("vad ska ditt konto heta? ");
            string AccountName = Console.ReadLine();
            Console.Write("Hur mycket pengar vill du lägga in på kontot? ");
            decimal Balance = ParseMethods.ReadDecimal();
            Console.WriteLine("Kontot har skapats!");
            Console.WriteLine("\nTryck på valfri knapp för att fortsätta.");
            Console.ReadKey();
            return new Account(Balance, AccountName);
        }

        //Loops through the info for each account, if AccountList is empty there is a message
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
       

        // shows history of bank transfers
        public static void AccountHistory()
        {

        }
        // Shows the names only of accounts in AccountLists
        public static void AccountNameList(List<Account> accounts)
        {
            foreach (var accountName in accounts)
            {
                accountName.PrintAccountName();
            }
        }

    }
}
