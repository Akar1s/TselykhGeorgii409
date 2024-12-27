namespace Debtors
{
    public class FileOut
    {
        public string Path { get; }
        public FileData FileData { get; }

        public FileOut(string path, FileData fileData)
        {
            Path = path;
            FileData = fileData;
        }
    }
}