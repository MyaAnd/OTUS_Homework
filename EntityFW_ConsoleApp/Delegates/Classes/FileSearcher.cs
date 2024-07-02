using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Classes
{
    public class FileSearcher
    {
        private CancellationTokenSource _tokenSource;

        private void FileFound_Handler(object sender, FileArgs e)
        {
            Console.WriteLine(@"File {0} was found", e.FoundFileName);

            Console.WriteLine(@"Write ""Q"" if you want to stop search or anything else to continue search");

            var answer = Console.ReadLine();

            if (answer == "Q") { _tokenSource.Cancel(); }
        }

        public FileSearcher() 
        { 
            _tokenSource = new CancellationTokenSource();
        }

        public void SearchForFiles(string filePath, List<string> files)
        {
            SearchFilesInDirrectoryClass newSearch = new SearchFilesInDirrectoryClass();
            newSearch.FileFoundEvent += FileFound_Handler;

            newSearch.SearchForFiles(filePath, files, _tokenSource.Token);
        }
    }
}
