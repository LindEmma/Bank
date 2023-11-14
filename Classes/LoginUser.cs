using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Classes
{
    internal class LoginUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public LoginUser(string username, string password, bool isAdmin = false)
        {
            UserName = username;
            Password = password;
            IsAdmin = isAdmin;
        }
    }
}
