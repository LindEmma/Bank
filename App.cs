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
                Console.Clear();
                Menu.MenuTitle();
                Menu.PrintStartMenu();
                string userChoice = Console.ReadLine();
                Console.Clear();
                switch (userChoice)
                {
                    case "1":
                        //Logga in
                        break;

                    case "2":
                        //skapa användare
                        break;

                    case "3":
                        Console.WriteLine("Vi är en bank");
                        Console.WriteLine("Tryck på valfri knapp för att gå tillbaka till startsidan");
                        Console.ReadKey();
                        break;

                    case "4":

                        Console.WriteLine("Tack för att du använde banken");
                        QuitApp(); // RunApp==false
                        break;

                    default:
                        Console.WriteLine("Välj 1-3");
                        break;
                }
            }
        }

    }
}
