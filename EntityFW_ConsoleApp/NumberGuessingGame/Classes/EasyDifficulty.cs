using NumberGuessingGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame.Classes
{
    //Interface Segregation Principle
    public class EasyDifficulty : IRangedDifficultyConfiguration
    {
        public string DifficultyName { get; set; } = "Easy";
        public int MinRange { get; set; } = 0;
        public int MaxRange { get; set; } = 10;
    }
}
