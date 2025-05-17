using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    public class GameLogic
    {
        private Board m_Board;
        private Guess m_Answer;
        private UserInterface m_UserInterface = new UserInterface();
        private int m_MaxGuesses;

        public GameLogic()
        {
            m_Board = new Board();
            m_Answer = Guess.GenerateAnswer();
            m_UserInterface = new UserInterface();
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

            if (!string.IsNullOrWhiteSpace(i_Input) && (i_Input == "Q"))
            {
                isQuit = true;
            }

            return isQuit;
        }

        public static bool IsGuessesAmountInRange(string i_Guess)
        {
            int.TryParse(i_Guess, out int GuessConvertedToInt);
            return GuessConvertedToInt >= 4 && GuessConvertedToInt <= 10;
        }

        public Result AnalyzeGuess(Guess i_UserGuess)
        {
            int bulls = i_UserGuess.CountBullsAgainst(m_Answer);
            int cows = i_UserGuess.CountCowsAgainst(m_Answer);

            string feedback = buildFeedbackString(bulls, cows);

            return new Result(feedback);
        }

        private string buildFeedbackString(int i_Bulls, int i_Cows)
        {
            StringBuilder feedbackBuilder = new StringBuilder();

            for (int i = 0; i < i_Bulls; i++)
            {
                feedbackBuilder.Append("V ");
            }

            for (int i = 0; i < i_Cows; i++)
            {
                feedbackBuilder.Append("X ");
            }

            return feedbackBuilder.ToString().TrimEnd();
        }

        public void RunGame()
        {
            bool playAgain;
            bool didQuit;

            do
            {
                startNewGame(out didQuit);
                if (didQuit)
                {
                    break;
                }

                playSingleGame(out didQuit);

                if (didQuit)
                {
                    break;
                }

                playAgain = askIfPlayAgain();
            }
            while (playAgain);

            Message.PrintQuitMessage();
        }

        private void startNewGame(out bool o_didQuit)
        {
            m_Board = new Board();
            m_Answer = Guess.GenerateAnswer();

            m_UserInterface.ClearScreen();
            m_UserInterface.GetMaxNumberOfGuesses(out string maxGuessesStr);

            if(maxGuessesStr == "Q")
            {
                o_didQuit = true;
                m_MaxGuesses = 0;
                return;
            }
            o_didQuit = false;
            m_MaxGuesses = int.Parse(maxGuessesStr);
        }

        private void playSingleGame(out bool o_DidQuit)
        {
            int numOfGuesses = 0;
            bool isWin = false;
            o_DidQuit = false;

            while (numOfGuesses < m_MaxGuesses && !isWin)
            {
                m_UserInterface.PrintBoard(m_Board);

                Guess userGuess = m_UserInterface.GetGuess(out o_DidQuit);
                if (o_DidQuit)
                {
                    return;
                }

                Result result = AnalyzeGuess(userGuess);
                m_Board.AddGuessAndResult(userGuess, result);
                numOfGuesses++;

                if (userGuess == m_Answer)
                {
                    isWin = true;
                }
            }

            m_UserInterface.PrintBoard(m_Board);
            printEndMessage(isWin, numOfGuesses);
        }       

        private bool askIfPlayAgain()
        {
            bool wantToPlay;
            Message.PrintPlayAgainPrompt();
            string answer = Console.ReadLine();

            while (answer != "Y" && answer != "N" && answer != "Q")
            {
                Message.PrintInvalidPlayAgain();
                answer = Console.ReadLine();
            }
            if (answer == "Y")
            {
                wantToPlay = true;
            }
            else
            {
                wantToPlay = false;
            }

            return wantToPlay;  

        }

        private void printEndMessage(bool i_IsWin, int i_NumOfGuesses)
        {
            if (i_IsWin)
            {
                Message.PrintWinMessage(i_NumOfGuesses);
            }
            else
            {
                Message.PrintLoseMessage();
                Console.WriteLine($"The correct answer was: {m_Answer}");
            }
        }
    }
}
