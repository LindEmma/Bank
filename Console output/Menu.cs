﻿using Spectre.Console;

namespace Bank.Console_output
{
    static public class Menu
    {
        // Different menu outputs for different logins
        // + some good to have short cuts
        public static void PrintStartMenu()
        {
            MenuTitle();
            AnsiConsole.MarkupLine("[red]VÄLKOMMEN[/]");
            AnsiConsole.WriteLine("[1] Logga in");
            AnsiConsole.WriteLine("[2] Stäng sidan");
        }
        public static void PrintCustomerMenuNoAccounts()
        {
            MenuTitle();
            Console.WriteLine();
            AnsiConsole.MarkupLine("[blue]Du är inloggad som kund[/]\n");
            Console.WriteLine("[1] Öppna ditt första bankkonto");
            Console.WriteLine("[2] Visa dina konton");
            Console.WriteLine("[3] Överför pengar");
            Console.WriteLine("[4] Visa kontohistorik");
            Console.WriteLine("[5] Ta ett lån");
            Console.WriteLine("[6] Se dina lån");
            Console.WriteLine("[7] Logga ut");
        }
        public static void PrintCustomerMenu()
        {
            MenuTitle();
            Console.WriteLine();
            AnsiConsole.MarkupLine("[blue]Du är inloggad som kund[/]\n");
            Console.WriteLine("[1] Öppna ett sparkonto");
            Console.WriteLine("[2] Visa dina konton");
            Console.WriteLine("[3] Överför pengar");
            Console.WriteLine("[4] Visa kontohistorik");
            Console.WriteLine("[5] Ta ett lån");
            Console.WriteLine("[6] Se dina lån");
            Console.WriteLine("[7] Logga ut");
        }
        public static void PrintAdminMenu()
        {
            MenuTitle();
            AnsiConsole.MarkupLine("[green]Du är inloggad som admin[/]\n");
            Console.WriteLine("[1] Skapa ny användare");
            Console.WriteLine("[2] Logga ut");
        }
        public static void MenuTitle()
        {
            AnsiConsole.Markup("[orangered1]  ______          ____              _    " +
                "\r\n |  ____|        |  _ \\            | |   \r\n " +
                "| |__ _____  __ | |_) | __ _ _ __ | | __\r\n |  __/ _ " +
                "\\ \\/ / |  _ < / _` | '_ \\| |/ /" +
                "\r\n | | | (_) >  <  | |" +
                "_) | (_| | | | |   < \r\n |_|  \\___/_/\\_\\ |__" +
                "__/ \\__,_|_| |_|_|\\_\\\r\n                       " +
                "                " +
                "  \r\n[/]");
        }
        public static void PressKey()
        {
            AnsiConsole.MarkupLine("\n[rapidblink]Tryck på valfri knapp för att gå tillbaka[/]");
            Console.ReadKey();
        }
        public static void ClearTitle()
        {
            Console.Clear();
            Menu.MenuTitle();
        }
    }
}
