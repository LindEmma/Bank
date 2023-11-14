using Bank.Classes;
using Bank.Console_output;
using Bank.Logic;
using System.Linq.Expressions;

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
                // metod för att logga in??
                // Nedan är menyprogrammet när kunden är inloggad. 
                Console.Clear();
                Menu.PrintCustomerMenu();
                try
                {
                    int customerChoice = Convert.ToInt32(Console.ReadLine());
                    switch (customerChoice)
                    {
                        case 1:
                            //skapar ett konto
                            Console.Clear ();
                            Menu.MenuTitle();
                            var newAccount = CustomerMethods.CreateAccount();
                            AccountList.Add(newAccount);
                            break;

                        case 2:
                            Console.Clear();
                            Menu.MenuTitle();
                            //Visar användarens konton
                            CustomerMethods.ShowBalance(AccountList);
                            break;

                        case 3:
                            Console.Clear();
                            Menu.MenuTitle();
                            //Överför pengar
                            Transfer.TransferFromAccount(AccountList);
                            break;

                        case 4:
                            Console.Clear();
                            Menu.MenuTitle();
                            //visa kontohistorik
                            break;

                        case 5:
                            Console.Clear();
                            Menu.MenuTitle();
                            //Ta ett lån
                            break;
                        case 6:
                            Console.Clear();
                            Menu.MenuTitle();
                            Console.WriteLine("Tack för idag!");
                            QuitApp();
                            break;

                        default:
                            throw new InvalidOperationException("Invalid choice. Please choose 1-6.");
                        
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error!");

                }
                // else if sats om user== admin
            }
        }
    }
}
