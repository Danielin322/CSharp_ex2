using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class OutputProvider
    {

        public void PrintBoard(List<string> i_Guesses, List<string> i_Results, int i_MaxGuesses)
        {
            PrintStartOfBoard();

            for (int i = 0; i < i_MaxGuesses; i++)
            {
                bool isRowFilled = i < i_Guesses.Count;

                if (isRowFilled)
                {
                    string[] pins = i_Guesses[i].Split(' ');
                    //printGuessRow(pins);
                }
                else
                {
                    PrintEmptyRow();
                }
                Console.WriteLine("|=========|=========|");
            }
        }

        public void PrintGuessRow(string[] i_Pins, string[] i_Result) // to keep []?
        {
            StringBuilder rowBuilder = new StringBuilder();
            
            rowBuilder.Append("| ");
            rowBuilder.Append(i_Pins);
            rowBuilder.Append(" |");
            //PrintResults()
            rowBuilder.Append('|');

            Console.WriteLine(rowBuilder.ToString());
        }

        public void PrintResults(string i_Result)
        {
            string spacedResults = string.Join(" ", i_Result);
            Console.WriteLine(spacedResults);
        }

        public void PrintEmptyRow()
        {
            Console.WriteLine("|         |       |");
        }

        public void PrintStartOfBoard()
        {
            Console.WriteLine("|Pins:    |Result:|");
            Console.WriteLine("|=========|=========|");
            Console.WriteLine("| # # # # |       |");
            Console.WriteLine("=========|=========|");
        }


        public void PrintGuessLimitPrompt() ////////
        {
            Console.Write("Please enter the maximum number of guesses (between 4 and 10), or '' to quit: ");
        }

        public void PrintInvalidNumberMessage() ////////
        {
            Console.WriteLine("Invalid input. Please enter a number between 4 and 10 or 'Q' to quit");
        }

        public void PrintNumberOutOfRangeMessage() ///////
        {
            Console.WriteLine("Number out of range. Please enter a number between 4 and 10 or 'Q' to quit");
        }

        public void PrintQuitMessage() ////////
        {
            Console.WriteLine("Thanks for playing! Goodbye.");
        }

        public void PrintGuessPrompt() ///////
        {
            Console.WriteLine("Please type yout next guess <A B C D> or 'Q' to quit");
        }

        public void PrintInvalidGuessMessage()
        {
            Console.WriteLine("Invalid guess input. Make sure it's 4 different letters from A to H");
        }

        public void PrintGuessOutOfRangeMessage() ///////
        {
            Console.WriteLine("Guess out of range. Make sure it's 4 different letters from A to H");
        }

        public void PrintWinMessage(int i_AmountOfSteps) /////
        {
            Console.WriteLine($"You guessed after {i_AmountOfSteps} steps!");
            PrintPlayAgainPrompt();
        }

        public void PrintLoseMessage() ///////
        {
            Console.WriteLine("No more guesses allowed. You Lost.");
            PrintPlayAgainPrompt();
        }

        public void PrintPlayAgainPrompt() /////
        {
            Console.WriteLine("Would you like to start a new game? <Y/N>");
        }

        public void ClearScreen()
        {
            Ex02.ConsoleUtils.Screen.Clear();
        }
    }
}
