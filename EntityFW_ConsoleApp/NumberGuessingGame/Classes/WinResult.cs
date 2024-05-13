using NumberGuessingGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame.Classes
{
    //Open/Close with FailResult
    public class WinResult : IGameResult
    {
        private int TryCount;

        public WinResult(int tryCount) 
        { 
            TryCount = tryCount;
        }

        public void PrintResult()
        {
            Console.WriteLine($"You guessed secret number in {TryCount} tries");
        }
    }
}
