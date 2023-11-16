using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Classes;

namespace Bank
{
    public class LoginHandler
    {
        public enum UserType
        {
            None,
            Regular,
            Admin
        }

        public UserType HandleLogin(List<LoginUser> users)
        {

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Användarnamn");
                string userName = Console.ReadLine();
                Console.WriteLine("Lösenord");
                string password = Console.ReadLine();

                bool success = Login(users, userName, password);
                if (success)
                {
                    if (IsAdmin(users, userName))
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
        private bool Login(List<LoginUser> users, string username, string password)
        {
            foreach (var user in users)
            {
                if (user.UserName == username && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsAdmin(List<LoginUser> users, string username)
        {
            var user = users.FirstOrDefault(u => u.UserName == username);
            return user != null && user.IsAdmin;
        }
    }
}
