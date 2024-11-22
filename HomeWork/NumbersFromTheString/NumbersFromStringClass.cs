using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.NumbersFromTheString
{
    public class NumbersFromStringClass
    {
        public static void NumbersFromString()
        {
            string answer = "";
            Console.WriteLine("Введите строку");
            string input = Console.ReadLine();
            for (int i = 0; i< input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    answer += input[i];
                }
            }
            Console.WriteLine(answer);
        }
    }
}
