using Bank.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Logic
{
    public class AdminMethods
    {
        public static LoginUser CreateUser()
        {
            Console.Write("Användarnamn:");
            string Username = Console.ReadLine();
            Console.Write("Lösenord:");
            string Password = Console.ReadLine();
            Console.WriteLine("Ditt användarkonto är skapat!");
            return new LoginUser(Username, Password, false);
        }

    }
}
