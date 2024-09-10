/* Author: Jonathan Benz
 * PE - Data Types & Variables
 * No Known Issues */
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace PE_DataTypesAndVariables_JRB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaring and initializing all variables
            const int startingPoints = 50;
            string name = "Jonathan Benz";
            double strength = startingPoints * 0.23;
            double dexterity = strength / 2;
            int intelligence = 7;
            double health = (dexterity + intelligence) - 2;
            double charisma = startingPoints - (strength + dexterity + intelligence + health);
            double totalPoints = strength + dexterity + intelligence + health + charisma;

            // Printing out all the statements
            Console.WriteLine("Name: " + name);
            Console.WriteLine();

            Console.WriteLine("Strength: " + strength);
            Console.WriteLine("Dexterity: " + dexterity);
            Console.WriteLine("Intelligence: " + intelligence);
            Console.WriteLine("Health: " + health);
            Console.WriteLine("Charisma: " + charisma);
            Console.WriteLine();

            Console.WriteLine("TOTAL: " + totalPoints);

            
        }
    }
}
