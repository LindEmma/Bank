using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Classes
{
    public class EuroAccount:BankAccount
    {
        public bool EuroCurrency { get; set; }
        public EuroAccount(decimal balance, string accountName) :base(balance, accountName)
        {
            Balance = balance;
            AccountName = accountName;
            EuroCurrency = true;
        }

        public override void PrintAccountInfo()
        {
            base.PrintAccountInfo();
        }
        public override void PrintAccountName()
        {
            base.PrintAccountName();
        }
    }
}
