/* Author: Jonathan Benz
 * PE - Magic 8 Ball
 * No known issues */
namespace PE_Magic8Ball_JRB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaring variables
            string owner;
            string choice;
            bool hasQuit = false;

            // Step 1: Getting the owner
            Console.WriteLine("Welcome to Magic 8 Ball Simulator!");
            owner = GetInput("  > Who owns this ball?");

            // Step 2: Instantiating MagicEightBall
            MagicEightBall magicEightBall = new MagicEightBall(owner);

            // Step 3: User controls program choices
            do
            {
                Console.WriteLine("\nWhat would you like to do?");
                choice = GetInput("You can \'shake\' the ball, get a \'report\', or \'quit\':");
                choice = choice.ToLower();

                switch(choice)
                {
                    case "shake":
                        // temp variable. We don't need to save this data. 
                        string question = GetInput("  > What is your question?");
                        Console.WriteLine(magicEightBall.ShakeBall());
                        break;
                    case "report":
                        Console.WriteLine(magicEightBall.Report());
                        break;
                    case "quit":
                        Console.WriteLine("  > Goodbye!");
                        hasQuit = true;
                        break;
                    default:
                        Console.WriteLine("  > I do not recognize that response.");
                        break;
                }
            }
            while (!hasQuit);
        }

        /// <summary>
        /// Helper method to handle input.
        /// </summary>
        /// <param name="prompt"> string prompt to ask the user. </param>
        /// <returns> a string of the user input's input trimmed. </returns>
        private static string GetInput(string prompt)
        {
            Console.Write(prompt + " ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string input = Console.ReadLine();
            input = input.Trim();
            Console.ForegroundColor = ConsoleColor.White;
            return input;
        }
    }
}
