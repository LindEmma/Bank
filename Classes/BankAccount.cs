namespace Bank.Classes
{
    public class BankAccount
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

        public BankAccount(decimal balance, string accountName)
        {
            Balance = balance;
            AccountName = accountName;
        }

        // method that prints the accounts info (balance and account name)
        public virtual void PrintAccountInfo()
        {
            Console.WriteLine($"Kontonamn: {AccountName}\nSaldo: {Balance} SEK\n");
        }

        // prints only the name of the account
        public virtual void PrintAccountName()
        {
            Console.WriteLine("*" + AccountName);
        }
        public bool HasLoans()
        {
            return Loans.Any();
        }
    }
}
