using Spectre.Console;

namespace Bank.Console_output
{
    static public class Menu
    {
        public static void PrintStartMenu()
        {
            AnsiConsole.MarkupLine("[red]VÄLKOMMEN[/] TILL BANKEN");
            AnsiConsole.WriteLine("[1] Logga in");
            AnsiConsole.WriteLine("[2] Om oss");
            AnsiConsole.WriteLine("[3] Stäng sidan");
            
            }

        public static void PrintCustomerMenu()
        {
            MenuTitle();
            Console.WriteLine("1. Skapa ett konto");
            Console.WriteLine("2. Visa dina konton");
            Console.WriteLine("3. Överför pengar");
            Console.WriteLine("4. Visa kontohistorik");
            Console.WriteLine("5. Ta ett lån");
            Console.WriteLine("6. Logga ut");
        }
        public static void MenuTitle()
        {
            ////Panel test
            //var panel = new Panel("Test1");
            //panel.Header = new PanelHeader("Header");
            //panel.Border = BoxBorder.Double;
            //AnsiConsole.Write(panel);

            //// table test
            //var table = new Table();
            //table.AddColumn(new TableColumn(new Markup("[yellow]Foo[/]")));
            //table.AddColumn(new TableColumn("[blue]Bar[/]"));
            //AnsiConsole.Write(table);

            //    var fruit = AnsiConsole.Prompt(
            //    new SelectionPrompt<string>()
            //    .Title("What's your [green]favorite fruit[/]?")
            //    .PageSize(10)
            //    .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
            //    .AddChoices(new[] {
            //        "Apple", "Apricot", "Avocado",
            //        "Banana", "Blackcurrant", "Blueberry",
            //        "Cherry", "Cloudberry", "Cocunut",
            //}));

            //    // Echo the fruit back to the terminal
            //    AnsiConsole.WriteLine($"I agree. {fruit} is tasty!");

            //    AnsiConsole.Write(
            //new FigletText("FoxBank")
            //.LeftJustified()
            //.Color(Color.Red));

            Console.Write("  ______          ____              _    " +
                "\r\n |  ____|        |  _ \\            | |   \r\n " +
                "| |__ _____  __ | |_) | __ _ _ __ | | __\r\n |  __/ _ " +
                "\\ \\/ / |  _ < / _` | '_ \\| |/ /" +
                "\r\n | | | (_) >  <  | |" +
                "_) | (_| | | | |   < \r\n |_|  \\___/_/\\_\\ |__" +
                "__/ \\__,_|_| |_|_|\\_\\\r\n                       " +
                "                " +
                "  \r\n ");
            
        }

        public static void PrintLoginPage()
        {
            Console.WriteLine("Logga in som admin");
            Console.WriteLine("Logga in som kund");
            string userInput = Console.ReadLine();
            switch(userInput)
            {
                case "1":
                    AdminMenu();
                    break;
            }
        }

        public static void AdminMenu()
        {
            Console.WriteLine("Skapa användare");
            Console.WriteLine("Logga ut");
        }
        

    }
}
