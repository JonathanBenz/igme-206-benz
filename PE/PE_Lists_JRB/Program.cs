/* Author: Jonathan Benz
 * PE - Lists
 * No known issues */
namespace PE_Lists_JRB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaring variables
            Random rng = new Random();
            string player1Name;
            string player2Name;
            Player player1;
            Player player2;

            List<string> stolenItems = new List<string>();
            string userInput;
            bool hasQuit = false;

            // Part 1: Inventory Setup

            Console.Write("Enter player 1's name: ");
            player1Name = Console.ReadLine();
            player1 = new Player(player1Name);

            Console.Write("Enter player 2's name: ");
            player2Name = Console.ReadLine();
            player2 = new Player(player2Name);

            PromptItemsForInventory(rng, player1, player2, 5);
            PrintBothInventories(player1, player2);

            // Part 2: Vendor's Shop
            do
            {
                Console.Write("\nEnter a command (print, steal, or quit) or an item: ");
                userInput = Console.ReadLine();
                userInput = userInput.Trim().ToLower();

                switch(userInput)
                {
                    case "print":
                        PrintBothInventories(player1, player2);
                        break;

                    case "steal":
                        Console.Write("Which player would you like to steal from (1 or 2)? ");
                        int player = int.Parse(Console.ReadLine());

                        if(player == 1)
                        {
                            StealItem(player1, stolenItems);
                        }
                        else if(player == 2)
                        {
                            StealItem(player2, stolenItems);
                        }
                        break;

                    case "quit":
                        Console.WriteLine("You stole {0} item(s):", stolenItems.Count);
                        for(int i = 0; i < stolenItems.Count; i++)
                        {
                            Console.WriteLine("\t- {0}", stolenItems[i]);
                        }
                        hasQuit = true;
                        break;

                    default:
                        double randomNum = rng.NextDouble();

                        if (randomNum > 0.5)
                        {
                            player1.AddToInventory(userInput);
                        }
                        else
                        {
                            player2.AddToInventory(userInput);
                        }
                        break;
                }
            }
            while(!hasQuit);
        }

        /// <summary>
        /// Helper method written by Jonathan Benz.
        /// Prompts the user for items to randomly add to either player1 or player2's inventories.
        /// </summary>
        /// <param name="rng"> Random object needed in order to calculate whether to randomly add item to player1 or player2's inventory. </param>
        /// <param name="player1"> First Player object </param>
        /// <param name="player2"> Second Player object </param>
        /// <param name="iterations"> Integer value representing the amount of times we want to prompt the user for an item. </param>
        private static void PromptItemsForInventory(Random rng, Player player1, Player player2, int iterations)
        {
            Console.WriteLine();
            for(int i = 0; i < iterations; i++)
            {
                Console.Write("Enter an item: ");
                string item = Console.ReadLine();
                double randomNum = rng.NextDouble();

                if(randomNum > 0.5)
                {
                    player1.AddToInventory(item);
                }
                else
                {
                    player2.AddToInventory(item);
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Helper method written by Jonathan Benz. 
        /// Print the players' inventories. 
        /// </summary>
        /// <param name="player1"> First Player object </param>
        /// <param name="player2"> Second Player object </param>
        private static void PrintBothInventories(Player player1, Player player2)
        {
            player1.PrintInventory();
            Console.WriteLine();
            player2.PrintInventory();
        }

        /// <summary>
        /// Helper method written by Jonathan Benz. 
        /// Prompts the user for which item they would like to steal, then prints to the console. 
        /// </summary>
        /// <param name="player"> Player object to steal from. </param>
        /// <param name="stolenItems"> String List of every stolen item. </param>
        private static void StealItem(Player player, List<string> stolenItems)
        {
            Console.Write("Which item # would you like to steal from {0}? ", player.Name);
            int index = int.Parse(Console.ReadLine());
            string stolenItem = player.GetItemInSlot(index);

            if(stolenItem == null)
            {
                Console.WriteLine("{0} was not a valid item #!", index);
            }
            else
            {
                Console.WriteLine("{0} stolen from slot {1} in {2}'s inventory!", stolenItem, index, player.Name);
                stolenItems.Add(stolenItem);
            }
        }
    }
}
