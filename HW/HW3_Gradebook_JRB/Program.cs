/* Author: Jonathan Benz
 * HW3 - Gradebook
 * No known issues */
using System;

namespace HW3_Gradebook_JRB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ---- Activity 1: Getting the Data ----
            // Declaring variables
            int numOfAssignments = -1;
            string[] assignments;
            double[] assignmentGrades;

            string assignmentName = " ";
            double assignmentGrade = 0;

            double sumOfGrades = 0;
            double averageOfGrades = 0;

            int numGradesAboveAvg = 0;
            double maxGrade = 0;
            double minGrade = 999;
            bool hasDuplicates = false;


            // Prompting the user for numOfAssignments
            // Also checks to see if numOfAssignments is a valid number
            Console.Write("How many assignments are you saving? ");
            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                numOfAssignments = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;
                if (numOfAssignments < 1)
                {
                    Console.Write("That is not a valid number. Enter the number of assignments: ");
                }
            }
            while (numOfAssignments < 1);
            Console.WriteLine("You are saving {0} assignments.", numOfAssignments);

            // Initializing the arrays in two seperate ways
            assignments = new string[numOfAssignments];
            assignmentGrades = new double[assignments.Length];

            // Prompting the user for name of assignment and grade received
            for (int i = 0; i < numOfAssignments; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nEnter the name for assignment #{0}: ", i+1);
                Console.ForegroundColor = ConsoleColor.Cyan;
                assignmentName = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("Enter the grade for {0}: ", assignmentName);
                do
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    assignmentGrade = double.Parse(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.White;
                    if (assignmentGrade < 0 || assignmentGrade > 100)
                    {
                        Console.Write("Grade must be between 0 and 100. Enter grade: ");
                    }
                }
                while (assignmentGrade < 0 || assignmentGrade > 100);

                sumOfGrades += assignmentGrade;
                assignments[i] = assignmentName;
                assignmentGrades[i] = assignmentGrade;
            }
            Console.WriteLine("\nAll grades are entered!");

            // ---- Activity 2: Grade Average ----
            // Calculating average
            averageOfGrades = sumOfGrades / numOfAssignments;

            // Printing out grade report
            Console.WriteLine("\nGrade Report:");
            for (int i = 0; i < numOfAssignments;i++)
            {
                Console.WriteLine("  {0}. {1}: {2}", i+1, assignments[i], assignmentGrades[i]);
            }
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Average: {0:F2}\n", averageOfGrades);

            // ----- Activity 3: Grade Replacement -----
            // Prompting the user for an appropriate index in assignmentGrades to replace
            // userIndex will be offset from the actual index of the array by +1. E.g., userIndex of 1 is equal to an index of 0. 
            int userIndex = -1;
            do
            {
                Console.Write("Which number grade do you want to replace? ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                userIndex = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;
                if (userIndex < 1 || userIndex > assignmentGrades.Length)
                {
                    Console.WriteLine("Index must be a number between 1 and {0}. Try again.", assignmentGrades.Length);
                }
            }
            while (userIndex < 1 || userIndex > assignmentGrades.Length);

            // Prompting what the new grade should be. Checking if the new grade is appropriate 
            Console.Write("\nWhat is the new grade for {0}? ", assignments[userIndex - 1]);
            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                assignmentGrade = double.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;
                if (assignmentGrade < 0 || assignmentGrade > 100)
                {
                    Console.Write("Grade must be between 0 and 100. Enter grade: ");
                }
            }
            while (assignmentGrade < 0 || assignmentGrade > 100);

            // Replacing the grade
            Console.WriteLine("\nReplacing the grade at index {0} with {1}", userIndex, assignmentGrade);
            assignmentGrades[userIndex - 1] = assignmentGrade;

            // ----- Activity 4: Print Final Summary -----
            // Reprinting and recalculating everything from Activity 2. 
            // *I am not sure if I would get points taken off for using a method
            // but all of this redundant code is killing my soul.*

            // Recalculating sum of grades
            sumOfGrades = 0;
            for (int i = 0; i < assignmentGrades.Length; i++)
            {
                sumOfGrades += assignmentGrades[i];
            }

            // Recalculating average
            averageOfGrades = sumOfGrades / numOfAssignments;

            // Printing out grade report
            Console.WriteLine("\nFinal Grade Report:");
            for (int i = 0; i < numOfAssignments; i++)
            {
                Console.WriteLine("  {0}. {1}: {2}", i + 1, assignments[i], assignmentGrades[i]);
            }
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Final average: {0:F2}\n", averageOfGrades);

            // ----- Activity 5: Analyze and Report! -----
            // Finding how many grades were above average
            for(int i = 0; i < assignmentGrades.Length; i++)
            {
                if (assignmentGrades[i] > averageOfGrades)
                {
                    numGradesAboveAvg++;
                }
            }
            Console.WriteLine("{0} grades are above average.\n", numGradesAboveAvg);

            // Finding the lowest and highest values in the array
            for (int i = 0; i < assignmentGrades.Length; i++)
            {
                if (assignmentGrades[i] > maxGrade)
                {
                    maxGrade = assignmentGrades[i];
                }
                if (assignmentGrades[i] < minGrade)
                {
                    minGrade = assignmentGrades[i];
                }
            }
            Console.WriteLine("The highest grade is {0}.", maxGrade);
            Console.WriteLine("The lowest grade is {0}\n", minGrade);

            // Finding duplicates
            for (int i = 0; i < assignmentGrades.Length; i++)
            {
                for (int j = 0;  j < assignmentGrades.Length; j++)
                {
                    if (i == j)
                    {
                        j++;
                    }
                    else if (assignmentGrades[i] == assignmentGrades[j])
                    {
                        hasDuplicates = true;
                    }
                }
            }

            // Print out final result
            if (hasDuplicates)
            {
                Console.WriteLine("A grade appears more than once in this set of grades.");
            }
            else
            {
                Console.WriteLine("All grades are unique.");
            }
        }
    }
}
