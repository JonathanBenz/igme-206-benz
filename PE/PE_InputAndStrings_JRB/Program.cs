/* 
 * Author: Jonathan Benz
 * PE - Inputs & Strings
 * No known issues. 
 * Version 2: Did not know if I was allowed to use string interpolation as I did in my first version,
 *            so I updated my strings to use conventional string formatting. 
 */
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
            Console.WriteLine("Welcome {0}!", name);

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
            Console.WriteLine("\nYour name is {0} letters long", name.Length);
            Console.WriteLine("and {0} letters longer than {1}'s name.\n", name.Length - petName.Length, petName);
            Console.WriteLine("I wonder if {0} and {1} like {2} " +
                "as much as you do.\n", petName.ToUpper(), favoriteBand.ToLower(), favoriteColor.ToUpper());
            Console.WriteLine("Maybe I should just call you {0}?", 
                name.ToUpper()[0] + favoriteColor.Substring(0, 2).ToLower() + petName.Substring(0, 2).ToLower() + favoriteBand.Substring(0, 2).ToLower());
        }
    }
}
