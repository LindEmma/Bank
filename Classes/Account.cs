namespace Bank.Classes
{
    public class Account
    {
        private decimal balance;
        public string AccountName { get; set; }
        public List<Loan> Loans { get; set; } = new List<Loan>();
        public decimal Balance
        {
            get
            { return balance; }
            set
            {
                if (balance < 0)
                    balance = 0;
                balance = value;
            }
        }

        public Account(decimal balance, string accountName)
        {
            Balance = balance;
            AccountName = accountName;
        }

        // method that prints the accounts info (balance and account name)
        public void PrintAccountInfo()
        {
            Console.WriteLine($"Kontonamn: {AccountName}\nSaldo: {Balance} SEK\n");
        }

        // prints only the name of the account
        public void PrintAccountName()
        {
            Console.WriteLine("*" + AccountName);
        }
        public bool HasLoans()
        {
            return Loans.Any();
        }
    }
    public class Loan
    {
        public decimal Amount { get; set; }
        public string Purpose { get; set; }
        public int DurationMonths { get; set; }

    }
}
