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
            GameLogic game = new GameLogic();
            game.RunGame();

            //Board board = new Board();
            //Guess guess = new Guess ("A B C D");
            //Result res = new Result ("V V X X");
            //board.AddGuessAndResult(guess, res);
            //UserInterface.PrintBoard(board);
            //UserInterface ui = new UserInterface(inputProvider, outputProvider);
            //string tmp;
            //ui.GetMaxNumberOfGuesses(out tmp);
            //ui.GetGuess(out tmp);
            //Console.WriteLine(tmp);
            return 0;
        }
    }
}
