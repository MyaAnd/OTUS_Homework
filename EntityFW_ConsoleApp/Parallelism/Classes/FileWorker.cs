using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallelism.Classes
{
    public static class FileWorker
    {
        public static async Task<string> ReadFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        public static async Task<int> CalculateSpaces(string text)
        {
            return text.Count(el => el == ' ');
        }

        public static async Task<int> ReadFileAndCalculateSpaces(string filePath)
        {
            string text = await ReadFile(filePath);
            return await CalculateSpaces(text);
        }

        public static async Task<int> ReadFilesFromDirectoryAndCalculateSpaces(string dirPath)
        {
            var filesInDirectory = Directory.GetFiles(dirPath, "*.*", SearchOption.TopDirectoryOnly);

            int totalSpaces = 0;

            Parallel.ForEach(filesInDirectory, file =>
            {
                int spacesInFile = ReadFileAndCalculateSpaces(file).Result;
                Console.WriteLine(@"Total spaces in file {0} is {1}", file, spacesInFile);
                totalSpaces += spacesInFile;
            });

            Console.WriteLine(@"Total spaces in files of direactory {0} is {1}", dirPath, totalSpaces);
            return totalSpaces;
        }
    }
}
