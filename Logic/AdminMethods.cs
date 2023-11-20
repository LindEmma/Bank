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
        public static LoginUser CreateUser()
        {
            string Username = "";
            string Password = "";
            while (String.IsNullOrEmpty(Username))
            {
                Console.Write("Användarnamn:");
                Username = Console.ReadLine();
                if(String.IsNullOrEmpty(Username)) Console.WriteLine("Du måste mata in något");
            }
            while (String.IsNullOrEmpty(Password))
            {
                Console.Write("Lösenord:");
                Password = Console.ReadLine();
                if (String.IsNullOrEmpty(Password)) Console.WriteLine("Du måste mata in något");
            }
            Console.WriteLine("Ditt användarkonto är skapat!");
            return new LoginUser(Username, Password, false);
        }
    }
}
