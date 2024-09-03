/* Jonathan Benz
 * PE - Statements & Expressions
 * No known issues
 */
namespace PE_StatementsExpressions_JRB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Write character name and a blank line for extra space
            Console.WriteLine("Name: Jonathan Benz");
            Console.WriteLine();

            // First stat is 20% of 50
            Console.WriteLine("First Stat: " + 50 * 0.2f);
            // Second stat is 50% of the First Stat
            Console.WriteLine("Second Stat: " + (50 * 0.2f) * 0.5f);
            // Third stat is always 7
            Console.WriteLine("Third Stat: 7");
            // Fourth stat is the sum of the second and third states, minus 2
            Console.WriteLine("Fourth Stat: " + ((((50 * 0.2f) * 0.5f) + 7) - 2));
            // Fifth stat is 50 - the rest
            Console.WriteLine("Fifth Stat: " +
                (50 -
                    ((50 * 0.2f) +                      // First stat
                     ((50 * 0.2f) * 0.5f) +             // Second stat
                     (7) +                              // Third stat
                     (((((50 * 0.2f) * 0.5f) + 7) - 2)) // Fourth stat
                     )
                    )
                );

            // Put a blank space for extra space and the total points at the end
            Console.WriteLine();
            Console.WriteLine("Total Points: 50");
        }
    }
}
