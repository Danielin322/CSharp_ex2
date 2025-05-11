using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
      internal class InputProvider
    {

        public string ReadLine()
        {
            return ReadLine();
        }

        public void GetGuessFromUser(out string o_UserGuess)
        {
            o_UserGuess = ReadLine();
        }

        public void GetMaxGuessInput(out string o_MaxGuessInput)
        {
            o_MaxGuessInput = ReadLine();
        }

        public void GetPlayAgainAnswer(out string o_Answer)
        {
            o_Answer = ReadLine();
        }
    }
}
