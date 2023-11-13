using Bank.Classes;
using Bank.Console_output;
using Bank.Logic;

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
                        //skapar ett konto
                        var newAccount=CustomerMethods.CreateAccount();
                        AccountList.Add(newAccount);
                        break;

                    case "2":
                        //Visar användarens konton
                        CustomerMethods.ShowBalance(AccountList);
                        break;

                    case "3":
                        //Överför pengar
                        CustomerMethods.Transfer(AccountList);
                        break;

                    case "4":

                        //visa kontohistorik
                        break;

                    case "5":
                        //Ta ett lån
                        break;
                    case "6":
                        Console.WriteLine("Tack för idag");
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
