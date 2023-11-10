using Spectre.Console;

namespace Bank.Console_output
{
    static public class Menu
    {
        public static void PrintStartMenu()
        {
            
            AnsiConsole.MarkupLine("[red]VÄLKOMMEN[/] TILL BANKEN");
            AnsiConsole.WriteLine("1. Logga in");
            
            AnsiConsole.WriteLine("3. Om oss");
            AnsiConsole.WriteLine("4. Stäng sidan");
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

            AnsiConsole.Write(
        new FigletText("FoxBank")
        .LeftJustified()
        .Color(Color.Red));
        }

        public static void PrintLoginPage()
        {
            Console.WriteLine();
        }

        public static void AdminMenu()
        {
            Console.WriteLine("Skapa användare");
            Console.WriteLine("Logga ut");
        }

    }
}
