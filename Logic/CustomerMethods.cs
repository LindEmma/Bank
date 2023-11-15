using Bank.Classes;

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
        public static void PrintAccountInfo(List<Account> AccountList)
        {
            if (AccountList.Count == 0)
            {
                Console.WriteLine("Det finns inga konton");
            }
            else
            {
                foreach (var account in AccountList)
                {
                    int NumberOfAccounts = AccountList.Count;
                    Console.WriteLine($"Antal konton: {NumberOfAccounts}\n");
                    account.PrintAccountInfo();
                }
            }
            Console.WriteLine("Tryck på valfri knapp för att gå tillbaka till menyn");
            Console.ReadKey();
        }
        
        // Shows the names only of accounts in AccountLists
        public static void PrintAccountNames(List<Account> accounts)
        {
            foreach (var accountName in accounts)
            {
                accountName.PrintAccountName();
            }
        }

    }
}
