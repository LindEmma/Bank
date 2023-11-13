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

        public Account(decimal balance, string accountName)
        {
            Balance = balance;
            AccountName = accountName;
        }

        public void PrintAccountInfo()
        {
            Console.WriteLine($"Kontonamn: {AccountName}\nSaldo: {Balance}\n" +
                $"-------------------------");
        }
        public void PrintAccountName()
        {
            Console.WriteLine(AccountName);
        }
    }
}
