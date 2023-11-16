using Spectre.Console;

namespace Bank.Console_output
{
    static public class Menu
    {
        public static void PrintStartMenu()
        {
            MenuTitle();
            AnsiConsole.MarkupLine("[red]VÄLKOMMEN[/]");
            AnsiConsole.WriteLine("[1] Logga in");
            AnsiConsole.WriteLine("[2] Stäng sidan");
            }
      
        public static void PrintCustomerMenu()
        {
            MenuTitle();
            Console.WriteLine("Du är inloggad som kund\n");
            Console.WriteLine("1. Skapa ett konto");
            Console.WriteLine("2. Visa dina konton");
            Console.WriteLine("3. Överför pengar");
            Console.WriteLine("4. Visa kontohistorik");
            Console.WriteLine("5. Ta ett lån");
            Console.WriteLine("6. Logga ut");
        }
        public static void MenuTitle()
        {

            Console.Write("  ______          ____              _    " +
                "\r\n |  ____|        |  _ \\            | |   \r\n " +
                "| |__ _____  __ | |_) | __ _ _ __ | | __\r\n |  __/ _ " +
                "\\ \\/ / |  _ < / _` | '_ \\| |/ /" +
                "\r\n | | | (_) >  <  | |" +
                "_) | (_| | | | |   < \r\n |_|  \\___/_/\\_\\ |__" +
                "__/ \\__,_|_| |_|_|\\_\\\r\n                       " +
                "                " +
                "  \r\n");
            
        }

        //public static void PrintLoginPage()
        //{
        //    Console.WriteLine("Logga in som admin");
        //    Console.WriteLine("Logga in som kund");
        //    string userInput = Console.ReadLine();
        //    switch(userInput)
        //    {
        //        case "1":
        //            AdminMenu();
        //            break;
        //    }
        //}

        public static void PrintAdminMenu()
        {
            Console.WriteLine("Du är inloggad som admin\n");
            Console.WriteLine("1. Skapa användare");
            Console.WriteLine("2. Logga ut");
        }
        public static void PressKey()
        {
            Console.WriteLine("\nTryck på valfri knapp för att gå tillbaka");
            Console.ReadKey();
        }
        

    }
}
