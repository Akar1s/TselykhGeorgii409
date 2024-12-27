using Debtors;

namespace Debtors
{
    public class MenuHandler
    {
        public readonly IServiceProvider _serviceProvider;
        public readonly VenuesDataStorage _venuesDataStorage;

        public MenuHandler(IServiceProvider serviceProvider, VenuesDataStorage venuesDataStorage)
        {
            _serviceProvider = serviceProvider;
            _venuesDataStorage = venuesDataStorage;
        }


        public void ShowMainMenu()
        {
            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1 - Счёт");
                Console.WriteLine("2 - Добавить заведение");
                Console.WriteLine("3 - Добавить друга");
                Console.WriteLine("4 - Вывести всех друзей");
                Console.WriteLine("5 - Вывести все заведения");
                Console.WriteLine("6 - Статистика");
                Console.WriteLine("7 - Очистить базу данных");
                Console.WriteLine("8 - Вывод конкретного счёта");
                Console.WriteLine("9 - Выйти");

                if (!int.TryParse(Console.ReadLine(), out var choice) || choice < 1 || choice > 9)
                {
                    Console.WriteLine("Неверный ввод. Попробуйте снова.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        HandleBill();
                        break;
                    case 2:
                        AddVenue();
                        break;
                    case 3:
                        AddFriend();
                        break;
                    case 4:
                        PrintAllFriends();
                        break;
                    case 5:
                        PrintAllVenuess();
                        break;
                    case 6:
                        ShowStatistics();
                        break;
                    case 7:
                        ClearDatabase();
                        break;
                    case 8:
                        ShowSpecificBill();
                        break;
                    case 9:
                        Console.WriteLine("Выход из программы.");
                        return;
                }
            }
        }

        private void HandleBill()
        {
            var billHandler = new BillHandler(_serviceProvider, _venuesDataStorage);
            billHandler.ProcessBill();
        }

        private void AddVenue()
        {
            Console.WriteLine("Введите название заведения:");
            var venueName = InputValidator.ValidateNonEmptyInput("Название заведения");
            var venues = DatabaseHelper.LoadDatabase<List<string>>("venues.json") ?? new List<string>();
            venues.Add(venueName);
            DatabaseHelper.SaveDatabase("venues.json", venues);
            Console.WriteLine("Заведение добавлено.");
        }

        private void AddFriend()
        {
            Console.WriteLine("Введите имя друга:");
            var friendName = InputValidator.ValidateNonEmptyInput("Имя друга");
            var friends = DatabaseHelper.LoadDatabase<List<string>>("friends.json") ?? new List<string>();
            friends.Add(friendName);
            DatabaseHelper.SaveDatabase("friends.json", friends);
            Console.WriteLine("Друг добавлен.");
        }

        private void PrintAllFriends()
        {
            var friends = DatabaseHelper.LoadDatabase<List<string>>("friends.json");
            if (friends == null || !friends.Any())
            {
                Console.WriteLine("Список друзей пуст.");
                return;
            }

            Console.WriteLine("Список друзей:");
            foreach (var friend in friends) Console.WriteLine($"- {friend}");
        }

        private void PrintAllVenuess()
        {
            var venues = DatabaseHelper.LoadDatabase<List<string>>("venues.json");
            if (venues == null || !venues.Any())
            {
                Console.WriteLine("Список заведений пуст.");
                return;
            }

            Console.WriteLine("Список заведений:");
            foreach (var venue in venues) Console.WriteLine($"- {venue}");
        }

        private void ShowStatistics()
        {
            var statisticsHandler = new StatisticsHandler(_venuesDataStorage);
            statisticsHandler.ShowStatisticsMenu();
        }

        private void ClearDatabase()
        {
            File.Delete("friends.json");
            File.Delete("venues.json");
            Console.WriteLine("База данных очищена.");
        }

        private void ShowSpecificBill()
        {
            Console.WriteLine("Введите имя файла счёта для отображения:");
            var fileName = InputValidator.ValidateNonEmptyInput("Имя файла");
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            if (File.Exists(filePath))
            {
                Console.WriteLine(File.ReadAllText(filePath));
            }
            else
            {
                Console.WriteLine("Файл не найден.");
            }
        }

    }
}
