using Bank.Classes;

namespace Bank.Logic
{
    internal class Transfer
    {
        //public decimal AmountOfMoney { get; set; }

        //public Transfer(decimal amountOfMoney)
        //{
        //    AmountOfMoney = amountOfMoney;
        //}

        // Method to transfer money between users own accounts
        public static void TransferFromAccount(List<Account> AccountList)
        {
            Console.WriteLine("Vilket konto vill du föra över pengar från?");
            CustomerMethods.AccountNameList(AccountList);
            string transferFromAccount = Console.ReadLine();
            var fromAccount = AccountList.Find(m => m.AccountName == transferFromAccount);

            // rätt verkligen?
            Console.WriteLine("Vilket konto vill du föra över pengar till?");
            AccountList.Remove(fromAccount);
            CustomerMethods.AccountNameList(AccountList);
            string transferToAccount = Console.ReadLine();
            AccountList.Add(fromAccount);

            var toAccount = AccountList.Find(t => t.AccountName == transferToAccount);

            Console.WriteLine("Hur mycket vill du föra över?");
            decimal amountOfMoney = ParseMethods.ReadDecimal();

            if (amountOfMoney > fromAccount.Balance)
            {
                Console.WriteLine("Du kan inte låna mer pengar än vad som finns på kontot");
                Console.ReadKey();
            }
            else
            {
                fromAccount.Balance = fromAccount.Balance - amountOfMoney;
                toAccount.Balance = toAccount.Balance + amountOfMoney;
            }
        }
    }
}
