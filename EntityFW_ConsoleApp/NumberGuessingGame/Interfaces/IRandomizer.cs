using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame.Interfaces
{
    //Single Responsibility
    public interface IRandomizer
    {
        int Randomize(int minRange, int maxRange);
    }
}
