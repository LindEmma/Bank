using Spectre.Console;
namespace Bank.Classes
{
    public class BankAccount
    {
        public string AccountName { get; set; }
        public List<Loan> Loans { get; set; } = new List<Loan>();
        public decimal Interest { get; set; }
        public decimal Balance { get; set; }

        public BankAccount(decimal balance, string accountName)
        {
            Balance = balance;
            AccountName = accountName;
            Interest = 0.03m;
        }

        // method that prints the accounts info (balance and account name)
        public void PrintAccountInfo()
        {
            Console.WriteLine($"\nKontonamn: {AccountName}\nSaldo: {Balance} SEK");
        }

        // prints only the name of the account
        public void PrintAccountName()
        {
            Console.WriteLine("*" + AccountName);
        }
        public decimal CalculateInterest()
        {
            return Balance * Interest;
        }
        public bool HasLoans()
        {
            return Loans.Any();
        }
    }
}
