using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Classes
{

    public enum Role
    {
        Admin,
        Customer,
        Invalid
    }
    public abstract class User
    {
        protected Role Role { get;set; }
        protected string Username { get; set; }
        protected string Password { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
            Role = Role.Invalid;
        }

        public abstract void Login();

    }
}
