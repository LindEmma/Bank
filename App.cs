using Bank.Classes;
using Bank.Console_output;
using Bank.Logic;

namespace Bank
{
    internal class App
    {
        public bool RunApp { get; set; }
        private List<Account> AccountList { get; set; }
        private List<string> TransferHistory { get; set; }
        private LoginManager loginManager;
        private LoginHandler loginHandler;
        private Transfer Transfer { get; set; }
        public bool Login { get; set; }

        public App()
        {
            RunApp = true;
            AccountList = new List<Account>();
            TransferHistory = new List<string>();
            loginManager = new LoginManager();
            loginHandler = new LoginHandler();
            Transfer = new Transfer();
            Login = true;
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
                        LoginHandler.UserType userType = loginHandler.HandleLogin(loginManager);
                        Console.Clear();

                        switch (userType)
                        {
                            case LoginHandler.UserType.Admin:

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
                                            _users.Add(newUserAccount);
                                                break;

                                        case 2:
                                            Console.WriteLine("Tack för idag!");
                                            LogOut();
                                                break;
                                    }
                                    
                                }

                                break;

                            case LoginHandler.UserType.Regular:
                                
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

                                        case 4:
                                           
                                            Transfer.TransferHistory(TransferHistory);
                                            //visa kontohistorik
                                            break;

                                        case 5:
                                            
                                            //Ta ett lån
                                            break;
                                        case 6:
                                            Console.WriteLine("Tack för idag!");
                                            LogOut();
                                            break;

                                        default:
                                            throw new InvalidOperationException("Vänligen välj 1-6");
                                    }
                                }

                                break;

                            case LoginHandler.UserType.None:
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

