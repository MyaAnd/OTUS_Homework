using NumberGuessingGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame.Classes
{
    public class NumberChecker : INumberChecker
    {
        private int SecretNumber;

        public NumberChecker(int secretNumber)
        {
            SecretNumber = secretNumber;
        }

        public bool Check(int number)
        {
            if (number < SecretNumber) { Console.WriteLine($"Secret number is higher than {number}"); };
            if (number > SecretNumber) { Console.WriteLine($"Secret number is lower than {number}"); };

            return number == SecretNumber;
        }
    }
}
