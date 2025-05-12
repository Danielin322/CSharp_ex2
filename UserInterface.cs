using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class UserInterface
    {
        private readonly InputProvider m_InputProvider;
        private readonly OutputProvider m_OutputProvider;

        public UserInterface(InputProvider i_InputProvider, OutputProvider i_OutputProvider)
        {
            m_InputProvider = i_InputProvider;
            m_OutputProvider = i_OutputProvider;
        }

        public void GetMaxNumberOfGuesses(out string o_MaxGuesses)
        {
            bool isValid = false;
            
            m_OutputProvider.PrintGuessLimitPrompt();

            do
            {
                m_InputProvider.GetMaxGuessInput(out o_MaxGuesses);

                isValid = GameLogic.IsMaxGuessesValid(o_MaxGuesses);

                if (!isValid)
                {
                    PrintInvalidInputMessage(o_MaxGuesses);
                }

            } while (!isValid);
        }

        public void PrintInvalidInputMessage(string i_Input)
        {
            if (!GameLogic.IsInputNumeric(i_Input))
            {
                m_OutputProvider.PrintInvalidNumberMessage();
            }
            else if(!GameLogic.IsGuessesAmountInRange(i_Input))
            {
                m_OutputProvider.PrintNumberOutOfRangeMessage();
            }
        }

        public void GetGuess(out string o_Guess)
        {
            bool isValid = false;

            do
            {
                m_OutputProvider.PrintGuessPrompt();
                m_InputProvider.GetGuessFromUser(out o_Guess);

                isValid = GameLogic.IsGuessValid(o_Guess);

                if (!isValid)
                {
                    m_OutputProvider.PrintInvalidGuessMessage();
                }

            } while (!isValid);
        }




    }
}
