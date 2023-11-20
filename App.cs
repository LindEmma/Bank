using Bank.Classes;
using Bank.Console_output;
using Bank.Logic;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bank
{
    internal class App
    {
        public bool RunApp { get; set; }
        private List<Account> AccountList { get; set; }
        private List<string> TransferHistory { get; set; }
        private List<LoginUser> Users { get; set; }
        private LoginManager loginManager;
        private Transfer Transfer { get; set; }
        public bool Login { get; set; }

        public App()
        {
            RunApp = true;
            AccountList = new List<Account>();
            TransferHistory = new List<string>();
            Users = new List<LoginUser>
            {
                new LoginUser("Frida", "Vinter2023", isAdmin: true),
                new LoginUser("Tom", "Vinter2023"),
                new LoginUser("Emma", "Vinter2023"),
                new LoginUser("Gustav", "Vinter2023")
            };
            Transfer = new Transfer();
            Login = true;
            loginManager = new LoginManager(Users);
        }

        public void QuitApp()
        {
            RunApp = false;
        }
        public void LogOut()
        {
            Login = false;
        }
        public void Run()
        {
            while (RunApp) // ==true
            {
                Console.Clear();

                Menu.PrintStartMenu();
                string startChoice = Console.ReadLine();
                Console.Clear();
                Menu.MenuTitle();

                switch (startChoice)
                {
                    case "1":
                        LoginManager.UserType userType = loginManager.HandleLogin();
                        Console.Clear();

                        switch (userType)
                        {
                            case LoginManager.UserType.Admin:

                                while (Login)
                                {
                                    Console.Clear();
                                    Menu.PrintAdminMenu();
                                    int adminChoice = ParseMethods.ReadInt();
                                    Console.Clear();
                                    switch (adminChoice)
                                    {
                                        case 1:
                                            var newUserAccount = AdminMethods.CreateUser();
                                            Users.Add(newUserAccount);
                                            Login = true;
                                            break;

                                        case 2:
                                            Console.WriteLine("Tack för idag!");
                                            LogOut();
                                            break;
                                    }                                    
                                }
                                break;

                            case LoginManager.UserType.Regular:
                                
                                while (Login)
                                {
                                    Console.Clear();
                                    Menu.PrintCustomerMenu();
                                    int customerChoice = ParseMethods.ReadInt();
                                    Console.Clear();
                                    Menu.MenuTitle();
                                    switch (customerChoice)
                                    {
                                        case 1:
                                            //skapar ett konto
                                            var newAccount = CustomerMethods.CreateAccount();
                                            AccountList.Add(newAccount);
                                            break;

                                        case 2:                                          
                                            //Visar användarens konton
                                            CustomerMethods.PrintAccountInfo(AccountList);
                                            break;

                                        case 3:                                            
                                            //Överför pengar                                           
                                            Transfer.TransferOwnAccounts(AccountList, TransferHistory);
                                            break;

                                        case 4                                           
                                            Transfer.TransferHistory(TransferHistory);
                                            //visa kontohistorik
                                            break;

                                         case 5:
                                            Console.Clear();
                                            Menu.MenuTitle();
                                            CustomerMethods.TakeLoanToAccount(AccountList);
                                            //Ta ett lån
                                            break;
                                        
                                          case 6:
                                           Console.Clear();
                                           CustomerMethods.PrintLoan(AccountList);
                                           Menu.MenuTitle();
                                           break;

                                          case 7:
                                           LogOut();
                                           Console.WriteLine("Tryck valfri knapp för att logga ut!");
                                           break;
                                    }
                                }

                                break;

                            case LoginManager.UserType.None:
                                Console.WriteLine("För många felaktiga login försök.");
                                Environment.Exit(0);
                                //QuitApp(); ??
                                break;
                        }
                        break;

                    case "2":
                        Console.WriteLine("Tack för idag");
                        QuitApp();
                        break;

                        //titta på
                    default:
                        Console.WriteLine("Välj 1 eller 2");
                        break;
                }
            }
        }
    }
}

