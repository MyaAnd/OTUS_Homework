using NumberGuessingGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame.Classes
{
    public class Game
    {
        private IDifficultySelector DifficultySelector;
        private IRangedDifficultyConfiguration SelectedDifficulty;
        private int TriesCounter;
        private int SecretNumber;

        public Game(IDifficultySelector difSelector)
        {
            DifficultySelector = difSelector;
        }

        public void RunGame()
        {
            //selecting difficulty
            SelectedDifficulty = DifficultySelector.SelectDifficulty();
            TriesCounter = 0;

            //getting condition for premature game ending
            Func<bool> prematureEndingCondition = () => { return true; };
            if (SelectedDifficulty is ILimitedCounterDifficultyConfiguration limitedTriesDifficulty)
            {
                prematureEndingCondition = () => {
                    return TriesCounter < limitedTriesDifficulty.TryCounter;
                };
            }

            //generating secret number
            IRandomizer randomizer = new Randomizer();
            SecretNumber = randomizer.Randomize(SelectedDifficulty.MinRange, SelectedDifficulty.MaxRange);
            
            //writing info about game
            WriteInfo();

            INumberChecker numberChecker = new NumberChecker(SecretNumber);

            Console.WriteLine("Please, enter a number");
            int enteredNumber = 0;
            string number;

            while (prematureEndingCondition())
            {
                number = Console.ReadLine()!;

                while(!Int32.TryParse(number, out enteredNumber))
                {
                    Console.WriteLine("Wasn't able to parse number you entered - please try again");
                    number = Console.ReadLine()!;
                }

                TriesCounter++;

                if (numberChecker.Check(enteredNumber)) break;
            }

            IGameResult result;

            if (prematureEndingCondition())
            {
                result = new WinResult(TriesCounter);
            }
            else
            {
                result = new FailResult(SecretNumber);
            }

            //The Liskov Substitution Principle
            result.PrintResult();
        }

        private void WriteInfo()
        {
            Console.WriteLine($"Guessed number is in range [{SelectedDifficulty.MinRange} ; " +
                $"{SelectedDifficulty.MaxRange}]");

            if (SelectedDifficulty is ILimitedCounterDifficultyConfiguration limitedTriesDifficulty)
            {
                Console.WriteLine($"You have {limitedTriesDifficulty.TryCounter} tries");
            }
        }
    }

    
}
