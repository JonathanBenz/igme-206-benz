/* Author: Jonathan Benz
 * PE - Arrays of Objects
 * No known issues */
namespace PE_ArraysOfObjects_JRB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaring variables.
            int handSize;

            // Printing deck.
            Deck deck = new Deck();
            deck.Print();
            Console.WriteLine();

            // Printing random hand.
            Console.Write("Enter a number of cards to deal (1 - 52): ");
            handSize = int.Parse(Console.ReadLine());
            Console.WriteLine();

            deck.Deal(handSize);
        }
    }
}
