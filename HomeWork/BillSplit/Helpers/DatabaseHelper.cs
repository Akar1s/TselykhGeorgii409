using System.Text.Json;
namespace Debtors
{
    public static class DatabaseHelper
    {
        public static T LoadDatabase<T>(string fileName) where T : class
        {
            if (!File.Exists(fileName)) return null;
            var jsonData = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<T>(jsonData);
        }

        public static void SaveDatabase<T>(string fileName, T data)
        {
            var jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, jsonData);
        }

    }
}