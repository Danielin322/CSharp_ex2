using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    public static class GameLogic
    {
        //public static bool IsInput(string i_Input)
        //{

        //}




        public static bool IsGuessValid(string i_Input)
        {
            bool isValid = true;

            if (isNullOrEmpty(i_Input))
            {
                isValid = false;
            }
            else
            {
                string guess = removeSpaces(i_Input).ToUpper(); /////case sensitive?

                if (!isGuessCorrectLength(guess))
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

        private static bool isGuessCorrectLength(string i_Guess)
        {
            return i_Guess.Length == 4;
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

        private static string removeSpaces(string i_Input)
        {
            return i_Input.Replace(" ", string.Empty);
        }





        public static bool IsMaxGuessesValid(string i_Input)
        {
            bool isValid = false;

            if (IsInputQuitCommand(i_Input))
            {
                isValid = true;
            }
            else if(IsInputNumeric(i_Input) && IsNumaricInputValid(i_Input))
            {
                isValid = true;

            }
            return isValid;
        }


        public static bool IsInputNumeric(string i_Input)
        {
            int temp;
            return int.TryParse(i_Input, out temp);
        }

        public static bool IsNumaricInputValid(string i_Input)
        {
             return IsGuessesAmountInRange(i_Input);
        }


        





        public static bool IsInputQuitCommand(string i_Input)
        {
            bool isQuit = false;

            if (!string.IsNullOrWhiteSpace(i_Input))
            {
                isQuit = i_Input.Trim().ToUpper() == "Q";
            }

            return isQuit;
        }

        public static bool IsGuessesAmountInRange(string i_Guess)
        {
            int.TryParse(i_Guess, out int GuessConvertedToInt);
            return GuessConvertedToInt >= 4 && GuessConvertedToInt <= 10;
        }


        
    }
}
