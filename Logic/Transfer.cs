using Bank.Classes;
using Bank.Console_output;

namespace Bank.Logic
{
    internal class Transfer
    {
        public string transferToAccount { get; set; }
        public string transferFromAccount { get; set; }

        public Transfer()
        {
            transferFromAccount = "";
            transferToAccount = "";
        }
        // Method to transfer money between users own accounts
        public void TransferOwnAccounts(List<Account> AccountList, List<string> TransferHistory)
        {
            DateTime date = DateTime.Now;
            var shortDate = date.ToString("yyyy-MM-dd HH:mm");

            //If there is 0-1 accounts, a transfer cannot be made
            if (AccountList.Count == 0 || AccountList.Count == 1)
            {
                Console.WriteLine("Du måste skapa minst två konton för att kunna göra en överföring");
                Menu.PressKey();
            }
            else
            {

                //var fromAccount = AccountList.Find(m => m.AccountName == transferFromAccount);
                do
                {
                    Console.WriteLine("Vilket konto vill du föra över pengar från? ");
                    CustomerMethods.PrintAccountNames(AccountList);
                    transferFromAccount = Console.ReadLine();
                    Menu.ClearTitle();

                    if (String.IsNullOrEmpty(transferFromAccount) || !AccountList.Exists(x => x.AccountName == transferFromAccount))
                    {
                        Console.WriteLine("\nVälj ett konto i listan\n");
                    }
                }

                while (String.IsNullOrEmpty(transferFromAccount) || !AccountList.Exists(x => x.AccountName == transferFromAccount));

                var fromAccount = AccountList.Find(f => f.AccountName == transferFromAccount);

                do
                {
                    Console.WriteLine("Vilket konto vill du föra över pengar till? ");
                    AccountList.Remove(fromAccount);
                    CustomerMethods.PrintAccountNames(AccountList);
                    transferToAccount = Console.ReadLine();
                    Menu.ClearTitle();

                    if (String.IsNullOrEmpty(transferFromAccount) || !AccountList.Exists(x => x.AccountName == transferToAccount))
                    {
                        Console.WriteLine("\nVälj ett konto i listan\n");
                    }
                }
                while (String.IsNullOrEmpty(transferFromAccount) || !AccountList.Exists(x => x.AccountName == transferToAccount));

                AccountList.Add(fromAccount);

                var toAccount = AccountList.Find(t => t.AccountName == transferToAccount);

                Console.WriteLine("Hur mycket vill du föra över? (i SEK) ");
                decimal amountOfMoney = ParseMethods.ReadDecimal();

                if (amountOfMoney > fromAccount.Balance)
                {
                    Console.WriteLine("Du kan inte överföra mer pengar än vad som finns på kontot");
                }
                else
                {
                    fromAccount.Balance = fromAccount.Balance - amountOfMoney;
                    toAccount.Balance = toAccount.Balance + amountOfMoney;
                    Console.Clear();
                    Console.WriteLine("Öveföringen godkänd!\n");
                    string logg = $"{shortDate}\nFrån: {fromAccount.AccountName}\nTill {toAccount.AccountName}\nBelopp: -{amountOfMoney} SEK";
                    Console.WriteLine($"Kvittens\nÖverföring {logg}");

                    TransferHistory.Add(logg);
                }
                Menu.PressKey();
            }
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





