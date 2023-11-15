using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class LoginHandler
    {
        public enum UserType
        {
            None,
            Regular,
            Admin
        }

        public UserType HandleLogin(LoginManager loginManager)
        {

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Användarnamn");
                string userName = Console.ReadLine();
                Console.WriteLine("Lösenord");
                string password = Console.ReadLine();

                bool success = loginManager.Login(userName, password);
                if (success)
                {
                    if (loginManager.IsAdmin())
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
    }
}
