/* Author: Jonathan Benz
 * PE - Static Helper Methods
 * No known issues */
namespace PE_StaticHelperMethods_JRB
{
    internal class Program
    {
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // LEAVE THE REST OF THE CODE ALONE!
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        /// <summary>
        /// Helper written by Prof. Mesh
        /// Check if one number is a factor of another value
        /// </summary>
        /// <param name="factor">The factor to test</param>
        /// <param name="value">The value to check</param>
        /// <returns>True if value can be evenly divided by the factor</returns>
        public static bool IsFactorOf(int factor, int value)
        {
            // Return true if "factor" is smaller than "value"
            // and is evenly divisible into "value"
            return factor < value && value % factor == 0;
        }


        /// <summary>
        /// Input helper written by Prof. Mesh
        /// Uses the given string to prompt the user for input and set
        /// the color to cyan while they type.
        /// </summary>
        /// <param name="prompt">What to print before waiting for input</param>
        /// <returns>A trimmed version of what the user entered</returns>
        public static string GetPromptedInput(string prompt)
        {
            // Always print in white
            Console.ForegroundColor = ConsoleColor.White;

            // Print the prompt
            Console.Write(prompt + " ");

            // Switch color and get user input (trim too)
            Console.ForegroundColor = ConsoleColor.Cyan;
            string response = Console.ReadLine().Trim();

            // Switch back to white and then return response.
            Console.ForegroundColor = ConsoleColor.White;
            return response;
        }
        /// <summary>
        /// Helper written by Jonathan Benz
        /// Prints out if the numbers are awesome or okay 
        /// depending on if they're factors or not.  
        /// </summary>
        /// <param name="a"> The first number prompted by the user</param>
        /// <param name="b"> The second number prompted by the user</param>
        public static void CheckNumbers(int a, int b)
        {
            if(IsFactorOf(a, b) || IsFactorOf(b, a))
            {
                Console.WriteLine("{0} & {1} are awesome numbers.", a, b);
            }
            else
            {
                Console.WriteLine("{0} & {1} are okay I guess.", a, b);
            }
        }
        /// <summary>
        /// Helper written by Jonathan Benz
        /// Prints out a secret code based on the data given by the user. 
        /// </summary>
        /// <param name="name"> The user's name</param>
        /// <param name="a"> The first number prompted by the user</param>
        /// <param name="b"> The second number prompted by the user</param>
        /// <returns></returns>
        public static int GetSecretCode(string name, int a, int b)
        {
            return (int)(Math.Sqrt(a) + Math.Pow(a, b) - name.Length) - name[0];
        }
        /// <summary>
        /// Helper written by Jonathan Benz. Prints out a summary of all the 
        /// processed information of the user. 
        /// </summary>
        /// <param name="name"> The user's name</param>
        /// <param name="a"> The first number prompted by the user</param>
        /// <param name="b"> The second number prompted by the user</param>
        public static void PrintAllInfo(string name, int a, int b)
        {
            Console.WriteLine("Your name is {0},", name.ToUpper());
            Console.WriteLine("\tyour favorite numbers are {0} and {1},", a, b);
            Console.WriteLine("\tand your secret code is {0}.", GetSecretCode(name, a, b));
        }
        static void Main(string[] args)
        {
            // Setup variables
            string name = "";
            int a = 0;
            int b = 0;
            int choice = 0;

            // Get values for name, a, and b using GetPromptedInput and parsing if needed.
            // Fyi, lines that begin with // TODO: will appear in a VS task list for you!
            // https://docs.microsoft.com/en-us/visualstudio/ide/using-the-task-list
            // TODO: ADD YOUR USER INPUT CODE HERE
            name = GetPromptedInput("What is your name?");
            a = int.Parse(GetPromptedInput("Enter a whole number:"));
            b = int.Parse(GetPromptedInput("Enter another whole number:"));

            // Reformat the name
            name = name[0].ToString().ToUpper() + name.Substring(1, name.Length - 1).ToLower();

            // Print the menu
            Console.WriteLine("\nHello {0}, what would you like to do?\n" +
                "\t1 - Compare numbers\n" +
                "\t2 - Get my secret code\n" +
                "\t3 - Output all info",
                name);
            choice = int.Parse(GetPromptedInput(">"));
            Console.WriteLine();

            // Figure out what to do and do it
            switch (choice)
            {
                // Check numbers
                case 1:
                    // TODO: ADD YOUR CODE HERE
                    CheckNumbers(a, b);
                    break;

                // Get secret code
                case 2:
                    // TODO: ADD YOUR CODE HERE
                    Console.WriteLine(GetSecretCode(name, a, b));
                    break;

                // Output all info
                case 3:
                    // TODO: ADD YOUR CODE HERE
                    PrintAllInfo(name, a, b);
                    CheckNumbers(a, b);
                    break;

                // Say goodbye for invalid choices
                default:
                    Console.WriteLine("That wasn't a valid choice. Goodbye.");
                    break;
            }
        }
    }
}
