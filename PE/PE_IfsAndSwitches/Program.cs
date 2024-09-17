/* Author: Jonathan Benz
 * PE - If's & Switches
 * No known issues */
namespace PE_IfsAndSwitches
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaring variables
            int answer1;
            int answer2A;
            int answer2B;
            int answer2C;
            string answer3;

            // Asking the first question 
            Console.Write("What is 6 * 7? ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            answer1 = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            // Checking if it is correct
            if (answer1 == 42)
            {
                Console.WriteLine("That's correct!");
            }
            else
            {
                Console.WriteLine("Nope :(");
            }

            // Asking the second question
            Console.WriteLine("\n\nEnter 3 whole numbers in *ascending* order:");
            Console.Write("1:  ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            answer2A = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("2:  ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            answer2B = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("3:  ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            answer2C = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            // Checking if it is correct
            if (answer2A < answer2B && answer2B < answer2C)
            {
                Console.WriteLine("That's correct!");
            }
            else if (answer2A > answer2B && answer2B > answer2C)
            {
                Console.WriteLine("That's backwards!");
            }
            else
            {
                Console.WriteLine("What?!");
            }

            // Asking the third question
            Console.WriteLine("\n\nSwitches are best for...");
            Console.WriteLine("\ta. Checking for the status of a combination of variables");
            Console.WriteLine("\tb. Checking for different discrete values of the same variable");
            Console.WriteLine("\tc. Checking if a variable's value is within a certain range");
            Console.WriteLine("\td. All of the above\n\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            answer3 = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            // Checking if it is true in a switch statement
            switch (answer3)
            {
                case "b":
                    Console.WriteLine("Correct!");
                    break;
                case "a":
                case "c":
                case "d":
                    Console.WriteLine("Sorry. That's incorrect. Switches are best for checking " +
                        "for different *discrete values* of the *same* variable.");
                    break;
                default:
                    Console.WriteLine("That wasn't even an option!");
                    break;
            }
        }
    }
}
