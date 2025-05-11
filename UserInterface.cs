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

        public void GetMaxNumberOfGuesses(out int o_MaxGuesses)
        {
            bool isValid = false;
            string input;

            o_MaxGuesses = 0;

            while (!isValid)
            {
                m_OutputProvider.PrintGuessLimitPrompt();
                m_InputProvider.GetMaxGuessInput(out input);

                if (GameLogic.IsQuitCommand(input))
                {
                    m_OutputProvider.PrintQuitMessage();
                    o_MaxGuesses = -1;
                }
                else if (!GameLogic.IsNumericGuessLimitInput(input))
                {
                    m_OutputProvider.PrintInvalidNumberMessage();
                }
                else if (!GameLogic.IsGuessInRange(o_MaxGuesses))
                {
                    m_OutputProvider.PrintNumberOutOfRangeMessage();
                }
                else
                {
                    isValid = true;
                }
            }
        }


    }
}
