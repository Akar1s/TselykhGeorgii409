namespace Debtors
{
    public class FileData
    {
        public string Name { get; }
        public DateTime CreationDate { get; }
        public string Path { get; }
        public string FileName { get; }

        public FileData(string name, DateTime creationDate, string path, string fileName)
        {
            Name = name;
            CreationDate = creationDate;
            Path = path;
            FileName = fileName;
        }
    }
}