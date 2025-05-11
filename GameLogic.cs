using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    public static class GameLogic
    {
        public static bool IsValidGuessFormat(string i_Input)
        {
            bool isValid = true;

            if (isNullOrEmpty(i_Input))
            {
                isValid = false;
            }
            else
            {
                string guess = removeSpaces(i_Input).ToUpper(); /////case sensitive?

                if (!isCorrectLength(guess))
                {
                    isValid = false;
                }
                else if (!containsOnlyValidLetters(guess))
                {
                    isValid = false;
                }
                else if (hasDuplicateLetters(guess))
                {
                    isValid = false;
                }
            }

            return isValid;
        }

        private static bool isNullOrEmpty(string i_Input)
        {
            return string.IsNullOrWhiteSpace(i_Input);
        }

        private static string removeSpaces(string i_Input)
        {
            return i_Input.Replace(" ", string.Empty);
        }

        private static bool isCorrectLength(string i_Guess)
        {
            return i_Guess.Length == 4;
        }

        /// check and change if case sensitive
        private static bool containsOnlyValidLetters(string i_Guess)
        {
            bool isValid = true;

            foreach (char letter in i_Guess)
            {
                if ((letter < 'A' || letter > 'H'))// case sensitive? add- && (letter < 'a' || letter > 'h'))
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }

        /// check and change if case sensitive
        private static bool hasDuplicateLetters(string i_Guess)
        {
            bool hasDuplicates = false;
            int[] letterCounts = new int[8]; // case sensitive?
            int index = 0;

            foreach (char letter in i_Guess)
            {
                index = letter - 'A'; // case sensitive?
                letterCounts[index]++;

                if (letterCounts[index] > 1)
                {
                    hasDuplicates = true;
                    break;
                }
            }

            return hasDuplicates;
        }
    }
}
