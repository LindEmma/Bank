using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Classes;

namespace Bank
{
    internal class LoginManager
    {
        public List<LoginUser> _users;
        public int _loginAttempts;
        public LoginUser _loggedInUser;
        public LoginManager()
        {
            _users = new List<LoginUser>(); // Fyller på med users
            _users.Add(new LoginUser("Frida", "Vinter2023", isAdmin: true));
            _users.Add(new LoginUser("Tom", "Vinter2023"));
            _users.Add(new LoginUser("Emma", "Vinter2023"));
            _users.Add(new LoginUser("Gustav", "Vinter2023"));
            _loginAttempts = 0;
            _loggedInUser = null;
        }
        public bool Login(string username, string password)
        {
            foreach (var user in _users)
            {
                if (user.UserName == username && user.Password == password)
                {
                    _loggedInUser = user;
                    return true;
                }
            }

            _loginAttempts++;

            if (_loginAttempts >= 3)
            {
                Console.WriteLine("För många felaktiga login försök.");
                Environment.Exit(0);
            }
            return false;
        }
        public bool IsAdmin()
        {
            return _loggedInUser != null && _loggedInUser.IsAdmin;
        }
    }
}
