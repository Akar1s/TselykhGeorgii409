using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.TextCapitalization
{
    public class CapitalizationClass
    {
        public static void Capitalization()
        {
            Console.WriteLine("Введите предложение");
            string input = Console.ReadLine();
            string answer;
            string[] words = input.Split(" ");
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
            }
            answer = String.Join(" ", words);
            Console.WriteLine(answer);
        }
    }
}
