
namespace Debtors
{
    public class CreateFileData : ICreateFileData
    {
        public FileData MCreateFileData()
        {
            Console.WriteLine("Введите название счёта:");
            var name = InputValidator.ValidateNonEmptyInput("Название счёта");

            DateTime creationDate;
            do
            {
                Console.WriteLine("Введите дату счёта (дд.мм.гггг):");
            } while (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out creationDate));

            string path;
            do
            {
                Console.WriteLine("Укажите путь для сохранения файла (без названия файла):");
                path = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(path) || !Directory.Exists(path));

            Console.WriteLine("Введите имя файла:");
            var fileName = InputValidator.ValidateNonEmptyInput("Имя файла");
            return new FileData(name, creationDate, path, fileName);
        }
    }
}