namespace Debtors
{
    public class OutData : IOutData
    {
        public FileOut CreateFile(FileData fileData)
        {
            var filePath = Path.Combine(fileData.Path, fileData.FileName);
            File.Create(filePath).Dispose();
            return new FileOut(filePath, fileData);
        }

        public void WriteMainInformationToFile(FileOut fileOut)
        {
            File.AppendAllText(fileOut.Path, $"Название счёта: {fileOut.FileData.Name}\nДата: {fileOut.FileData.CreationDate:dd.MM.yyyy}\n");
        }

        public void WriteAboutVenuesToFile(FileOut fileOut, PartyData partyData)
        {
            var venueInfo = $"Заведение: {partyData.VenueName}\nПлательщик: {partyData.Payer}\n";
            venueInfo += string.Join("\n", partyData.Names.Select(kv => $"{kv.Key}: {kv.Value}"));
            File.AppendAllText(fileOut.Path, venueInfo + "\n");
        }
        public void WriteCalculatedInformationToFile(FileOut fileOut, VenuesDataStorage venuesDataStorage)
        {
            var calculationInfo = string.Join("\n", venuesDataStorage.VenuesData.SelectMany(p => p.Value.Select(d => $"{d.Key} => {p.Key}: {d.Value}")));
            File.AppendAllText(fileOut.Path, calculationInfo + "\n");
        }

        public void WriteResultToConsole(FileOut fileOut)
        {
            Console.WriteLine(File.ReadAllText(fileOut.Path));
        }
    }
}