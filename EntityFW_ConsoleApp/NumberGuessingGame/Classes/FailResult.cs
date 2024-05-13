using NumberGuessingGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame.Classes
{
    //Open/Close with WinResult
    public class FailResult : IGameResult
    {
        private int SecretNumber;

        public FailResult(int secretNumber) 
        {
            SecretNumber = secretNumber;
        } 

        public void PrintResult()
        {
            Console.WriteLine($"You failed to guess secret number \nSecret number was \"{SecretNumber}\"");
        }
    }
}
