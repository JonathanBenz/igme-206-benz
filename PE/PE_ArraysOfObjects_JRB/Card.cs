/* Author: Jonathan Benz
 * Card Class
 * No known issues */
namespace PE_ArraysOfObjects_JRB
{
    internal class Card
    {
        // Declaring class fields. 
        private int value;
        private string suit;

        /// <summary>
        /// Constructor for instantiating a Card. 
        /// </summary>
        /// <param name="value"> int value of the card from 1-13. </param>
        /// <param name="suit"> string value representing the card's suit. </param>
        public Card(int value, string suit)
        {
            this.value = value;
            this.suit = suit;
        }

        /// <summary>
        /// Prints to the console what value and suit the card is. 
        /// </summary>
        public void Print()
        {
            switch(value)
            {
                case 1:
                    Console.WriteLine("  - Ace of {0}", suit);
                    break;
                case 11:
                    Console.WriteLine("  - Jack of {0}", suit);
                    break;
                case 12:
                    Console.WriteLine("  - Queen of {0}", suit);
                    break;
                case 13:
                    Console.WriteLine("  - King of {0}", suit);
                    break;
                default:
                    Console.WriteLine("  - {0} of {1}", value, suit);
                    break;
            }
        }
    }
}
