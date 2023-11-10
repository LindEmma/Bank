using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Classes
{
    internal class Admin : User
    {
        public Admin(string username, string password)
            :base(username, password)
        {
            Role = Role.Admin;
        }
        public override void Login()
        {
            
        }
    }
}
