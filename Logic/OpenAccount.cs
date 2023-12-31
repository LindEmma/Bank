﻿using Bank.Classes;
using Bank.Console_output;
using Spectre.Console;

namespace Bank.Logic
{
    internal static class OpenAccount
    {
        // Method to open a Checkings account as a first account, this account contains the users salary
        // returns an account with balance= 35000 and accountName = "Betalkonto" 
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
         
            return new BankAccount(35000m, "Betalkonto");
        }

        // method that lets the user create a new Account. Adds it to AccountList
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

        // Method that loops through the info for each account, if AccountList is empty there is a message
        public static void PrintAccountInfo(List<BankAccount> AccountList)
        {
            var table = new Table();
            var table2 = new Table();

            // if AccountList is empty, a message says so
            if (AccountList.Count == 0)
            {
                Console.WriteLine("Det finns inga konton");
            }
            else
            {
                //shows how many accounts is in Accountlist
                AnsiConsole.MarkupLine($"[blue]Antal konton: {AccountList.Count}[/]\n");
                var checkingsAccount = AccountList.Find(x => x.AccountName == "Betalkonto");

                //adds decorative column for checkings account using spectre console
                table.AddColumn("Betalkonton");
                AnsiConsole.Write(table);

                //shows info of checkings account
                checkingsAccount.PrintAccountInfo();
                AccountList.Remove(checkingsAccount);

                table2.AddColumn("Sparkonton");
                Console.WriteLine();
                AnsiConsole.Write(table2);

                //loops through info of each savings account including interest, if there are any in AccountList
                if (AccountList.Count == 0)
                {
                    Console.WriteLine("Det finns inga sparkonton");
                }
                else
                {
                    foreach (var account in AccountList)
                    {
                        account.PrintAccountInfo();
                        Console.WriteLine($"|Aktuell årsränta (3%): " + account.CalculateInterest()+" SEK\n");
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
