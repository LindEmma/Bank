using Bank.Classes;

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
        public void TransferOwnAccounts(List<Account> AccountList, List<string>TransferHistory)
        {
            while (Run)
            {
                //If there is 0-1 accounts, a transfer cannot be made
                if (AccountList.Count == 0||AccountList.Count==1)
                {
                    Console.WriteLine("Du måste skapa minst två konton för att kunna göra en överföring");
                    Console.WriteLine("\nTryck på valfri knapp för att gå tillbaka till menyn");
                    Console.ReadKey();
                    Run = false;
                }
                else
                {
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
                        Console.WriteLine("Överföringen är lyckad!");
                        TransferHistory.Add($"{fromAccount.AccountName} - {amountOfMoney}kr\n{toAccount.AccountName} + {amountOfMoney}kr");
                    }
                    Console.WriteLine("Vill du göra en ny överföring? j/n");
                    string answer = Console.ReadLine();
                    switch (answer)
                    {
                        case "j":
                        case "J":
                            break;
                        case "n":
                        case "N":
                            Run = false;
                            break;
                        default:
                            Console.WriteLine("Vänligen välj j/n");
                            break;

                    }
                }
            }
        }
        // shows history of bank transfers
        public void TransferHistory(List<string>TransferHistory)
        {
            if (TransferHistory.Count == 0)
            {
                Console.WriteLine("Det finns ingen historik att visa\nTryc på valfri knapp för att återgå till  menyn");
            }
            else
            {
                foreach (string logg in TransferHistory)
                {
                    Console.WriteLine(logg);
                    Console.WriteLine("\nTryck på valfri knapp för att gå tillbaka till menyn");
                }
            }
            Console.ReadKey();
        }
    }
}
