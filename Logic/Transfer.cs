using Bank.Classes;
using Bank.Console_output;

namespace Bank.Logic
{
    internal class Transfer
    {
        public bool Run { get; set; }

        public Transfer()
        {
            Run = true;
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
                //Run = false;
            }
            else
            {
                //felhantera, så att anv måste skriva någonting
                Console.WriteLine("Vilket konto vill du föra över pengar från?");
                CustomerMethods.PrintAccountNames(AccountList);
                string transferFromAccount = Console.ReadLine();
                var fromAccount = AccountList.Find(m => m.AccountName == transferFromAccount);

                Console.WriteLine("Vilket konto vill du föra över pengar till?");
                AccountList.Remove(fromAccount);
                CustomerMethods.PrintAccountNames(AccountList);
                string transferToAccount = Console.ReadLine();
                AccountList.Add(fromAccount);

                var toAccount = AccountList.Find(t => t.AccountName == transferToAccount);

                Console.WriteLine("Hur mycket vill du föra över?");
                decimal amountOfMoney = ParseMethods.ReadDecimal();

                if (amountOfMoney > fromAccount.Balance)
                {
                    Console.WriteLine("Du kan inte låna mer pengar än vad som finns på kontot");
                }
                else
                {
                    fromAccount.Balance = fromAccount.Balance - amountOfMoney;
                    toAccount.Balance = toAccount.Balance + amountOfMoney;
                    Console.Clear();
                    Console.WriteLine("Öveföringen godkänd!\n");
                    string logg = $"{shortDate}\nFrån: {fromAccount.AccountName}\nTill {toAccount.AccountName}\nBelopp: -{amountOfMoney}";
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

