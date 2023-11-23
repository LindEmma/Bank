using Bank.Classes;
using Bank.Console_output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Logic
{
    public static class AdminMethods
    {
        // Method to create a new user
        public static LoginUser CreateUser()
        {
            // Fields containing username and password
            string Username = "";
            string Password = "";
            // Loop to check if the string is empty
            while (String.IsNullOrEmpty(Username))
            {
                // Prompts the user to enter username
                Console.Write("Användarnamn:");
                Username = Console.ReadLine();
                // If string is still empty, loop again
                if(String.IsNullOrEmpty(Username)) Console.WriteLine("Du måste mata in något");
            }
            // Loop to check if the string is empty
            while (String.IsNullOrEmpty(Password))
            {
                // Prompts the user to enter password
                Console.Write("Lösenord:");
                Password = Console.ReadLine();
                // If string is still empty, loop again
                if (String.IsNullOrEmpty(Password)) Console.WriteLine("Du måste mata in något");
            }
            Console.WriteLine("Ditt användarkonto är skapat!");
            return new LoginUser(Username, Password, false);
        }
    }
}
