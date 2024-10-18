//****************************************************************
// DO NOT modify anything in this file *EXCEPT* where marked
// explicitly with TODO comments!
//****************************************************************
namespace GDP_Exam_1
{
    /// <summary>
    /// A standalone class to hold Item object instances
    /// </summary>
    class Inventory
    {
        // NO additional fields are permitted.
        private List<Item> items = new List<Item>();

        /// <summary>
        /// Return the number of items within the
        /// inventory's list. Nothing can be changed.
        /// </summary>
        public int NumberItems
        {
            // TODO: Complete the property
            get 
            {
                return items.Count;
            }
        }

        /// <summary>
        /// TODO: Complete the AddItem method to add a provided Item reference
        /// into the inventory list
        /// </summary>
        public void AddItem(Item itemToAdd)
        {
            items.Add(itemToAdd);
        }

        /// <summary>
        /// TODO: Complete the PrintSummary method to print the number of items
        /// in the inventory and then a summary of each item.
        /// </summary>
        public void PrintSummary()
        {
            Console.WriteLine("The inventory currently has {0} item(s):", NumberItems);
            foreach (Item item in items)
            {
                Console.WriteLine("\t" + item.ToString());
            }

            Console.WriteLine("Total weight: {0}", CalculateTotalWeight());
            Console.WriteLine("Total damage from weapon(s): {0}", CalculateTotalDamage());
        }


        /// <summary>
        /// TODO: Complete the CalculateTotalWeight method to return the total
        /// weight of all items in the inventory
        /// </summary>
        private double CalculateTotalWeight()
        {
            double total = 0;
            foreach (Item item in items)
            {
                total += item.Weight;
            }
            return total;
        }

        /// <summary>
        /// TODO: Complete CalculateTotalWeight method to return the total
        /// damage of all weapons in the inventory
        /// </summary>
        private double CalculateTotalDamage()
        {
            double total = 0;
            foreach (Item item in items)
            {
                if(item is Weapon)
                {
                    Weapon weapon = (Weapon)item;
                    total += weapon.Damage;
                }
            }
            total = Math.Round(total, 2);
            return total;
        }

        /// <summary>
        /// Loads items from a file line by line
        /// </summary>
        public void LoadItems(string filename)
        {
            StreamReader input = null;

            // TODO: Add exception handling
            try
            {
                input = new StreamReader(filename);
                string line = null;
                while((line = input.ReadLine()) != null)
                {
                    // TODO: For each line, seperate the data and create
                    // new Food or Weapon objects appropriately
                    string[] splitData = line.Split('~');

                    if (splitData[0].Equals("Weapon"))
                    {
                        int damage;
                        double weight;
                        bool tryParseDamage = int.TryParse(splitData[2], out damage);
                        bool tryParseWeight = double.TryParse(splitData[3], out weight);

                        // If try parse failed. 
                        if (!tryParseDamage || !tryParseWeight)
                        {
                            Console.WriteLine("Error. Unable to parse file data.");
                        }

                        // else success! can add new weapon. 
                        else
                        {
                            Weapon newWeapon = new Weapon(splitData[1], int.Parse(splitData[2]), double.Parse(splitData[3]));
                            AddItem(newWeapon);
                        }
                    }

                    else if(splitData[0].Equals("Food"))
                    {
                        int servings;
                        double lbsPerServing;
                        bool tryParseServings = int.TryParse(splitData[2], out servings);
                        bool tryParseLbsPerServing = double.TryParse(splitData[3], out lbsPerServing);

                        // If try parse failed. 
                        if (!tryParseServings || !tryParseLbsPerServing)
                        {
                            Console.WriteLine("Error. Unable to parse file data.");
                        }

                        // else success! can add new food. 
                        else
                        {
                            Food newFood = new Food(splitData[1], int.Parse(splitData[2]), double.Parse(splitData[3]));
                            AddItem(newFood);
                        }
                    }

                    // If Weapon or Food are not detected, then print error message.
                    else
                    {
                        Console.WriteLine("Incompatible Type Detected. Must be Weapon or Food.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Uh oh: Could not find file \'{0}\'.", filename);
            }
            if (input != null)
            {
                input.Close();
            }
        }
    }
}
