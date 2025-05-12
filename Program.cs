using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class Program
    {
        static int Main()
        {
            InputProvider inputProvider = new InputProvider();
            OutputProvider outputProvider = new OutputProvider();

            UserInterface ui = new UserInterface(inputProvider, outputProvider);
            //string tmp;
            //ui.GetMaxNumberOfGuesses(out tmp);
            //ui.GetGuess(out tmp);
            //Console.WriteLine(tmp);
            return 0;
        }
    }
}
