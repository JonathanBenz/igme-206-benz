/* Author: Jonathan Benz
 * PE - File IO with Classes
 * No known issues */
using System.Drawing;

namespace PE_FileIOWithClasses_JRB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaring variables
            PlayerManager playerManager = new PlayerManager();
            string[] choices = { "create", "print", "save", "load", "quit" };
            bool isQuit = false;

            do
            {
                string userInput = GetPromptedChoice("\nCreate. Print. Save. Load. Quit. >>", choices);
                switch(userInput)
                {
                    case "create":
                        string playerName = GetPromptedInput("\tWhat is the player's name?");
                        int playerStrength = int.Parse(GetPromptedInput("\tPlayer's strength?"));
                        int playerHealth = int.Parse(GetPromptedInput("\tPlayer's health?"));
                        playerManager.CreatePlayer(playerName, playerStrength, playerHealth);
                        break;

                    case "print":
                        playerManager.Print();
                        break;

                    case "save":
                        playerManager.Save();
                        break;

                    case "load":
                        playerManager.Load();
                        break;

                    case "quit":
                        Console.WriteLine("\tGoodbye!");
                        isQuit = true;
                        break;

                    default:
                        break;
                }
            }
            while (!isQuit);
        }

        // Helper Methods

        /// <summary>
        /// CREDIT FOR THIS HELPER METHOD TO PROFESSOR MESH!!! Method slightly modified to use string instead of char. 
        /// Given a reference to an array of possible choices, keep prompting
        /// the user until they enter a valid option
        /// NOTE: Validation assumes lower case choices!
        /// </summary>
        /// <param name="prompt">The prompt to use</param>
        /// <param name="choices">The valid options</param>
        /// <returns>The final valid choice</returns>
        public static string GetPromptedChoice(string prompt, string[] choices)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(prompt + " ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string result = Console.ReadLine(); // Get JUST 1 character
            result = result.Trim().ToLower();
            Console.ForegroundColor = ConsoleColor.White;

            // We haven't taught using Predicates in parameters. There are ways to implement
            // this with what you've learned so far, but I didn't feel like making you worry about
            // anything not related to exceptions or TryParse for this PE.
            // https://learn.microsoft.com/en-us/dotnet/api/system.array.exists?view=net-7.0
            while (!Array.Exists(choices, element => element == result))
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n\tCommand not recognized.\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n" + prompt + " ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                result = Console.ReadLine();
                result = result.Trim().ToLower();
                Console.ForegroundColor = ConsoleColor.White;
            }
            return result;
        }

        /// <summary>
        /// CREDIT FOR THIS HELPER METHOD TO PROFESSOR MESH!!!
        /// Uses the given string to prompt the user for input and set
        /// the color to cyan while they type.
        /// </summary>
        /// <param name="prompt">What to print before waiting for input</param>
        /// <param name="promptColor">The color to use when printing the prompt (defaults to white). 
        /// The user-entered text will always be in cyan.</param>
        /// <returns>A trimmed version of what the user entered</returns>
        public static string GetPromptedInput(string prompt, ConsoleColor promptColor = ConsoleColor.White)
        {
            // Always print in white
            Console.ForegroundColor = promptColor;

            // Print the prompt
            Console.Write(prompt + " ");

            // Switch color and get user input (trim too)
            Console.ForegroundColor = ConsoleColor.Cyan;
            string response = Console.ReadLine().Trim();

            // Switch back to white and then return response.
            Console.ForegroundColor = ConsoleColor.White;
            return response;
        }

    }
}
