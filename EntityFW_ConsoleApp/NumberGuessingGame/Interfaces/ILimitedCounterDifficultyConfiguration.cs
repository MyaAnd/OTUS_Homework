using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame.Interfaces
{
    public interface ILimitedCounterDifficultyConfiguration
    {
        int TryCounter { get; set; }
    }
}
