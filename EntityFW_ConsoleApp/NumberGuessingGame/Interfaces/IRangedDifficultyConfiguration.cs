using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame.Interfaces
{
    public interface IRangedDifficultyConfiguration
    {
        string DifficultyName { get; set; }
        int MinRange { get; set; }
        int MaxRange { get; set; }
    }
}
