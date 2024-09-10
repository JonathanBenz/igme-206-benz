/* Author: Jonathan Benz
 * PE - Inputs & Strings
 * No known issues. */
namespace PE_InputAndStrings_JRB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaring our variables to be used. 
            string name;
            string favoriteColor;
            string petName;
            string favoriteBand;

            // Asking the user four different prompts. 
            Console.Write("What is your name? ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Welcome {name}!");

            Console.Write("What is your favorite color? ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            favoriteColor = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("What is your pet's name? ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            petName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("What is your favorite band? ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            favoriteBand = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            // Analyzing the information
            Console.WriteLine($"\nYour name is {name.Length} letters long");
            Console.WriteLine($"and {(name.Length - petName.Length)} letters longer than {petName}'s name.\n");
            Console.WriteLine($"I wonder if {petName.ToUpper()} and {favoriteBand.ToUpper()} like {favoriteColor.ToUpper()} " +
                $"as much as you do.\n");
            Console.WriteLine($"Maybe I should just call you " +
                $"{name.ToUpper()[0] + favoriteColor.Substring(0, 2).ToLower() + petName.Substring(0, 2).ToLower() + favoriteBand.Substring(0, 2).ToLower()}?");
        }
    }
}
