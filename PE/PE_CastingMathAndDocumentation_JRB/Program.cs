/* Author: Jonathan Benz
 * PE - Casting, Math & Documentation
 * No known issues */
namespace PE_CastingMathAndDocumentation_JRB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaring and initializing variables
            string playerName = "Johnny McJonnerson";

            int totalHoursPlayed = 274;
            // Point One X,Y values
            int pointOneX = -13;
            int pointOneY = 51;
            // Point Two X, Y values
            int pointTwoX = 17;
            int pointTwoY = 28;

            double numberA = 7.9;
            double numberB = 2.25;

            double angleInDegs = 60;
            double angleInRads = angleInDegs * (Math.PI / 180);

            // Calculations
            // Addition
            double doubleSumOfAB = numberA + numberB;
            Console.WriteLine("--- ADDITION ---");
            Console.WriteLine("Number A: " + numberA);
            Console.WriteLine("Number B: " + numberB);
            Console.WriteLine(numberA + " + " + numberB + " = " + doubleSumOfAB);

            int intSumOfAB = (int)numberA + (int)numberB;
            Console.WriteLine("Now I'll add just the whole number parts.");
            Console.WriteLine((int)numberA + " + " + (int)numberB + " = " + intSumOfAB);

            // Division and Modulus
            int numOfDays = totalHoursPlayed / 24;
            int numOfHoursLeftover = totalHoursPlayed % numOfDays;
            Console.WriteLine("\n--- DIVISION and MODULUS ---");
            Console.WriteLine(playerName + " has played a game for " + totalHoursPlayed + " hours.");
            Console.WriteLine("They have played for " + numOfDays + " days and " + numOfHoursLeftover + " hours.");

            // Trig Functions
            Console.WriteLine("\n--- SINE and COSINE ---");
            Console.WriteLine(angleInDegs + " degrees is " + angleInRads + " radians.");
            Console.WriteLine("The sine is " + Math.Sin(angleInRads));
            Console.WriteLine("The cosine is " + Math.Cos(angleInRads));

            // Distance
            int deltaX = pointOneX - pointTwoX;
            int deltaY = pointOneY - pointTwoY;
            double distance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
            Console.WriteLine("\n--- DISTANCE ---");
            Console.WriteLine("Point One: (" + pointOneX + "," + pointOneY + ")");
            Console.WriteLine("Point Two: (" + pointTwoX + "," + pointTwoY + ")");
            Console.WriteLine("The distance between these points is " + distance);

            // Rounding
            int roundedToWhole = (int)Math.Round(distance, 0);
            double roundedToThousandths = Math.Round(distance, 3);
            Console.WriteLine("\n--- ROUNDING ---");
            Console.WriteLine("The distance is " + distance + ", which is approximately " + 
                roundedToWhole + " units, or " + roundedToThousandths + " to be more precise.");
        }
    }
}
