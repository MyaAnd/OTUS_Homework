using NumberGuessingGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NumberGuessingGame.Classes
{
    public class DifficultySelector : IDifficultySelector
    {
        IEnumerable<IRangedDifficultyConfiguration> Difficulties;

        public DifficultySelector(IEnumerable<IRangedDifficultyConfiguration> difficulties)
        {
            Difficulties = difficulties;
        }

        public IRangedDifficultyConfiguration SelectDifficulty()
        {
            Console.WriteLine("Please, select from available difficulties by writing its name:");
            foreach (var difficulty in Difficulties)
            {
                Console.WriteLine($"-{difficulty.DifficultyName}");
            }

            string selectedDifficulty = Console.ReadLine()!;

            IRangedDifficultyConfiguration? selectedDifficultyConfiguration = Difficulties.FirstOrDefault
                (el => el.DifficultyName.ToLower() == selectedDifficulty.ToLower());

            while (selectedDifficultyConfiguration == null)
            {
                Console.WriteLine("Wasn't able to parse selected difficulty, please try again");

                selectedDifficulty = Console.ReadLine()!;

                selectedDifficultyConfiguration = Difficulties.FirstOrDefault
                (el => el.DifficultyName.ToLower() == selectedDifficulty.ToLower());
            }

            return selectedDifficultyConfiguration;
        }
    }
}
