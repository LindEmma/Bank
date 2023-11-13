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


        public Account CreateAccount(List<Account> accounts)
        {
            Console.Write("vad ska ditt konto heta?");
            string AccountName = Console.ReadLine();
            Console.Write("Hur mycket pengar vill du lägga in på kontot?");
            decimal Balance = decimal.Parse(Console.ReadLine());
            return new Account();
        }

        public void Transfer()
        {
            Console.WriteLine("Vilket konto vill du föra över pengar från?");
            
            string transferFromAccount = Console.ReadLine();
            Console.WriteLine("Vilket konto vill du föra över pengar till?");

        }

        public void ShowBalance(List<Account> accounts)
        {
            foreach (var account in accounts)
            {
                Console.WriteLine($"Kontonamn: {AccountName}\nSaldo: {Balance}");
            }
        }
        public void AccountNameList(List<Account>accounts)
        {
            foreach (var accountName in accounts)
            {
                Console.WriteLine($"{AccountName}");
            }
        }
    }
}
