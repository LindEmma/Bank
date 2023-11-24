using Bank.Classes;
using Bank.Console_output;
using Spectre.Console;

namespace Bank.Logic
{
    internal static class OpenAccount
    {
        // Method to open a Checkings account as a first account, this account contains the users salary
        // returns an account with balance= 35000 and accountName = "Betalkonto". 
        public static BankAccount OpenCheckingsAccount(List<string> TransferHistory)
        {
            DateTime dateTime = DateTime.Now;
            var date = dateTime.ToString("yyyy,MM,dd,HH,mm");
            Console.WriteLine("Tryck på valfri knapp för att öppna ditt betalkonto!\n");
            Console.ReadKey();
            AnsiConsole.MarkupLine("[green]Ditt betalkonto är öppnat![/]\nDu kan se det under fliken \"Visa dina konton\"");
            Menu.PressKey();

            string logg = $"{date}\nFrån: Lönekontoret\nTill: Betalkonto\nBelopp: 35000 SEK";
            TransferHistory.Add(logg);
            string accountName = "Betalkonto";
            return new BankAccount(35000m, accountName);
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

            AnsiConsole.MarkupLine("\n[green]Sparkontot har skapats![/]");
            Menu.PressKey();

            return new BankAccount(0, AccountName); //returns new Account
        }
        //Loops through the info for each account, if AccountList is empty there is a message
        public static void PrintAccountInfo(List<BankAccount> AccountList)
        {
            var table = new Table();
            var table2 = new Table();

            if (AccountList.Count == 0)
            {
                Console.WriteLine("Det finns inga konton");
            }
            else
            {
                int NumberOfAccounts = AccountList.Count;
                AnsiConsole.MarkupLine($"[blue]Antal konton: {NumberOfAccounts}[/]\n");
                var checkingsAccount = AccountList.Find(x => x.AccountName == "Betalkonto");
                //Console.WriteLine("Betalkonton:\n");
                table.AddColumn("Betalkonton");
                AnsiConsole.Write(table);


                checkingsAccount.PrintAccountInfo();
                //Console.WriteLine("------------------------\n");
                AccountList.Remove(checkingsAccount);
                //Console.WriteLine("Sparkonton (ränta 3%):\n");

                table2.AddColumn("Sparkonton");
                AnsiConsole.Write(table2);

                if (AccountList.Count == 0)
                {
                    Console.WriteLine("Det finns inga sparkonton");
                }
                else
                {
                    foreach (var account in AccountList)
                    {
                        account.PrintAccountInfo();
                        Console.WriteLine($"Aktuell årsränta: " + account.CalculateInterest());
                    }
                }
                AccountList.Add(checkingsAccount);
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
