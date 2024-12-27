namespace Debtors
{
    public static class InputValidator
    {
        public static string ValidateNonEmptyInput(string fieldName)
        {
            string input;
            do
            {
                Console.WriteLine($"{fieldName}:");
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine($"{fieldName} не может быть пустым. Попробуйте снова:");
                }
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }
    }
}

