using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Logic
{
    // Felhanterar typkonvertering från string till decimal. 
    // För att använda i annan klass, skriv:
    // decimal userInput = ParseMethods.ReadDecimal();
    public static class ParseMethods
    {
        public static decimal ReadDecimal()
        {
            decimal decNum;
            while (decimal.TryParse(Console.ReadLine(), out decNum) == false)
            {
                Console.WriteLine("Try again");
            }
            return decNum;
        }

        public static int ReadInt()
        {
            int intNum;
            while (int.TryParse(Console.ReadLine(), out intNum)== false)
            {
                Console.WriteLine("try again");
            }
            return intNum;
        }
    }
}
