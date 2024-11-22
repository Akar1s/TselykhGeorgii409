using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Anagram
{
    public class AnagramClass
    {
        public static void Anagram()
        {
            Console.WriteLine("Введите первую строку");
            string firstString = Console.ReadLine();
            Console.WriteLine("Введите вторую строку");
            string secondString = Console.ReadLine();
            if (ToLowerChars(firstString) == ToLowerChars(secondString))
            {
                Console.WriteLine("Это анаграммы");
            }
            else
            {
                Console.WriteLine("Это не анаграммы");
            }
        }
        public static string ToLowerChars(string input)
        {
            string strn = "";
            for (int i = 0; i <= input.Length - 1; i++)
            {   
                if (Char.IsLetterOrDigit(input[i]))
                {
                    strn += char.ToLower(input[i]);
                }
            }
            char[] elements = strn.ToCharArray();
            Array.Sort(elements);
            return new string(elements);
                
        }
    }
}
