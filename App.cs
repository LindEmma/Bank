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
        private List<string> TransferHistory { get; set; }


        public App()
        {
            RunApp = true;
            AccountList = new List<Account>();
            TransferHistory = new List<string>();
        }

        public void QuitApp()
        {
            RunApp = false;
        }

        public void Run()
        {
            
            while (RunApp) // ==true
            {

                Console.Clear();
                Menu.PrintStartMenu();

                string startChoice = Console.ReadLine();
                Console.Clear();

                switch (startChoice)
                {
                    case "1":
                        //if (Login())
                        //{
                        //    usermeny();
                        //}
                        break;

                    case "2":
                        Console.WriteLine("Tack för idag");
                        QuitApp();
                        break;

                    default:
                        Console.WriteLine("Välj 1 eller 2");
                        break;
                }

                // Nedan är menyprogrammet när kunden är inloggad. 
                Console.Clear();
                Menu.PrintCustomerMenu();

                {
                    int customerChoice = ParseMethods.ReadInt();
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
                            CustomerMethods.PrintAccountInfo(AccountList);
                            break;

                        case 3:
                            Console.Clear();
                            Menu.MenuTitle();
                            //Överför pengar
                            Transfer transfer = new Transfer();
                            transfer.TransferOwnAccounts(AccountList,TransferHistory);
                            break;

                        case 4:
                            Console.Clear();
                            Menu.MenuTitle();
                            Transfer transferLogg = new Transfer();
                            transferLogg.TransferHistory(TransferHistory);
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
                            throw new InvalidOperationException("Vänligen välj 1-6");
                    }

                }
                
                // else if sats om user== admin
            }
        }
    }
}
