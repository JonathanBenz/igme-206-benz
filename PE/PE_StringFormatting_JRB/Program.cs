/* Author: Jonathan Benz
 * PE - String Formatting
 * No known issues. */
namespace PE_StringFormatting_JRB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // String template used throughout the program
            const string StatsUpdateTemplate = "{0}, you now have {1} health and {2:C2} remaining.";

            // Declaring and initializing variables
            string name = "";
            string title = "";
            string nameWithTitle = "";
            int health = 100;
            double wallet = 0.00;

            string action = "";
            int actionHealthReq = 0;
            string item = "";
            double itemCost = 0;

            // Player Input and Greeting
            Console.Write("What is your name brave adventurer? ");
            Console.ForegroundColor = ConsoleColor.Blue;
            name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("What is your title? ");
            Console.ForegroundColor = ConsoleColor.Blue;
            title = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("How much money are you carring? $");
            Console.ForegroundColor = ConsoleColor.Blue;
            wallet = double.Parse(Console.ReadLine());
            Console.ForegroundColor= ConsoleColor.White;

            nameWithTitle = String.Format("{0} the {1}", name, title);
            Console.WriteLine("Welcome {0}!", nameWithTitle);

            // The player performs an action
            Console.Write("\nWhat do you want to do next? ");
            Console.ForegroundColor = ConsoleColor.Blue;
            action = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("How much health does it take to do this? ");
            Console.ForegroundColor = ConsoleColor.Blue;
            actionHealthReq = int.Parse(Console.ReadLine());
            health -= actionHealthReq;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\nOkay, let's see you {0}!", action);
            Console.WriteLine(StatsUpdateTemplate, nameWithTitle, health, wallet);

            // The player buys something
            Console.Write("\nWhat do you want to buy? ");
            Console.ForegroundColor = ConsoleColor.Blue;
            item = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("How much does it normally cost? ");
            Console.ForegroundColor = ConsoleColor.Blue;
            itemCost = double.Parse(Console.ReadLine()) * 1.1;
            wallet -= itemCost;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\nYou bought {0} for {1:C3}!", item, itemCost);
            Console.WriteLine(StatsUpdateTemplate, nameWithTitle, health, wallet);
        }
    }
}
