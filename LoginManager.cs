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
        public List<LoginUser> users { get; set; }
        public int loginAttempts { get; set; }
        public LoginUser loggedInUser { get; set; }
        public LoginManager(List<LoginUser> users)
        {
            this.users = users;
            loginAttempts = 0;
            loggedInUser = null;
        }
        public bool Login(string username, string password)
        {
            foreach (var user in users)
            {
                if (user.UserName == username && user.Password == password)
                {
                    loggedInUser = user;
                    return true;
                }
            }

            loginAttempts++;

            if (loginAttempts >= 3)
            {
                Console.WriteLine("För många felaktiga login försök.");
                Environment.Exit(0);
            }
            return false;
        }
        public bool IsAdmin()
        {
            return loggedInUser != null && loggedInUser.IsAdmin;
        }
    }
}
