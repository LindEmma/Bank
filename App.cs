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
            while (RunApp)
            {
                Console.Clear();

                Menu.PrintStartMenu();
                int startChoice = ParseMethods.ReadInt();
                Console.Clear();
                Menu.MenuTitle();

                switch (startChoice) //if else ist??
                {
                    case 1:
                        Login = true;
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
                                    Menu.MenuTitle();
                                    switch (adminChoice)
                                    {
                                        case 1:
                                            var newUserAccount = AdminMethods.CreateUser(); //Skapar användare, men användaren är "samma" med samma bankkonton oavsett vem som loggar in
                                            Users.Add(newUserAccount);
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
                                            var newAccount = CustomerMethods.CreateAccount(AccountList);
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
                                            CustomerMethods.TakeLoanToAccount(AccountList); //Lånen blir max 5 ggr det som finns på kontot inkl lån = anv kan låna hur mycket som helst i hur många mån som helst
                                            //Ta ett lån
                                            break;
                                        
                                          case 6:                                         
                                           CustomerMethods.PrintLoan(AccountList);
                                           break;

                                          case 7:
                                           LogOut();
                                           Console.WriteLine("Tryck valfri knapp för att logga ut!");
                                           break;
                                        default:
                                            Console.WriteLine("Vänligen välj 1-7");
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

                    case 2:
                        Console.WriteLine("Tack för idag");
                        QuitApp();
                        break;

                    default:
                        Console.WriteLine("Välj 1 eller 2");
                        //Readkey??
                        break;
                }
            }
        }
    }
}

