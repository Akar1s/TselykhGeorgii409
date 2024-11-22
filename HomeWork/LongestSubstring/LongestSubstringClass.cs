using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.LongestSubstring
{
     public class LongestSubstringClass
    {
        public static void LongestSubstring()
        {
            Console.WriteLine("Введите строку");
            string input = Console.ReadLine();
            string longestSubstring = "";
            string midtermSubstring = "";
            for (int i = 0; i <= input.Length - 1; i++)
            {
                char currentSymbol = input[i];
                int index = midtermSubstring.IndexOf(currentSymbol);
                if (index != -1)
                {
                    if (midtermSubstring.Length > longestSubstring.Length)
                    {
                        longestSubstring = midtermSubstring;
                    }
                    midtermSubstring = midtermSubstring.Substring(index + 1);
                }
                midtermSubstring += currentSymbol;
            }
            if (midtermSubstring.Length > longestSubstring.Length)
            {
                longestSubstring = midtermSubstring;
            }
            Console.WriteLine($"{longestSubstring} - Самая длинная подстрока");
        }
    }
}
