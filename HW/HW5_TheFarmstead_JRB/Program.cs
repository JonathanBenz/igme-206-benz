/* Author: Jonathan Benz
 * HW 5 - The Farmstead
 * Write-Up: https://docs.google.com/document/d/1xnF9pZIhLC-PW3OAOktW15VzMtAktTZWnHEsuQSDBpQ/edit
 * No known issues */
namespace HW5_TheFarmstead_JRB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaring variables
            Farm myFarm;
            Crop[] availableCrops;
            int numCrops;
            int numFields;
            string farmName;
            double startingMoney;
            double maintenanceCost;
            bool isGameOver = false;

            // Declaring const maximum starting values that the user cannot go over when creating their farm
            const int MaxCrops = 5;
            const int MaxFields = 5;
            const int MaxHarvestTime = 10;
            const double MaxCropCost = 500.00;
            const double MaxStartingMoney = 1000.00;
            const double MaxMaintenanceCost = 50.00;

            // Declaring const prompt variables for game loop
            const string PromptUser = "  1. Plant crops\n  2. Harvest and sell produce\n  3. Do nothing today\n  4. Quit\n> ";
            const char Plant = '1';
            const char Harvest = '2';
            const char DoNothing = '3';
            const char Quit = '4';

            // Game Introduction
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome to Farmstead, your virtual farming adventure!");
            Console.WriteLine("Start your farming journey by defining the crops available and naming your farm.");

            numCrops = SmartConsole.GetValidNumericInput("\nHow many types of crops do you want to define?", 1, MaxCrops);
            availableCrops = new Crop[numCrops];

            // Fills in availableCrops array
            for(int i = 0; i < numCrops; i++)
            {
                Console.WriteLine("\nDefine crop type #{0}", i+1);
                string cropName = SmartConsole.GetPromptedInput("  Name:");
                double cost = SmartConsole.GetValidNumericInput("  Cost:", 1, MaxCropCost);
                int harvestTime = SmartConsole.GetValidNumericInput("  Days until harvest:", 1, MaxHarvestTime);
                Crop crop = new Crop(cropName, cost, harvestTime);
                availableCrops[i] = crop;
            }

            // Getting farm start values
            farmName = SmartConsole.GetPromptedInput("\nPlease name your farm:");
            numFields = SmartConsole.GetValidNumericInput("\nHow many fields are available for planting?", 1, MaxFields);
            startingMoney = SmartConsole.GetValidNumericInput("\nHow much money are you starting with?", 1, MaxStartingMoney);
            maintenanceCost = SmartConsole.GetValidNumericInput("\nWhat is the daily maintenance cost?", 1, MaxMaintenanceCost);

            // Create farm instance
            myFarm = new Farm(farmName, availableCrops, numFields, startingMoney, maintenanceCost);
            Console.WriteLine("\n*** {0}, ready for a fruitful season! ***", myFarm.Name);

            // Game Loop
            do
            {
                Console.WriteLine();
                // Check for game over status
                if(myFarm.Money <= 0)
                {
                    isGameOver = true;
                    string gameOverMessage = string.Format("{0} ran out of money!", myFarm.Name);
                    SmartConsole.PrintError(gameOverMessage);
                    break;
                }

                // Print farm status
                myFarm.PrintStatus();

                // Prompt for what the player wants to do today
                char choice = SmartConsole.GetPromptedChoice(PromptUser,
                    [Plant, Harvest, DoNothing, Quit]);
                Console.WriteLine();

                switch(choice)
                {
                    case (Plant):
                        myFarm.Plant();
                        myFarm.DayPassed();
                        break;

                    case Harvest:
                        myFarm.Harvest();
                        myFarm.DayPassed();
                        break;

                    case DoNothing:
                        myFarm.DayPassed();
                        break;

                    case Quit:
                        isGameOver = true;
                        myFarm.DayPassed();
                        string quitMessage = string.Format("You quit with {0:C} in the bank!", myFarm.Money);
                        SmartConsole.PrintSuccess(quitMessage);
                        break;

                    default:
                        break;
                }
            }
            while (!isGameOver);
        }
    }
}
