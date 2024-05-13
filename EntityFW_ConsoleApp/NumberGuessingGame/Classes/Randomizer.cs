using NumberGuessingGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame.Classes
{
    public class Randomizer : IRandomizer
    {
        public int Randomize(int minRange, int maxRange)
        {
            return Random.Shared.Next(minRange, maxRange + 1);
        }
    }
}
