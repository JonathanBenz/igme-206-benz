/* Author: Jonathan Benz
 * HW2 - Stats Analysis
 * No known issues. */
namespace HW2_StatsAnalysis_JRB
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // Declaring and initializing variables for both players. 
            string p1Name;
            int p1TotalGamesPlayed;
            int p1GamesWon;
            int p1GamesLost;
            double p1HoursPlayed;
            double p1AvgGameTime;
            double p1WinPercentage;

            string p2Name;
            int p2TotalGamesPlayed;
            int p2GamesWon;
            int p2GamesLost;
            double p2HoursPlayed;
            double p2AvgGameTime;
            double p2WinPercentage;

            // Error Validation Variables
            bool errorDetected = false;
            const string error1 = "ERROR: Invalid name for {0}";
            const string error2 = "ERROR: Games & total play time must be non-negative numbers!";
            const string error3 = "ERROR: The number of games won and lost does not match the total number of games played!";
            const string error4 = "ERROR: No stats to calculate for a player with zero games or no play time!!";
            const string errorExitMessage = "\nCannot continue with analysis. Goodbye.";


            Console.WriteLine("========= STATS ANALYZER =========\n");

            // Getting Player 1's input.
            Console.Write("Enter the name for Player 1: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            p1Name = Console.ReadLine();
            p1Name = p1Name.Trim();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter the number of games {0} played: ", p1Name);
            Console.ForegroundColor = ConsoleColor.Cyan;
            p1TotalGamesPlayed = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter the number of games {0} won: ", p1Name);
            Console.ForegroundColor = ConsoleColor.Cyan;
            p1GamesWon = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter the number of games {0} lost: ", p1Name);
            Console.ForegroundColor = ConsoleColor.Cyan;
            p1GamesLost = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter the total time played by {0} in hours: ", p1Name);
            Console.ForegroundColor = ConsoleColor.Cyan;
            p1HoursPlayed = double.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            // Validate Player 1's Input.
            Console.ForegroundColor = ConsoleColor.DarkRed;
            if(p1Name.Length == 0)
            {
                Console.WriteLine(error1, "player 1.");
                errorDetected = true;
            }
            if(p1TotalGamesPlayed < 0 || p1GamesWon < 0 || p1GamesWon < 0 || p1HoursPlayed < 0)
            {
                Console.WriteLine(error2);
                errorDetected = true;
            }
            if((p1GamesWon + p1GamesLost) != p1TotalGamesPlayed)
            {
                Console.WriteLine(error3);
                errorDetected = true;
            }
            // It is a bad idea to compare a double to exactly 0 due to the nature of floating point accuracy
            // so I compare it to less than or equal to 0.01. 
            if(p1TotalGamesPlayed == 0 || p1HoursPlayed <= 0.01)
            {
                Console.WriteLine(error4);
                errorDetected = true;
            }
            if (errorDetected)
            {
                Console.WriteLine(errorExitMessage);
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            Console.ForegroundColor = ConsoleColor.White;

            // Getting Player 2's input.
            Console.Write("Enter the name for Player 2: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            p2Name = Console.ReadLine();
            p2Name = p2Name.Trim();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter the number of games {0} played: ", p2Name);
            Console.ForegroundColor = ConsoleColor.Cyan;
            p2TotalGamesPlayed = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter the number of games {0} won: ", p2Name);
            Console.ForegroundColor = ConsoleColor.Cyan;
            p2GamesWon = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter the number of games {0} lost: ", p2Name);
            Console.ForegroundColor = ConsoleColor.Cyan;
            p2GamesLost = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter the total time played by {0} in hours: ", p2Name);
            Console.ForegroundColor = ConsoleColor.Cyan;
            p2HoursPlayed = double.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            // Validate Player 2's Input.
            Console.ForegroundColor = ConsoleColor.DarkRed;
            if (p2Name.Length == 0)
            {
                Console.WriteLine(error1, "player 2.");
                errorDetected = true;
            }
            if (p2TotalGamesPlayed < 0 || p2GamesWon < 0 || p2GamesWon < 0 || p2HoursPlayed < 0)
            {
                Console.WriteLine(error2);
                errorDetected = true;
            }
            if ((p2GamesWon + p2GamesLost) != p2TotalGamesPlayed)
            {
                Console.WriteLine(error3);
                errorDetected = true;
            }
            // It is a bad idea to compare a double to exactly 0 due to the nature of floating point accuracy
            // so I compare it to less than or equal to 0.01.
            if (p2TotalGamesPlayed == 0 || p2HoursPlayed <= 0.01)
            {
                Console.WriteLine(error4);
                errorDetected = true;
            }
            if (errorDetected)
            {
                Console.WriteLine(errorExitMessage);
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            Console.ForegroundColor = ConsoleColor.White;

            // Analyze the stats
            p1AvgGameTime = p1HoursPlayed * 60 / p1TotalGamesPlayed;
            p1WinPercentage = p1GamesWon * 1.0 / p1TotalGamesPlayed;

            p2AvgGameTime = p2HoursPlayed * 60 / p2TotalGamesPlayed;
            p2WinPercentage = p2GamesWon * 1.0 / p2TotalGamesPlayed;

            // Display the results in a table
            Console.WriteLine("Summary Table:");
            Console.WriteLine("\t\t\t{0} \t{1}", p1Name, p2Name);
            Console.WriteLine("\tGames Played \t{0} \t\t{1}", p1TotalGamesPlayed, p2TotalGamesPlayed);
            Console.WriteLine("\tGames Won \t{0} \t\t{1}", p1GamesWon, p2GamesWon);
            Console.WriteLine("\tGames Lost \t{0} \t\t{1}", p1GamesLost, p2GamesLost);
            Console.WriteLine("\tTotal Time (h) \t{0:F1} \t\t{1:F1}", p1HoursPlayed, p2HoursPlayed);
            Console.WriteLine("\tWin Rate \t{0:P3} \t{1:P3}", p1WinPercentage, p2WinPercentage);
            Console.WriteLine("\tAvg Time (m) \t{0:F0} \t\t{1:F0}", p1AvgGameTime, p2AvgGameTime);
            Console.WriteLine();

            // Display who has the better win percentage
            if(p1WinPercentage > p2WinPercentage)
            {
                Console.WriteLine("{0} has a better win rate!", p1Name);
            }
            else if(p1WinPercentage < p2WinPercentage)
            {
                Console.WriteLine("{0} has a better win rate!", p2Name);
            }
            // else there is a tie
            else
            {
                Console.WriteLine("It's a draw!");
            }
        }
    }
}
