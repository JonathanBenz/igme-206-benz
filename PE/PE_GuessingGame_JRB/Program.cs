/* Author: Jonathan Benz
 * PE - Guessing Game
 * No known issues */
namespace PE_GuessingGame_JRB
{
    internal class Program
    {
        /// <summary>
        /// Author: Jonathan Benz
        /// Prompts the user for a valid guess.
        /// </summary>
        /// <param name="turnNumber">The turn number</param>
        /// <returns>Returns the user's guess</returns>
        public static int GetGuess(int turnNumber)
        {
            int input = -1;
            bool success = false;
            do
            {
                Console.Write("Turn #{0}: Guess a number between 0 and 100 (inclusive): ", turnNumber);
                Console.ForegroundColor = ConsoleColor.Cyan;
                success = int.TryParse(Console.ReadLine(), out input);
                Console.ForegroundColor = ConsoleColor.White;

                if (!success || input < 0 || input > 100)
                {
                    Console.WriteLine("Invalid guess - try again.\n");
                }
            }
            while (!success || input < 0 || input > 100);
            return input;
        }
        static void Main(string[] args)
        {
            // Declare and initialize variables
            const int MaxGuesses = 8;
            int guess = -1;
            bool guessedCorrectly = false;

            // Create a Random object and then generate + store a random number between 0 and 100
            Random random = new Random();
            int randomNum = random.Next(0, 101);

            Console.WriteLine("{0}\n\n", randomNum);

            // Prompt the user to guess the number at most 8 times
            for (int i = 1; i <= MaxGuesses; i++)
            {
                guess = GetGuess(i);

                // Print if their guess is too low, too high, or correct
                if(guess < randomNum)
                {
                    Console.WriteLine("Too low\n");
                }
                else if(guess > randomNum)
                {
                    Console.WriteLine("Too high\n");
                } 
                else
                {
                    guessedCorrectly = true;
                    Console.WriteLine("\nCorrect! You won in {0} turns.", i);
                    break;
                }
            }

            // If ran out of guesses, print Lose Message.
            if(!guessedCorrectly)
            {
                Console.WriteLine("\nYou ran out of turns. The number was {0}.", randomNum);
            }
        }
    }
}
