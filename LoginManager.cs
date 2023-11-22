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

        //Constructor to initialize the LoginManager with a list of users
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

        // Method to handle the login process
        public UserType HandleLogin()
        {
            //3 login attempts
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Användarnamn");
                string userName = Console.ReadLine();
                Console.WriteLine("Lösenord");
                string password = Console.ReadLine();

                // If login successful, determine user type and return
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

        // Method to perform the login
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

            // Login attempts and exit if exceeded
            LoginAttempts++;

            if (LoginAttempts >= 3)
            {
                Console.WriteLine("För många felaktiga login försök.");
                Environment.Exit(0);
            }
            return false;
        }

        // Method to check if a user is an admin
        private bool IsAdmin(string username)
        {
            var user = Users.FirstOrDefault(u => u.UserName == username);
            return user != null && user.IsAdmin;
        }
    }
}
