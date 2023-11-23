using Bank.Classes;
using Bank.Console_output;
using Bank.Logic;

namespace Bank
{
    internal class App
    {
        public bool RunApp { get; set; }
        public List<BankAccount> AccountList { get; set; }
        public List<string> TransferHistory { get; set; }
        public List<LoginUser> Users { get; set; }
        public LoginManager LoginManager;
        public Transfer Transfer { get; set; }
        public bool Login { get; set; }

        public App()
        {
            RunApp = true;
            AccountList = new List<BankAccount>();
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
            LoginManager = new LoginManager(Users);
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
            while (RunApp)
            {
                // start menu - with choice to log in or exit program
                Console.Clear();
                Menu.PrintStartMenu();
                int startChoice = ParseMethods.ReadInt();
                Console.Clear();
                Menu.MenuTitle();

                switch (startChoice)
                {
                    case 1:
                        Login = true;
                        LoginManager.UserType userType = LoginManager.HandleLogin();
                        Console.Clear();
                        
                        switch (userType)
                        {
                            case LoginManager.UserType.Admin:

                                //logged in as admin
                                while (Login)
                                {
                                    Console.Clear();
                                    Menu.PrintAdminMenu();
                                    int adminChoice = ParseMethods.ReadInt();
                                    Console.Clear();
                                    Menu.MenuTitle();
                                    switch (adminChoice)
                                    {
                                        case 1:
                                            // lets admin create new customer user account
                                            var newUserAccount = AdminMethods.CreateUser();
                                            Users.Add(newUserAccount);
                                            break;

                                        case 2:
                                            // log out to start menu
                                            Console.WriteLine("Tack för idag!");
                                            LogOut();
                                            break;
                                    }                                    
                                }
                                break;

                            case LoginManager.UserType.Regular:
                                
                                //logged in as customer
                                while (Login)
                                { 
                                    Console.Clear();
                                    if (AccountList.Count == 0) { Menu.PrintCustomerMenuNoAccounts(); }
                                    else { Menu.PrintCustomerMenu(); }
                                    int customerChoice = ParseMethods.ReadInt();
                                    Console.Clear();
                                    Menu.MenuTitle();
                                    switch (customerChoice)
                                    {
                                        case 1: //Opens a CheckingsAccount as a first account
                                            if (AccountList.Count == 0)
                                            {
                                                var newCheckingsAccount = OpenAccount.OpenCheckingsAccount(TransferHistory);
                                                AccountList.Add(newCheckingsAccount);
                                            }
                                            else
                                            {
                                                //Opens new savings account
                                                var newSavingsAccount = OpenAccount.OpenSavingsAccount(AccountList);
                                                AccountList.Add(newSavingsAccount);
                                            }
                                            break;

                                        case 2:                        
                                            //Shows info of all bank accounts
                                            OpenAccount.PrintAccountInfo(AccountList);
                                            break;
                                        case 3:                   
                                            // method to transfer currency between users own accounts
                                            Transfer.TransferOwnAccounts(AccountList, TransferHistory);
                                            break;

                                        case 4:                                          
                                            // shows transfer history
                                            Transfer.TransferHistory(TransferHistory);
                                            break;

                                         case 5:
                                            // lets user take a bank loan
                                            TakeLoan.TakeLoanToAccount(AccountList);
                                            break;
                                        
                                          case 6:               
                                           // shows current loans                         
                                           TakeLoan.PrintLoan(AccountList);
                                           break;

                                          case 7:
                                            //log out to start menu
                                           LogOut();
                                           Console.WriteLine("Tryck valfri knapp för att logga ut!");
                                           break;
                                        
                                        default:
                                            Console.WriteLine("Vänligen välj 1-7");
                                            break;
                                    }
                                }
                                break;

                                // if user failed to login 3 times, program shuts down
                            case LoginManager.UserType.None:
                                Console.WriteLine("För många felaktiga login försök.");
                                Environment.Exit(0);
                                break;
                        }
                        break;

                    case 2:
                        // "closes" program
                        Console.WriteLine("Tack för idag");
                        QuitApp();
                        break;

                    default:
                        Console.WriteLine("Välj 1 eller 2");
                        break;
                }
            }
        }
    }
}

