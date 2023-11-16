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
            DateTime dt = new DateTime();
            dt = DateTime.Now;

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
                    Console.WriteLine("Överföringen är lyckad!");

                    //Jobba in datetime??
                    TransferHistory.Add($"{fromAccount.AccountName} - {amountOfMoney}kr\n{toAccount.AccountName} + {amountOfMoney}kr\n{dt}");
                }
                Menu.PressKey();

                // var choice = AnsiConsole.Prompt(
                // new SelectionPrompt<string>().Title("\nVill du göra en ny överföring? j/n")
                //.PageSize(4)
                //.MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
                //.AddChoices(new[] {
                //"ja", "Återgå till menyn",
                // }));
                // if (choice == "Återgå till menyn")
                // {
                //     Run = false;
                // }
                // else
                // {
                //     Console.Clear();
                // }
                //Console.WriteLine("Vill du göra en ny överföring? j/n");
                //string answer = Console.ReadLine();
                //switch (answer)
                //{
                //    case "j":
                //    case "J":
                //        break;
                //    case "n":
                //    case "N":
                //        Run = false;
                //        break;
                //    default:
                //        Console.WriteLine("Vänligen välj j/n");
                //        break;
                //}
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
                }
            }
            Menu.PressKey();
        }
    }
}
}
