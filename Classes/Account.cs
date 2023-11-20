using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Classes
{
    public class Account
    {
        public decimal Balance { get; set; }
        public string AccountName { get; set; }
        public List<Loan> Loans { get; set; } = new List<Loan>();


        public Account(decimal balance, string accountName)
        {
            Balance = balance;
            AccountName = accountName;
        }

        // method that prints the accounts info (balance and account name)
        public void PrintAccountInfo()
        {
            Console.WriteLine($"Kontonamn: {AccountName}\nSaldo: {Balance}\n");
        }

        // prints only the name of the account
        public void PrintAccountName()
        {
            Console.WriteLine(AccountName);
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
