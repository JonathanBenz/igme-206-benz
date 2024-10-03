/* Author: Jonathan Benz
 * Player Class
 * No known issues */
namespace PE_Lists_JRB
{
    internal class Player
    {
        // Declaring Fields
        private string name;
        private List<string> inventory;

        // Properties
        public string Name { get { return name; } }

        // Constructor
        public Player(string name)
        {
            this.name = name;
            inventory = new List<string>();
        }

        // Methods

        /// <summary>
        /// Adds an item to the inventory list and prints to console. 
        /// </summary>
        /// <param name="item"></param>
        public void AddToInventory(string item)
        {
            inventory.Add(item);
            Console.WriteLine("Item \'{0}\' added to {1}'s inventory.", item, name);
        }

        /// <summary>
        /// Removes the item from the list and returns it. 
        /// </summary>
        /// <param name="index"> Integer index used for the list. </param>
        /// <returns> Removed item. </returns>
        public string GetItemInSlot(int index)
        {
            if (index < 0 || index >= inventory.Count)
            {
                return null;
            }
            else
            {
                string removedItem = inventory[index];
                inventory.RemoveAt(index);
                return removedItem;
            }
        }

        /// <summary>
        /// Prints, line by line, the contents of the inventory list. 
        /// </summary>
        public void PrintInventory()
        {
            Console.WriteLine("{0}'s Inventory:", name);
            for (int i = 0; i < inventory.Count; i++)
            {
                Console.WriteLine("\t- {0}", inventory[i]);
            }
        }
    }
}
