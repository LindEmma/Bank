using Bank.Classes;
using Bank.Console_output;
using Spectre.Console;

namespace Bank.Logic
{
    internal static class OpenAccount
    {
        // Method to open a Checkings account as a first account, this account contains the users salary
        // returns an account with balance= 10000 and accountName = "Betalkonto", or null. 
        public static BankAccount OpenCheckingsAccount(List<string> TransferHistory)
        {
            Console.WriteLine("Tryck på valfri knapp för att öppna ditt betalkonto!\n");
            Console.ReadKey();
            Console.WriteLine("Ditt betalkonto är öppnat!\nDu kan se det under fliken \"Visa dina konton\"");
            Menu.PressKey();

            string logg = $"Från: Lönekontoret\nTill: Betalkonto\nBelopp: 10000 SEK";
            TransferHistory.Add(logg);

            return new BankAccount(10000, "Betalkonto");
        }

        // method that lets the user create a new Account. Adds it to AccountList.
        public static BankAccount OpenSavingsAccount(List<BankAccount> AccountList)
        {
            string AccountName = "";

            //Handles the name of the account
            while (String.IsNullOrEmpty(AccountName) || AccountList.Exists(x => x.AccountName == AccountName))
            {
                Console.Write("Vad ska ditt sparkonto heta? ");
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

            Console.WriteLine("\nSparkontot har skapats!");
            Menu.PressKey();

            return new BankAccount(0, AccountName); //returns new Account
        }
        //Loops through the info for each account, if AccountList is empty there is a message
        public static void PrintAccountInfo(List<BankAccount> AccountList)
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
        public static void PrintAccountNames(List<BankAccount> accounts)
        {
            foreach (var accountName in accounts)
            {
                accountName.PrintAccountName();
            }
            Console.WriteLine();
        }
    }
}
