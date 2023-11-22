using Bank.Classes;
using Bank.Console_output;

namespace Bank.Logic
{
    internal static class CustomerMethods
    {

        // method that lets the user create a new Account. Adds it to AccountList.
        public static Account CreateAccount(List<Account> AccountList)
        {
            string AccountName = "";
            decimal Balance;

            //Handles the name of the account
            while (String.IsNullOrEmpty(AccountName) || AccountList.Exists(x => x.AccountName == AccountName))
            {
                Console.Write("Vad ska ditt konto heta? ");
                AccountName = Console.ReadLine();
                if (String.IsNullOrEmpty(AccountName))
                {
                    Console.WriteLine("Du måste mata in något\n");
                }
                else if (AccountList.Exists(x => x.AccountName == AccountName))
                {
                    Console.WriteLine("Kontonamnet finns redan, testa ett nytt namn\n");
                }
            }
            //Handles how much money the user wants to add to the account (no limit as of now)
            do
            {
                Console.Write("Hur mycket pengar vill du lägga in på kontot? (SEK) ");
                Balance = ParseMethods.ReadDecimal();
                if (Balance < 0)
                {
                    Menu.ClearTitle();
                    Console.WriteLine("Du kan inte lägga in negativa belopp på kontot, testa igen\n");
                }
            } while (Balance < 0);

            Console.WriteLine("\nKontot har skapats!");
            Menu.PressKey();
            return new Account(Balance, AccountName); //returns new Account

        }
        //Loops through the info for each account, if AccountList is empty there is a message
        public static void PrintAccountInfo(List<Account> AccountList)
        {
            if (AccountList.Count == 0)
            {
                Console.WriteLine("Det finns inga konton");
            }
            else
            {
                int NumberOfAccounts = AccountList.Count;
                Console.WriteLine($"Antal konton: {NumberOfAccounts}\n");

                foreach (var account in AccountList)
                {
                    account.PrintAccountInfo();
                }
            }
            Menu.PressKey();
        }

        // Shows the names only of accounts in AccountLists
        public static void PrintAccountNames(List<Account> accounts)
        {
            foreach (var accountName in accounts)
            {
                accountName.PrintAccountName();
            }
            Console.WriteLine();
        }
       

    }
}
