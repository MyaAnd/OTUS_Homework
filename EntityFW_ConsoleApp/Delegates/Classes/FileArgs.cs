using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Classes
{
    public class FileArgs : EventArgs
    {
        public string FoundFileName;

        public FileArgs(string foundFileName) 
        { 
            FoundFileName = foundFileName;
        }
    }
}
