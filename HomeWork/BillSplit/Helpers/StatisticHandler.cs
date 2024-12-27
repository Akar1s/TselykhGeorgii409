using Debtors;

namespace Debtors
{
    public class StatisticsHandler
    {
        private readonly VenuesDataStorage _venuesDataStorage;

        public StatisticsHandler(VenuesDataStorage venuesDataStorage)
        {
            _venuesDataStorage = venuesDataStorage;
        }


        public void ShowStatisticsMenu()
        {
            while (true)
            {
                Console.WriteLine("\nВыберите тип статистики:");
                Console.WriteLine("1 - Статистика трат человека за год");
                Console.WriteLine("2 - Статистика трат человека за месяц");
                Console.WriteLine("3 - Статистика трат человека по заведению");
                Console.WriteLine("4 - Статистика заведений по посещаемости");
                Console.WriteLine("5 - Статистика заведений по тратам в них");
                Console.WriteLine("6 - Возврат");

                if (!int.TryParse(Console.ReadLine(), out var choice) || choice < 1 || choice > 6)
                {
                    Console.WriteLine("Неверный ввод. Попробуйте снова.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        ShowYearlySpendingStatistics();
                        break;
                    case 2:
                        ShowMonthlySpendingStatistics();
                        break;
                    case 3:
                        ShowSpendingByVenueStatistics();
                        break;
                    case 4:
                        ShowVenueVisitStatistics();
                        break;
                    case 5:
                        ShowVenueSpendingStatistics();
                        break;
                    case 6:
                        return;
                }
            }
        }

        private void ShowYearlySpendingStatistics()
        {
            Console.WriteLine("Введите год для статистики:");
            if (!int.TryParse(Console.ReadLine(), out var year))
            {
                Console.WriteLine("Неверный ввод. Попробуйте снова.");
                return;
            }

            Console.WriteLine("Статистика трат человека за год:");
            var yearlySpending = new Dictionary<string, int>();

            foreach (var venue in _venuesDataStorage.VenueVisits)
            {
                foreach (var visit in venue.Value)
                {
                    if (visit.VisitDate.Year == year)
                    {
                        foreach (var name in visit.Names)
                        {
                            if (!yearlySpending.ContainsKey(name.Key))
                            {
                                yearlySpending[name.Key] = 0;
                            }
                            yearlySpending[name.Key] += name.Value;
                        }
                    }
                }
            }

            foreach (var person in yearlySpending)
            {
                Console.WriteLine($"{person.Key}: {person.Value}");
            }
        }

        private void ShowMonthlySpendingStatistics()
        {
            Console.WriteLine("Введите год для статистики:");
            if (!int.TryParse(Console.ReadLine(), out var year))
            {
                Console.WriteLine("Неверный ввод. Попробуйте снова.");
                return;
            }

            Console.WriteLine("Введите месяц для статистики:");
            if (!int.TryParse(Console.ReadLine(), out var month) || month < 1 || month > 12)
            {
                Console.WriteLine("Неверный ввод. Попробуйте снова.");
                return;
            }

            Console.WriteLine("Статистика трат человека за месяц:");
            var monthlySpending = new Dictionary<string, int>();

            foreach (var venue in _venuesDataStorage.VenueVisits)
            {
                foreach (var visit in venue.Value)
                {
                    if (visit.VisitDate.Year == year && visit.VisitDate.Month == month)
                    {
                        foreach (var name in visit.Names)
                        {
                            if (!monthlySpending.ContainsKey(name.Key))
                            {
                                monthlySpending[name.Key] = 0;
                            }
                            monthlySpending[name.Key] += name.Value;
                        }
                    }
                }
            }

            foreach (var person in monthlySpending)
            {
                Console.WriteLine($"{person.Key}: {person.Value}");
            }
        }
    

        private void ShowSpendingByVenueStatistics()
        {
            Console.WriteLine("Статистика трат человека по заведению:");
            var spendingByvenue = new Dictionary<string, Dictionary<string, int>>();

            foreach (var venue in _venuesDataStorage.VenueVisits)
            {
                if (!spendingByvenue.ContainsKey(venue.Key))
                {
                    spendingByvenue[venue.Key] = new Dictionary<string, int>();
                }

                foreach (var visit in venue.Value)
                {
                    foreach (var name in visit.Names)
                    {
                        if (!spendingByvenue[venue.Key].ContainsKey(name.Key))
                        {
                            spendingByvenue[venue.Key][name.Key] = 0;
                        }
                        spendingByvenue[venue.Key][name.Key] += name.Value;
                    }
                }
            }

            foreach (var venue in spendingByvenue)
            {
                Console.WriteLine($"Заведение: {venue.Key}");
                foreach (var person in venue.Value)
                {
                    Console.WriteLine($"  {person.Key}: {person.Value}");
                }
            }
        }

        private void ShowVenueVisitStatistics()
        {
            Console.WriteLine("Статистика заведений по посещаемости:");
            var visitCount = new Dictionary<string, int>();

            foreach (var venue in _venuesDataStorage.VenueVisits)
            {
                visitCount[venue.Key] = venue.Value.Count;
            }

            foreach (var venue in visitCount)
            {
                Console.WriteLine($"{venue.Key}: {venue.Value} посещений");
            }
        }

        private void ShowVenueSpendingStatistics()
        {
            Console.WriteLine("Статистика заведений по тратам в них:");
            var spendingByVenue = new Dictionary<string, int>();

            foreach (var venue in _venuesDataStorage.VenueVisits)
            {
                if (!spendingByVenue.ContainsKey(venue.Key))
                {
                    spendingByVenue[venue.Key] = 0;
                }

                foreach (var visit in venue.Value)
                {
                    foreach (var amount in visit.Names.Values)
                    {
                        spendingByVenue[venue.Key] += amount;
                    }
                }
            }

            foreach (var venue in spendingByVenue)
            {
                Console.WriteLine($"{venue.Key}: {venue.Value} потрачено");
            }
        }
    }
}