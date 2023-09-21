namespace IOLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileWordCounter fileWordCounter = new FileWordCounter();
            fileWordCounter.ReadFileAndCount();
            fileWordCounter.ReadFilesFromDirectoryAndCount();
            fileWordCounter.DisplayDictionary();
        }
    }
}