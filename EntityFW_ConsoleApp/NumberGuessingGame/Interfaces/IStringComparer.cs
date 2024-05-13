using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame.Interfaces
{
    public interface IStringComparer
    {
        bool Compare(string s1, string s2);
    }
}
