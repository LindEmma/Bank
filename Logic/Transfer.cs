﻿using Bank.Classes;
using Bank.Console_output;

namespace Bank.Logic
{
    internal class Transfer
    {
        public string transferToAccount { get; set; }
        public string transferFromAccount { get; set; }
        public decimal amountOfMoney { get; set; }

        public Transfer()
        {
            transferFromAccount = "";
            transferToAccount = "";
            amountOfMoney = 0;
        }
        // Method to transfer money between users own accounts
        public void TransferOwnAccounts(List<BankAccount> AccountList, List<string> TransferHistory)
        {
            DateTime date = DateTime.Now;
            var shortDate = date.ToString("yyyy-MM-dd HH:mm");

            //If there is 0-1 accounts, a transfer cannot be made
            if (AccountList.Count == 0 || AccountList.Count == 1)
            {
                Console.WriteLine("Du måste skapa minst två konton för att kunna göra en överföring");
            }
            else
            {
                // asks from which bank account a transfer is to be made. Needs to be a valid account from the provided list.
                do
                {
                    Console.WriteLine("Vilket konto vill du föra över pengar från? ");
                    OpenAccount.PrintAccountNames(AccountList);
                    transferFromAccount = Console.ReadLine();
                    Menu.ClearTitle();

                    if (String.IsNullOrEmpty(transferFromAccount) || !AccountList.Exists(x => x.AccountName == transferFromAccount))
                    {
                        Console.WriteLine("\nVälj ett konto i listan\n");
                    }
                }

                while (String.IsNullOrEmpty(transferFromAccount) || !AccountList.Exists(x => x.AccountName == transferFromAccount));

                //Finds the account name and removes it from the list
                var fromAccount = AccountList.Find(f => f.AccountName == transferFromAccount);

                if (fromAccount.Balance == 0)
                {
                    Console.WriteLine("Det finns inga pengar att överföra");
                    Menu.PressKey();
                }
                else
                {
                    AccountList.Remove(fromAccount);

                    // asks to which bank account a transfer will be made. Needs to be a valid account from the list
                    do
                    {
                        Console.WriteLine("Vilket konto vill du föra över pengar till? ");

                        OpenAccount.PrintAccountNames(AccountList);
                        transferToAccount = Console.ReadLine();
                        Menu.ClearTitle();

                        if (String.IsNullOrEmpty(transferFromAccount) || !AccountList.Exists(x => x.AccountName == transferToAccount))
                        {
                            Console.WriteLine("\nVälj ett konto i listan\n");
                        }
                    }
                    while (String.IsNullOrEmpty(transferFromAccount) || !AccountList.Exists(x => x.AccountName == transferToAccount));

                    //adds the account back to the list
                    AccountList.Add(fromAccount);
                    var toAccount = AccountList.Find(t => t.AccountName == transferToAccount);

                    //asks how much money the user wants to transfer
                    //cannot be a negative number or more money than exists in the bank account
                    do
                    {
                        Console.WriteLine($"Hur mycket vill du föra över? (max {fromAccount.Balance} SEK)");
                        amountOfMoney = ParseMethods.ReadDecimal();

                        if (amountOfMoney > fromAccount.Balance)
                        {
                            Console.WriteLine("Du kan inte överföra mer pengar än vad som finns på kontot, försök igen!\n");
                        }
                        else if (amountOfMoney < 0)
                        {
                            Console.WriteLine("Du kan inte överföra negativa belopp, försök igen!\n");
                        }

                    }
                    while (amountOfMoney > fromAccount.Balance || amountOfMoney < 0);

                        // subtracts money from fromAccount and adds it to toAccount
                        fromAccount.Balance = fromAccount.Balance - amountOfMoney;
                        toAccount.Balance = toAccount.Balance + amountOfMoney;
                        Console.Clear();

                        // makes a logg of transfer info, date and time
                        // prints a receipt
                        Console.WriteLine("Öveföringen godkänd!\n");
                        string logg = $"{shortDate}\nFrån: {fromAccount.AccountName}\nTill: {toAccount.AccountName}\nBelopp: -{amountOfMoney} SEK";
                        Console.WriteLine($"Kvittens\nÖverföring {logg}");

                        if (fromAccount.AccountName != "Betalkonto")
                        {
                            Console.WriteLine($"Ny årsränta för {fromAccount.AccountName}: {fromAccount.Balance * 0,03}");
                        }
                        if (toAccount.AccountName != "Betalkonto")
                        {
                            Console.WriteLine($"Ny årsränta för {toAccount.AccountName}: {toAccount.Balance * 0,03}");
                        }

                        //adds the logg to TransferHistory list
                        TransferHistory.Add(logg);
                    }
                }
            Menu.PressKey();
        }

        // shows history of bank transfers
        public void TransferHistory(List<string> TransferHistory)
        {
            if (TransferHistory.Count == 0)
            {
                Console.WriteLine("Det finns ingen historik att visa");
            }
            else
            {
                foreach (string logg in TransferHistory)
                {
                    Console.WriteLine(logg);
                    Console.WriteLine("------------------\n");
                }
            }
            Menu.PressKey();
        }
    }
}





