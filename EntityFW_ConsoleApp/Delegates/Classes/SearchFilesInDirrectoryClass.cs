using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Classes
{
    public class SearchFilesInDirrectoryClass
    {
        public event EventHandler<FileArgs> FileFoundEvent;

        public SearchFilesInDirrectoryClass()
        {

        }

        public void SearchForFiles(string filePath, List<string> filesToSearch, CancellationToken cancellationToken)
        {
            var filesInDirectory = Directory.GetFiles(filePath, "*.*", SearchOption.TopDirectoryOnly);

            foreach (var file in filesInDirectory)
            {
                string shortName = Path.GetFileName(file);

                if (filesToSearch.Contains(shortName))
                {
                    FileFoundEvent?.Invoke(this, new FileArgs(shortName));
                }

                if (cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("Search was finished prematurely");
                    return;
                }
            }

            Console.WriteLine("Search was finished");
        }
    }
}
