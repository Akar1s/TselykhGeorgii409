using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Palindrome
{
    public class PalindromeClass
    {
        public static void Palindrome()
        {
            Console.WriteLine("Введите строку");
            string input = Console.ReadLine();
            string strn = "";
            string revercedString = "";
            for (int i = 0; i <= input.Length - 1; i++)
            {
                if (Char.IsLetterOrDigit(input[i]))
                {
                    strn += Char.ToLower(input[i]);
                }
            }
            for (int i = (strn.Length - 1); i>= 0; i--)
            {
                revercedString += strn[i];
            }
            if (revercedString == strn)
            {
                Console.WriteLine($"{input} - палиндром");
            }
            else
            {
                Console.WriteLine($"{input} - не палиндром");
            }

        }
    }
}
