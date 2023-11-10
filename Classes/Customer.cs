using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Classes
{
    internal class Customer: User
    {
        public Customer(string username, string password)

            :base(username, password)
        {
            Role = Role.Customer;
        }
        public override void Login()
        {

        }
    }
}
