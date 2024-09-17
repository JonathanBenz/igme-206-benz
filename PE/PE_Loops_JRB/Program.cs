/* Author: Jonathan Benz
 * PE - Loops
 * No known issues */
namespace PE_Loops_JRB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaring variables
            int iteration;
            int width;
            int height;

            // PART ONE
            Console.WriteLine("+++++ PART ONE +++++");

            // Looping from 0 to 5 with a while loop
            Console.WriteLine("Using a while loop:");
            iteration = 0;
            while(iteration < 6)
            {
                Console.WriteLine(iteration++);
            }
            Console.WriteLine();

            // Using do while loop to descend from 100 to 95
            Console.WriteLine("Using a do while loop:");
            iteration = 100;
            do
            {
                Console.WriteLine(iteration--);
            }
            while (iteration > 94);
            Console.WriteLine();

            // Printing out multiples of 5 using a for loop
            Console.WriteLine("Using a for loop:");
            for (int i = 0; i < 30; i += 5)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            // PART TWO
            Console.WriteLine("+++++ PART TWO +++++");

            // Prompting for dimensions of the box
            Console.Write("Enter a width: ");
            width = int.Parse(Console.ReadLine());
            Console.Write("Enter a height: ");
            height = int.Parse(Console.ReadLine());

            // Drawing the rectangle
            Console.WriteLine("Drawing your rectangle:\n");
            // For each row... 
            for (int i = 0; i < height; i++)
            {
                // Draw the columns...
                for (int j = 0; j < width; j++)
                {
                    Console.Write("O");
                }
                // Then move onto the next row... Repeat
                Console.WriteLine();
            }

            // Drawing just the border
            Console.WriteLine("Drawing your border:\n");

            // For each row... 
            for (int i = 0; i < height; i++)
            {
                // Draw the columns...
                for (int j = 0; j < width; j++)
                {
                    // Checking for edges
                    if ((i != 0 && i != height - 1) && (j != 0 && j != width - 1))
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("O");
                    }
                }
                // Then move onto the next row... Repeat
                Console.WriteLine();
            }
        }
    }
}
