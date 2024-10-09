/* Author: Jonathan Benz
 * Farm Class
 * No known issues */
namespace HW5_TheFarmstead_JRB
{
    internal class Farm
    {
        // Declaring fields and properties
        private string farmName;
        private double currentMoney;
        private double maintenanceCost;
        private Crop[] availableCrops;
        private Crop[] currentCrops;
        private Random rng;
        private int daysPassed;

        public double Money
        {
            get { return currentMoney; }
            set { currentMoney = value; }
        }
        public string Name
        {
            get { return farmName; }
            set { farmName = value; }
        }

        public bool HasEmptyFields
        {
            get
            {
                if(currentCrops.Contains(null))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        // Constructor
        public Farm(string farmName, Crop[] availableCrops,  int numFields, double startingMoney, double maintenanceCost)
        {
            this.farmName = farmName;
            this.availableCrops = availableCrops;
            currentCrops = new Crop[numFields];
            currentMoney = startingMoney;
            this.maintenanceCost = maintenanceCost;
            rng = new Random();
            daysPassed = 1;
        }

        // Methods

        /// <summary>
        /// Decrements money by the maintenance cost, rolls for a random weather event, and then passes the day. 
        /// </summary>
        public void DayPassed()
        {
            currentMoney -= maintenanceCost;
            
            double randomPercentage = rng.NextDouble();
            // Blight Weather Condition
            if(randomPercentage <= 0.05)
            {
                Console.WriteLine();
                SmartConsole.PrintError("Blight has struck the farm!");
                SmartConsole.PrintError("ALL our crops are dead! :(");

                // Reset the growth time and get rid of the crop. 
                for(int i = 0; i < currentCrops.Length; i++)
                {
                    if (currentCrops[i] != null)
                    {
                        currentCrops[i].DaysLeft = currentCrops[i].GrowthTime;
                        currentCrops[i] = null;
                    }
                }
            }
            // Rain Weather Condition
            else if(randomPercentage <= .20)
            {
                Console.WriteLine();
                SmartConsole.PrintWarning("It rained. Nothing grew today.");
                SmartConsole.PrintWarning("Hopefully tomorrow will be better.");
            }
            // No weather means the crops decrement their days left to harvest
            else
            {
                for (int i = 0; i < currentCrops.Length; i++)
                {
                    if (currentCrops[i] != null)
                    {
                        currentCrops[i].DayPassed();
                    }
                }
            }
            daysPassed++;
        }

        /// <summary>
        /// Prompts the user for which crop they want to plant. If there is an empty field, plant it. Else, print an error. 
        /// </summary>
        public void Plant()
        {
            Console.WriteLine("\nSelect a crop to plant:");
            for(int i = 0; i < availableCrops.Length; i++)
            {
                Console.WriteLine("  {0}. {1} (Cost: {2:C})", i + 1, availableCrops[i].Name, availableCrops[i].Cost);
            }
            int cropType = SmartConsole.GetValidNumericInput("> ", 1, availableCrops.Length);
            
            // Check for affordability
            if(currentMoney < availableCrops[cropType - 1].Cost)
            {
                string errorMessage = string.Format("Unable to afford {0} right now! Its price is too high!", availableCrops[cropType - 1].Name);
                SmartConsole.PrintError(errorMessage);
            }
            // Check for an empty field
            else if(HasEmptyFields)
            {
                // Find first available empty field to plant in
                for(int i = 0; i < currentCrops.Length; i++)
                {
                    if (currentCrops[i] == null)
                    {
                        Crop newCropInstance = new Crop(availableCrops[cropType - 1]);
                        currentCrops[i] = newCropInstance;
                        currentMoney -= newCropInstance.Cost;
                        string successMessage = String.Format("{0} planted in field #{1}", newCropInstance.Name, i + 1);
                        SmartConsole.PrintSuccess(successMessage);
                        break;
                    }
                }
            }
            // All fields full, cannot plant
            else
            {
                SmartConsole.PrintError("Unable to plant right now. Harvest something first.");
            }
        }

        /// <summary>
        /// Let's the user harvest and sell crops. Prevents the user from harvest an empty field or a crop that is still growing. 
        /// </summary>
        public void Harvest()
        {
            // if all fields are empty, error message for player to plant something first
            if(AllFieldsAreEmpty())
            {
                SmartConsole.PrintError("You have to plant something first!");
            }
            // else, prompt the player for which field to harvest
            else
            {
                Console.WriteLine("Which field would you like to harvest?");
                Console.WriteLine(BuildFieldList());
                int field = SmartConsole.GetValidNumericInput("> ", 1, currentCrops.Length);

                // Field is empty
                if(currentCrops[field - 1] == null)
                {
                    string errorMessage = String.Format("You have to plant something in field {0} first!", field);
                    SmartConsole.PrintError(errorMessage);
                }
                // Check whether or not it can be harvested
                else if (currentCrops[field-1].CanHarvest)
                {
                    Money += currentCrops[field - 1].SellingPrice;
                    string harvestMessage = String.Format("Sold {0} for {1:C}", currentCrops[field - 1].Name, currentCrops[field - 1].SellingPrice);
                    SmartConsole.PrintSuccess(harvestMessage);
                    currentCrops[field - 1] = null;
                }
                // Crop not ready for harvest yet
                else if(!currentCrops[field - 1].CanHarvest)
                {
                    string errorMessage = String.Format("{0} cannot be harvested yet, it still has {1} days left to grow!", currentCrops[field - 1].Name, currentCrops[field - 1].DaysLeft);
                    SmartConsole.PrintError(errorMessage);
                }
            }
        }

        /// <summary>
        /// Prints the status of the farm, including the day, farm name, potential earnings. 
        /// </summary>
        public void PrintStatus()
        {
            Console.WriteLine("Day {0} at {1} with {2:C} on hand.", daysPassed, farmName, currentMoney);

            // Get the total potential earnings from today
            double potentialEarnings = 0;
            foreach(Crop crop in currentCrops)
            {
                if(crop != null && crop.CanHarvest)
                {
                    potentialEarnings += crop.SellingPrice;
                }
            }
            Console.WriteLine("We have {0:C} potential earnings from the fields ready to harvest.", potentialEarnings);

            Console.WriteLine(BuildFieldList());
        }
        /// <summary>
        /// Helper method which helps build out the list of fields and their crops.
        /// </summary>
        /// <returns> string variable representing the field list. </returns>
        private string BuildFieldList()
        {
            string finalList = null;
            for(int i = 0; i < currentCrops.Length; i++)
            {
                string field = String.Format(" - Field {0}: ", i + 1);
                string cropStatus = null;

                // if empty field
                if (currentCrops[i] == null)
                {
                    cropStatus = "Empty";
                }
                else
                {
                    cropStatus = currentCrops[i].ToString();
                }
                finalList = finalList + field + cropStatus + "\n";
            }
            return finalList;
        }

        /// <summary>
        /// Helper function to check if ALL fields are empty, not just if one field is empty. 
        /// </summary>
        /// <returns> bool value of whether all fields are empty or not. </returns>
        private bool AllFieldsAreEmpty()
        {
            foreach(Crop crop in currentCrops)
            {
                // If a crop exists, the field is not empty
                if (crop != null)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
