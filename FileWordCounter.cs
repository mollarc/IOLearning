using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IOLearning
{
    internal class FileWordCounter
    {
        string winDir = System.Environment.GetEnvironmentVariable("windir");
        Dictionary<string,int> TextFiles = new Dictionary<string,int>();
        public FileWordCounter() 
        { 

        }

        public void ReadFileAndCount()//Reads a specific file and counts the number of characters
        {
            int charCount = 0;
            Console.WriteLine("Please enter the file path Location");
            string filePath = Console.ReadLine();
            string fileName = Path.GetFileName(filePath);
            //code block below modified from microsoft code snippet https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/file-io-operation
            StreamReader reader = new StreamReader(filePath);
            try
            {
                do
                {
                    if(reader.Read()!=' ')//If char is not a space char count goes up
                    {
                        charCount++;
                    }
                }
                while (reader.Peek() != -1);
            }
            catch
            {
                Console.WriteLine("File is empty, does not exist, or path was entered wrong");
            }
            finally
            {
                reader.Close();
            }
            TextFiles.Add(fileName, charCount);//adds to dictionary
        }
        public void ReadFilesFromDirectoryAndCount()
        {
            int charCount = 0;
            Console.WriteLine("Please enter the file path for one of the files in the folder you wish to read");
            string filePath = Console.ReadLine();
            string directory = Path.GetDirectoryName(filePath);//Get the path of the folder
            
            //code block below modified from microsoft code snippet https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/file-io-operation
            string[] files = Directory.GetFiles(directory);
            foreach (string file in files)
            {
                StreamReader reader = new StreamReader(directory+"/"+file);//uses the path and appends the file to read
                try
                {
                    do
                    {
                        if (reader.Read() != ' ')
                        {
                            charCount++;
                        }
                    }
                    while (reader.Peek() != -1);
                }
                catch
                {
                    Console.WriteLine("File is empty, does not exist, or path was entered wrong");
                }
                finally
                {
                    reader.Close();
                }
                TextFiles.Add(file, charCount);
            }
        }
        public void DisplayDictionary()//Reads all Dictionary Entries
        {
            foreach(var file in TextFiles)
            {
                Console.WriteLine($"File Name: {file.Key} Word Count: {file.Value}");
            }
            Console.ReadLine();
        }
    }
}
