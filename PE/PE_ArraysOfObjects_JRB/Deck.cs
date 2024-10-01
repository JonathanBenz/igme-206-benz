/* Author: Jonathan Benz
 * Deck Class
 * No known issues */
namespace PE_ArraysOfObjects_JRB
{
    internal class Deck
    {
        // Declaring class fields. 
        private Random rng;
        private Card[] cards;

        public Deck()
        {
            rng = new Random();
            cards = new Card[52];

            CreateCards("Diamonds", cards);
            CreateCards("Clubs", cards);
            CreateCards("Hearts", cards);
            CreateCards("Spades", cards);
        }

        /// <summary>
        /// Prints the whole deck to the console. 
        /// </summary>
        public void Print()
        {
            Console.WriteLine("Your deck:");
            for(int i = 0; i < cards.Length; i++)
            {
                cards[i].Print();
            }
        }

        /// <summary>
        /// Prints out a hand by randomly getting cards from the deck.
        /// </summary>
        /// <param name="amount"> int variable specifying the length of the hand. </param>
        public void Deal(int amount)
        {
            Console.WriteLine("Your hand:");
            for(int i = 0; i < amount; i++)
            {
                int randomIndex = rng.Next(0, cards.Length);
                cards[randomIndex].Print();
            }
        }

        /// <summary>
        /// Helper method to create cards and put them into the cards array. 
        /// </summary>
        /// <param name="suit"> string variable representing the suit of the cards to create. </param>
        /// <param name="cards"> the array of cards to put these cards into. </param>
        private void CreateCards(string suit, Card[] cards)
        {
            // Checks for last placed card index. 
            int lastPlacedIndex = -1;
            for(int i = 0; i < cards.Length; i++)
            {
                if (cards[i] == null)
                {
                    lastPlacedIndex = i;
                    break;
                }
            }

            // Places cards
            for (int i = 0; i < 13; i++)
            {
                Card newCard = new Card(i + 1, suit);
                cards[lastPlacedIndex++] = newCard;
            }
        }
    }
}
