using Ex02.ConsoleUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    public class UserInterface
    {
        

        public void GetMaxNumberOfGuesses(out string o_MaxGuesses)
        {
            bool isValid;
            
            Message.PrintGuessLimitPrompt();

            do
            {
                o_MaxGuesses = Console.ReadLine();

                isValid = GameLogic.IsMaxGuessesValid(o_MaxGuesses);

                if (!isValid)
                {
                    PrintInvalidMaxInputMessage(o_MaxGuesses);
                }

            } while (!isValid);
        }

        public void PrintInvalidMaxInputMessage(string i_Input)
        {
            if (!GameLogic.IsInputNumeric(i_Input))
            {
                Message.PrintInvalidNumberMessage();
            }
            else if(!GameLogic.IsGuessesAmountInRange(i_Input))
            {
                Message.PrintNumberOutOfRangeMessage();
            }
        }

        public Guess GetGuess(out bool o_IsQuit)
        {
            bool isValid;
            string guessInput;

            do
            {
                Message.PrintGuessPrompt();
                guessInput = Console.ReadLine();

                if(GameLogic.IsInputQuitCommand(guessInput))
                {
                    o_IsQuit = true;
                    break;
                }

                isValid = Guess.IsInputGuessValid(guessInput);

                if (!isValid)
                {
                    Message.PrintInvalidGuessMessage();
                }

                o_IsQuit= false;

            } while (!isValid);

            return new Guess(guessInput);
        }

        public void ClearScreen()
        {
            Ex02.ConsoleUtils.Screen.Clear();
        }

        public void PrintBoard(Board i_Board)
        {
            Screen.Clear();
            string boardString = i_Board.CreateBoardToString();
            Console.WriteLine(boardString);
        }




    }
}
