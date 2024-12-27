namespace Debtors
{
    public interface IOutData
    {
        FileOut CreateFile(FileData fileData);
        void WriteMainInformationToFile(FileOut fileOut);
        void WriteAboutVenuesToFile(FileOut fileOut, PartyData partyData);
        void WriteCalculatedInformationToFile(FileOut fileOut, VenuesDataStorage venuesDataStorage);
        void WriteResultToConsole(FileOut fileOut);
    }
}