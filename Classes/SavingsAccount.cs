using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Classes
{
    public class SavingsAccount: BankAccount
    {
        public decimal Interest { get; set; }
        public SavingsAccount(decimal balance, string accountName): base (balance, accountName)
        {
            Interest = 0.03m;
        }
        public override void PrintAccountInfo()
        {
            Console.WriteLine($"Kontonamn: {AccountName}\nSaldo: {Balance} SEK\n");
        }

        public override void PrintAccountName()
        {
            base.PrintAccountName();
        }

        public void ShowInterest()
        {
            Console.WriteLine($"Din månadsränta är {Balance}*{Interest}");
        }
    }
}
