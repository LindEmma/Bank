using Bank.Classes;
using Bank.Console_output;
using Spectre.Console;

namespace Bank
{
    internal class App
    {
        public bool RunApp { get; set; }
        private List<Account> AccountList { get; set; }

        public App()
        {
            RunApp = true;
            AccountList = new List<Account>();
        }

        public void QuitApp()
        {
            RunApp = false;
        }

        public void Run()
        {
            while (RunApp) // ==true
            {
                //Console.Clear();
                //Menu.PrintStartMenu();

                // metod för att logga in

                Console.Clear();
                Menu.PrintCustomerMenu();

                string customerChoice = Console.ReadLine();
                Console.Clear();
                switch (customerChoice)
                {
                    case "1":
                        Account acc = new Account();
                        acc.CreateAccount();
                        //Skapa ett konto
                        break;

                    case "2":
                        acc.Transfer();
                        break;

                    case "3":
                        //Överför pengar
                        break;

                    case "4":

                        //visa kontohistorik
                        break;

                    case "5":
                        //Ta ett lån
                        break;
                    case "6":
                        QuitApp();
                        break;
                    default:
                        Console.WriteLine("Välj 1-6");
                        break;
                }
            }
        }

    }
}
