using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Logic
{
    //Handles conversion from string to int and decimal
    // useful in other methods
    public static class ParseMethods
    {
        public static decimal ReadDecimal()
        {
            decimal decNum;
            while (decimal.TryParse(Console.ReadLine(), out decNum) == false)
            {
                Console.WriteLine("Skriv ett tal med eller utan decimaler");
            }
            return decNum;
        }

        public static int ReadInt()
        {
            int intNum;
            while (int.TryParse(Console.ReadLine(), out intNum)== false)
            {
                Console.WriteLine("Skriv ett heltal");
            }
            return intNum;
        }
    }
}
