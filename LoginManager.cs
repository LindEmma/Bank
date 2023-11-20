using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Classes;

namespace Bank
{
    public class LoginManager
    {
        public List<LoginUser> Users { get; private set; }
        public int LoginAttempts { get; private set; }
        public LoginUser LoggedInUser { get; private set; }

        public LoginManager(List<LoginUser> users)
        {
            Users = users;
            LoginAttempts = 0;
            LoggedInUser = null;
        }

        public enum UserType
        {
            None,
            Regular,
            Admin
        }

        public UserType HandleLogin()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Användarnamn");
                string userName = Console.ReadLine();
                Console.WriteLine("Lösenord");
                string password = Console.ReadLine();


                bool success = Login(userName, password);
                if (success)
                {
                    Console.WriteLine($"IsAdmin: {IsAdmin(userName)}");
                    if (IsAdmin(userName))
                    {
                        return UserType.Admin;
                    }
                    else
                    {
                        return UserType.Regular;
                    }
                }
                else
                {
                    Console.WriteLine("Fel användarnamn eller lösenord, försök igen.");
                }
            }

            return UserType.None;
        }

        private bool Login(string username, string password)
        {
            foreach (var user in Users)
            {
                if (user.UserName == username && user.Password == password)
                {
                    LoggedInUser = user;
                    return true;
                }
            }

            LoginAttempts++;

            if (LoginAttempts >= 3)
            {
                Console.WriteLine("För många felaktiga login försök.");
                Environment.Exit(0);
            }
            return false;
        }

        private bool IsAdmin(string username)
        {
            var user = Users.FirstOrDefault(u => u.UserName == username);
            return user != null && user.IsAdmin;
        }
    }
}
