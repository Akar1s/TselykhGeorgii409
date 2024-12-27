

namespace Debtors
{
    public class GetPartyData : IGetPartyData
    {
        public PartyData GetPartyD(List<string> names)
        {
            Console.WriteLine("Введите название заведения:");
            var venueName = ValidateNonEmptyInput("Название заведения");

            Console.WriteLine("Введите имя плательщика:");
            var payer = ValidateNonEmptyInput("Имя плательщика");

            var partyData = new PartyData(venueName, payer);

            Console.WriteLine("Кто был в заведении?");
            var friendsInVenue = new List<string>();
            while (true)
            {
                Console.WriteLine("Введите имя друга (пустая строка завершит ввод):");
                var friend = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(friend)) break;
                friendsInVenue.Add(friend);
            }

            foreach (var friend in friendsInVenue)
            {
                Console.WriteLine($"Сколько потратил {friend}?");
                int amount;
                while (!int.TryParse(Console.ReadLine(), out amount) || amount < 0)
                {
                    Console.WriteLine("Сумма должна быть числом >= 0. Попробуйте снова:");
                }
                partyData.Names[friend] = amount;
            }

            while (true)
            {
                Console.WriteLine("Был ли кто-нибудь ещё? (+ Да, - Нет)");
                string moreFriends;
                do
                {
                    moreFriends = Console.ReadLine()?.Trim();
                    if (moreFriends != "+" && moreFriends != "-")
                    {
                        Console.WriteLine("Введите + для добавления друга или - для завершения.");
                    }
                } while (moreFriends != "+" && moreFriends != "-");

                if (moreFriends == "+")
                {
                    Console.WriteLine("Введите имя друга:");
                    var friend = ValidateNonEmptyInput("Имя друга");
                    Console.WriteLine($"Сколько потратил {friend}?");
                    int amount;
                    while (!int.TryParse(Console.ReadLine(), out amount) || amount < 0)
                    {
                        Console.WriteLine("Сумма должна быть числом >= 0. Попробуйте снова:");
                    }
                    partyData.Names[friend] = amount;
                }
                else
                {
                    break;
                }
            }

            return partyData;
        }

        private string ValidateNonEmptyInput(string fieldName)
        {
            string input;
            do
            {
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