/* Author: Jonathan Benz
* PE - Input & Casting
* No known issues */
namespace PE_InputAndParsing_JRB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaring and initializing variables
            string playerName;

            int totalHoursPlayed;
            // Point One X,Y values
            int pointOneX;
            int pointOneY;
            // Point Two X, Y values
            int pointTwoX;
            int pointTwoY;

            double numberA;
            double numberB;

            double angleInDegs;
            double angleInRads;

            // string to temporarily hold input in order to parse. 
            string input;

            // Calculations
            // Addition
            Console.WriteLine("--- ADDITION ---");

            Console.Write("What is the first number? ");
            Console.ForegroundColor = ConsoleColor.Blue;
            input = Console.ReadLine();
            numberA = double.Parse(input);
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("What is the second number? ");
            Console.ForegroundColor = ConsoleColor.Blue;
            input = Console.ReadLine();
            numberB = double.Parse(input);
            Console.ForegroundColor = ConsoleColor.White;

            double doubleSumOfAB = numberA + numberB;
            Console.WriteLine(numberA + " + " + numberB + " = " + doubleSumOfAB);

            int intSumOfAB = (int)numberA + (int)numberB;
            Console.WriteLine("Now I'll add just the whole number parts.");
            Console.WriteLine((int)numberA + " + " + (int)numberB + " = " + intSumOfAB);

            // Division and Modulus
            Console.WriteLine("\n--- DIVISION and MODULUS ---");
            Console.Write("What is that player's name? ");
            Console.ForegroundColor = ConsoleColor.Blue;
            playerName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("How many hours have they logged? ");
            Console.ForegroundColor = ConsoleColor.Blue;
            input = Console.ReadLine();
            totalHoursPlayed = int.Parse(input);
            Console.ForegroundColor = ConsoleColor.White;

            int numOfDays = totalHoursPlayed / 24;
            int numOfHoursLeftover = totalHoursPlayed % numOfDays;
            Console.WriteLine(playerName + " has played a game for " + totalHoursPlayed + " hours.");
            Console.WriteLine("They have played for " + numOfDays + " days and " + numOfHoursLeftover + " hours.");

            // Trig Functions
            Console.WriteLine("\n--- SINE and COSINE ---");
            Console.Write("Enter an angle in degrees: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            input = Console.ReadLine();
            angleInDegs = int.Parse(input);
            angleInRads = angleInDegs * (Math.PI / 180);
            Console.ForegroundColor= ConsoleColor.White;

            Console.WriteLine(angleInDegs + " degrees is " + angleInRads + " radians.");
            Console.WriteLine("The sine is " + Math.Sin(angleInRads));
            Console.WriteLine("The cosine is " + Math.Cos(angleInRads));

            // Distance
            Console.WriteLine("\n--- DISTANCE and ROUNDING ---");
            Console.Write("Enter Point 1 X: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            input = Console.ReadLine();
            pointOneX = int.Parse(input);
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter Point 1 Y: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            input = Console.ReadLine();
            pointOneY = int.Parse(input);
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter Point 2 X: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            input = Console.ReadLine();
            pointTwoX = int.Parse(input);
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter Point 2 Y: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            input = Console.ReadLine();
            pointTwoY = int.Parse(input);
            Console.ForegroundColor = ConsoleColor.White;

            int deltaX = pointOneX - pointTwoX;
            int deltaY = pointOneY - pointTwoY;
            double distance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
            Console.WriteLine("Point One: (" + pointOneX + "," + pointOneY + ")");
            Console.WriteLine("Point Two: (" + pointTwoX + "," + pointTwoY + ")");
            Console.WriteLine("The distance between these points is " + distance);

            // Rounding
            int roundedToWhole = (int)Math.Round(distance, 0);
            double roundedToThousandths = Math.Round(distance, 3);
            Console.WriteLine("The distance is " + distance + ", which is approximately " +
                roundedToWhole + " units, or " + roundedToThousandths + " to be more precise.");
        }
    }
}