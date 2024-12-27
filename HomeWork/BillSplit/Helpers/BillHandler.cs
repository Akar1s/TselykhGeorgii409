using System.Text.Json;

using Microsoft.Extensions.DependencyInjection;

namespace Debtors
{
    public class BillHandler
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly VenuesDataStorage _venuesDataStorage;

        public BillHandler(IServiceProvider serviceProvider, VenuesDataStorage venuesDataStorage)
        {
            _serviceProvider = serviceProvider;
            _venuesDataStorage = venuesDataStorage;
        }

        public void ProcessBill()
        {
            var fileData = _serviceProvider.GetService<ICreateFileData>()?.MCreateFileData();
            if (fileData == null)
            {
                Console.WriteLine("Ошибка: Не удалось создать данные файла.");
                return;
            }

            var file = _serviceProvider.GetService<IOutData>()?.CreateFile(fileData);
            if (file == null)
            {
                Console.WriteLine("Ошибка: Не удалось создать файл.");
                return;
            }

            var names = _serviceProvider.GetService<IGetNames>()?.MGetNames();
            if (names == null || names.Names == null)
            {
                Console.WriteLine("Ошибка: Не удалось получить имена.");
                return;
            }

            _serviceProvider.GetService<IOutData>()?.WriteMainInformationToFile(file);

            var venues = DatabaseHelper.LoadDatabase<List<string>>("venues.json") ?? new List<string>();

            while (true)
            {
                var partyData = _serviceProvider.GetService<IGetPartyData>()?.GetPartyD(names.Names);
                if (partyData == null)
                {
                    Console.WriteLine("Ошибка: Не удалось получить данные о вечеринке.");
                    return;
                }

                _venuesDataStorage.AddVenue(partyData, fileData.CreationDate);
                _serviceProvider.GetService<IOutData>()?.WriteAboutVenuesToFile(file, partyData);

                if (!venues.Contains(partyData.VenueName))
                {
                    venues.Add(partyData.VenueName);
                }

                Console.WriteLine("Добавить новое заведение? (+ Да, - Нет)");
                string addMore;
                do
                {
                    addMore = Console.ReadLine()?.Trim();
                    if (addMore != "+" && addMore != "-")
                    {
                        Console.WriteLine("Введите + для добавления нового заведения или - для завершения.");
                    }
                } while (addMore != "+" && addMore != "-");

                if (addMore == "-") break;
            }

            DatabaseHelper.SaveDatabase("venues.json", venues);

            _serviceProvider.GetService<ICalculateResult>()?.GetCalculatedResult(_venuesDataStorage);
            _serviceProvider.GetService<IOutData>()?.WriteCalculatedInformationToFile(file, _venuesDataStorage);
            _serviceProvider.GetService<IOutData>()?.WriteResultToConsole(file);
        }
    }
}