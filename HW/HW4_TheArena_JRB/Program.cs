/***
 * YOUR NAME: Jonathan Benz
 * 
 * HW 4 - The Arena
 * Write-up: https://docs.google.com/document/d/15Rl0oXwNXdGze8p5HcrZ8n4y78oiubW5pbkJei2YTPI/edit?usp=sharing
 *
 * Primary upgrades:
 *  1. Power-Ups --> Randomly spawns a potion that the player can pick up to randomly increase his health stat!
 *  2. Experience Points --> Displays how much XP the player has. For every enemy slain, level up and increase a stat! 
 *  
 * Optional extra upgrades:
 *  3. Random Enemy Placement --> Generates a random number of enemies to spawn, and then spawns them randomly! 
 *  4. Enemy Customization  --> When entering an enemy encounter, generates a random enemy name and a random amount of enemy healthpoints!
 *  
 * Known Bugs: No known issues. 
 * 
 * Other notes: N/A
 * 
 */
namespace HW4_Arena
{
    /// <summary>
    /// Primary class for the console app. Main() will be run on program launch. Other helper methods are
    /// also defined that Main() will need. It's your job to finish them!
    /// 
    /// Do NOT change anything except where explicitly marked with a TODO comment!
    /// See the comments through this program AND read the assignment write-up for details.
    /// </summary>
    internal class Program
    {
        // *** These constants are defined for you to make your code more readable AND help ensure it works
        //     with the code given to you. Do NOT change these!

        // Constants for the tile types
        private const char Empty = ' ';
        private const char Wall = '#';
        private const char Enemy = 'E';
        private const char Player = '@';
        private const char PlayerStart = '0';
        private const char Exit = '1';
        private const char Potion = '!';
        // Constants for directions
        private const char Up = 'w';
        private const char Down = 's';
        private const char Left = 'a';
        private const char Right = 'd';

        // Player stat indices
        private const int Strength = 0;
        private const int Dexterity = 1;
        private const int Constitution = 2;
        private const int Health = 3;
        private const int XP = 4;

        // Possible fight outcomes
        private const int Win = 0;
        private const int Lose = 1;
        private const int Run = 2;
        private const int Draw = 3;

        // *** Other constants
        // TODO: It's okay to tweak these numbers a bit to balance your game and/or add new ones.
        // (But don't delete what is here. Main needs some of them!)
        const int EnemySpacing = 6;
        const int MaxPoints = 10;
        const int HealthMult = 5;
        const int DamageMult = 5;
        const int EnemyAttack = 5;
        const int EnemyMaxHealth = 50;
        const int experienceGain = 10;

        /// <summary>
        /// DO NOT CHANGE ANY CODE IN MAIN!!!
        /// 
        /// But it's definitely worth reading it to get an understanding of 
        /// how/when your methods will be called.
        /// 
        /// AND it's okay to *temporarily* comment out chunks of code until 
        /// you're ready for them to run to make it easier to test other things.
        /// </summary>
        static void Main(string[] args)
        {
            // ** SETUP **
            // Player's name
            string name;

            // Stats - to make it easier to pass these around between methods, all 4 stats are
            // in a single array with elements in the order [Strength, Dexterity, Constitution, Health]
            // Constants are defined above to help with this.
            int[] stats = new int[5];

            // Define the variable to refer to the final arena
            char[,] arena;

            // Track the player's location as [row, col] (NOT x, y)
            int[] playerLoc = { 1, 1 };

            // Is the game still running?
            bool stillPlaying = true;

            // How many enemies are left?
            int numEnemies;

            // ** GET PLAYER STATS & BUILD ARENA **
            // Welcome & get stats 
            name = GetPlayerInfo(stats);

            // Build & print the Arena
            arena = BuildArena(out numEnemies);

            // ** GAME LOOP **
            while (stillPlaying)
            {
                // ** PRINT EVERYTHING **

                // Clear the console and then print the arena
                Console.Clear();
                PrintArena(arena, playerLoc);
                Console.WriteLine(
                    $"\n{name}, your stats are: " +
                    $"Strength {stats[Strength]}, " +
                    $"Dexterity {stats[Dexterity]}, " +
                    $"Constitution {stats[Constitution]}, " +
                    $"Health {stats[Health]}, " +
                    $"and XP: {stats[XP]}");

                // ** DETECT MOVEMENT **

                // Get the desired direction
                char direction = SmartConsole.GetPromptedChoice(
                        $"\n Where would you like to go? {Up}/{Left}/{Down}/{Right} >",
                        new char[] { Up, Left, Down, Right });
                Console.WriteLine();

                // Figure out what is there, but don't move yet
                int[] nextLoc = { playerLoc[0], playerLoc[1] };
                switch (direction)
                {
                    case Up:
                        nextLoc[0]--; // row--
                        break;

                    case Down:
                        nextLoc[0]++; // row++
                        break;

                    case Left:
                        nextLoc[1]--; // col --
                        break;

                    case Right:
                        nextLoc[1]++; // col ++
                        break;
                }

                // ** TAKE ACTION **
                // Act based on what is in the next location (row, col)
                switch (arena[nextLoc[0], nextLoc[1]])
                {
                    // Do nothing. We're stuck.
                    case Wall:
                        Console.WriteLine("\n You can't go there...");
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        break;

                    // Move to that spot
                    case Empty:
                        playerLoc = nextLoc;
                        break;

                    // Launch a new fight and determine how to proceed based on the result
                    case Enemy:
                        switch (Fight(stats))
                        {
                            // Take over the enemy's spot if we win
                            case Win:
                                playerLoc = nextLoc;
                                arena[playerLoc[0], playerLoc[1]] = Empty;
                                numEnemies--;
                                break;

                            // A loss or draw is game over
                            case Lose:
                            case Draw:
                                stillPlaying = false;
                                break;

                            // Run back to the start and regain half health
                            case Run:
                                Console.WriteLine("You retreat to the starting area of the arena to heal up.");
                                playerLoc = new int[] { 1, 1 };
                                stats[Health] += (stats[Constitution] * HealthMult) / 2;
                                stats[Health] = Math.Clamp(stats[Health], 0, stats[Constitution] * HealthMult); // cap at max health
                                break;
                        }
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        break;

                    case Exit:
                        if (numEnemies > 0)
                        {
                            Console.WriteLine("You must defeat all enemies before you can escape.");
                        }
                        else
                        {
                            Console.WriteLine("You made it to the exit! Congratulations!");
                            stillPlaying = false;
                        }
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        break;

                    // POWER-UP MODIFICATION! 
                    // Increase health by a random int between 0 and 10 if player picks up a potion
                    case Potion:
                        int healthIncrease = new Random().Next(11);
                        stats[Health] += healthIncrease;

                        playerLoc = nextLoc;
                        arena[playerLoc[0], playerLoc[1]] = Empty;

                        Console.WriteLine("\nYour health went up by {0} after drinking the potion!", healthIncrease);
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }

        }

        /// <summary>
        /// Given a reference to the player's current stats, launch a new fight
        /// </summary>
        /// <param name="stats">A reference to an int[] containing [Strength, Dexterity, Constitution, Health]</param>
        /// <returns>The result of the fight using an int code. See the constants at the top of Program.cs</returns>
        private static int Fight(int[] stats)
        {
            // TODO: Implement the Fight method
            // ~~~~ YOUR CODE STARTS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // Declaring and initializing health and damage variables
            int enemyHealth = EnemyMaxHealth;
            int damageDealt = stats[Strength] * DamageMult;
            int damageReceived = EnemyAttack - stats[Dexterity];
            int finalCondition = -1;
            bool stoppedFighting = false;

            // Array of enemy names to randomly pull out of
            string[] enemyNames = { "goat", "llama", "bunny", "bear", "penguin", "lion", "squirrel", "crocodile",
                                "capybara", "elephant", "dinosaur", "shark", "wolf", "monkey", "beaver" };
            // Array of enemy health mults to get random enemy health
            int[] enemyHealthMults = { 1, 2, 3, 4, 5 };
            // Randomly picking enemy name and enemy health
            string enemyName = enemyNames[new Random().Next(enemyNames.Length)];
            enemyHealth = EnemyMaxHealth * enemyHealthMults[new Random().Next(enemyHealthMults.Length)];

            // Fight loop
            Console.WriteLine("An angry {0} attacks you!", enemyName);
            while(!stoppedFighting)
            {
                Console.WriteLine("\nYour current health is {0}, the {1}'s health is {2}", stats[Health], enemyName, enemyHealth);
                String action = SmartConsole.GetPromptedInput("What would you like to do? Attack/Run >");
                action = action.ToLower();
                if(action.Equals("attack"))
                {
                    // Attacking
                    Console.WriteLine("You swing at the {0} doing {1} damage.", enemyName, damageDealt);
                    enemyHealth -= damageDealt;
                    Console.WriteLine("The {0} charges at you for {1} damage!", enemyName, damageReceived);
                    stats[Health] -= damageReceived;

                    // Check for Win Condition
                    if(stats[Health] > 0 && enemyHealth <= 0)
                    {
                        Console.WriteLine("\nYou have defeated the beast! Congratulations!");
                        finalCondition = Win;
                        stoppedFighting = true;

                        // Reward with XP and level up!
                        Console.WriteLine("\nYou have gained {0} XP Points and can level up!", experienceGain);
                        char attributeIncrease = SmartConsole.GetPromptedChoice(
                        $"Which attribute would you like to increase? \n\t{Strength} - Strength? \n\t{Dexterity} - Dexterity? \n\t{Constitution} - Constitution? \n\t >",
                        new char[] { '0', '1', '2' });

                        // Increase stat
                        switch(attributeIncrease)
                        {
                            case '0':
                                stats[Strength]++;
                                Console.WriteLine("\nStength increased!");
                                break;
                            case '1':
                                stats[Dexterity]++;
                                Console.WriteLine("\nDexterity increased!");
                                break;
                            case '2':
                                stats[Constitution]++;
                                Console.WriteLine("\nConstitution increased!");
                                break;
                        }

                        // Reset stats to reflect upon new level's stats
                        damageDealt = stats[Strength] * DamageMult;
                        damageReceived = EnemyAttack - stats[Dexterity];
                        stats[Health] = stats[Constitution] * HealthMult;
                        stats[XP] += experienceGain;

                        Console.WriteLine("\nLevel Up Successful!");
                    }
                    // Check for Draw Condition
                    else if (stats[Health] <= 0 && enemyHealth <= 0)
                    {
                        Console.WriteLine("\nYou defeat the {0} with your last breath.", enemyName);
                        finalCondition = Draw;
                        stoppedFighting = true;
                    }
                    // Check for Lose Condition
                    else if (stats[Health] <= 0 && enemyHealth > 0)
                    {
                        Console.WriteLine("\nYour wounds are too much, the {0} wins this time.", enemyName);
                        finalCondition = Lose;
                        stoppedFighting = true;
                    }
                }
                else if(action.Equals("run"))
                {
                    finalCondition = Run;
                    stoppedFighting = true;
                }
                else
                {
                    Console.WriteLine("\nCommand not recognized! Oh no! LOOK OUT!!");
                    Console.WriteLine("The {0} charges at you for {1} damage!", enemyName, damageReceived);
                    stats[Health] -= damageReceived;

                    // Check for Lose Condition
                    if(stats[Health] <= 0)
                    {
                        Console.WriteLine("\nYour wounds are too much, the {0} wins this time.", enemyName);
                        finalCondition = Lose;
                        stoppedFighting = true;
                    }
                }
            }
            return finalCondition;
            // ~~~~ YOUR CODE STOPS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }

        /// <summary>
        /// Get the player's name & stats. Stats are loaded into the provided array and
        /// the name is returned.
        /// </summary>
        /// <param name="statsArray">A reference int[4] array that this method will put data into</param>
        /// <returns>The player's name</returns>
        private static string GetPlayerInfo(int[] statsArray)
        {
            // TODO: Implement the GetPlayerInfo method
            // ~~~~ YOUR CODE STARTS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // Prompt for name
            String name = SmartConsole.GetPromptedInput("Welcome, please enter your name:");
            Console.WriteLine("\nHello {0}, I'll need a bit more information from you before we can start.", name);
            Console.WriteLine("You have {0} points to build your character and three attributes to allocate them to.\n", MaxPoints);

            // Declaring and initializing prompts we can re-use, as well as a points tracker
            string allocationPrompt = "How many points would you like to allocate to {0}? >";
            string pointsRemainingPrompt = "You have {0} points remaining.\n";
            int pointsRemaining = MaxPoints;

            // Getting Strength data
            statsArray[Strength] = SmartConsole.GetValidIntegerInput(String.Format(allocationPrompt, "Strength"), 1, 8);
            pointsRemaining -= statsArray[Strength];
            Console.WriteLine(String.Format(pointsRemainingPrompt, pointsRemaining));

            // Getting Dexterity data
            statsArray[Dexterity] = SmartConsole.GetValidIntegerInput(String.Format(allocationPrompt, "Dexterity"), 1, pointsRemaining);
            pointsRemaining -= statsArray[Dexterity];
            Console.WriteLine(String.Format(pointsRemainingPrompt, pointsRemaining));

            // Getting Constitution data
            statsArray[Constitution] = SmartConsole.GetValidIntegerInput(String.Format(allocationPrompt, "Constitution"), 1, pointsRemaining);
            pointsRemaining -= statsArray[Constitution];
            Console.WriteLine("You left {0} points unused.\n", pointsRemaining);

            // Calculating Health data
            statsArray[Health] = statsArray[Constitution] * HealthMult;

            return name;
            // ~~~~ YOUR CODE STOPS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }

        /// <summary>
        /// Given a reference to a 2d array variable (that will be null to start):
        /// - Prompt for the desired size and initialize the array
        /// - Put walls along all borders
        /// - Evenly space enemies every few tiles (vert & hor)
        /// - Put empty cells everywhere else
        /// - Place the player start in the top left
        /// - Place an exit in the bottom right
        /// </summary>
        /// <param name="numEnemies">An out param to store the total number of enemies created</param>
        /// <returns>A reference to the final 2d arena</returns>
        private static char[,] BuildArena(out int numEnemies)
        {
            // Start by setting numEnemies to 0. Increment this whenever you create
            // an enemy and the out param will work just fine. :)
            numEnemies = 0;

            // TODO: Implement the BuildArena method
            // ~~~~ YOUR CODE STARTS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // Prompting user if they want random enemy placement
            bool randomEnemies = false;
            int numEnemiesLimit = -1;
            char yesOrNo = SmartConsole.GetPromptedChoice(
                        "Would you like enemies to be randomly placed within the arena? y/n >",
                        new char[] { 'y', 'n' });

            if(yesOrNo == 'y')
            {
                randomEnemies = true;
                // Generating random number of enemies limit from 1 to 10 
                numEnemiesLimit = new Random().Next(1, 11);
            }


            // Prompting for width/ height of arena and then initializing that data into our 2D char array
            int arenaWidth = 0;
            int arenaHeight = 0;
            arenaWidth = SmartConsole.GetValidIntegerInput("\n\nHow wide should the arena be? (Enter a value from 10 to 50) >", 10, 50);
            arenaHeight = SmartConsole.GetValidIntegerInput("How tall should the arena be? (Enter a value from 10 to 50) >", 10, 50);
            char[,] arena = new char[arenaHeight, arenaWidth];

            // Filling in the arena array!
            for(int r = 0; r < arenaHeight; r++)
            {
                for(int c = 0; c < arenaWidth; c++)
                {
                    if(r == 0 || c == 0 || r == arenaHeight-1 || c == arenaWidth-1)
                    {
                        arena[r, c] = Wall;
                    }
                    else if(!randomEnemies && c % EnemySpacing == 0 && r % EnemySpacing == 0)
                    {
                        arena[r, c] = Enemy;
                        numEnemies++;
                    }
                    else
                    {
                        arena[r, c] = Empty;
                    }
                }
            }
            arena[1, 1] = PlayerStart;
            arena[arenaHeight - 2, arenaWidth - 2] = Exit;

            // Spawning a potion pick-up at a random location!
            bool canSpawn = false;
            while(!canSpawn)
            {
                int randomRow = new Random().Next(arenaHeight);
                int randomCol = new Random().Next(arenaWidth);
                if (arena[randomRow, randomCol] != Wall &&
                    arena[randomRow, randomCol] != PlayerStart &&
                    arena[randomRow, randomCol] != Exit &&
                    arena[randomRow, randomCol] != Enemy)
                {
                    canSpawn = true;
                    arena[randomRow, randomCol] = Potion;
                }
            }

            // Randomly spawning in our enemies! 
            bool stopSpawning = false;
            while(!stopSpawning && randomEnemies)
            {
                int randomRow = new Random().Next(arenaHeight);
                int randomCol = new Random().Next(arenaWidth);
                if (arena[randomRow, randomCol] != Wall &&
                    arena[randomRow, randomCol] != PlayerStart &&
                    arena[randomRow, randomCol] != Exit &&
                    arena[randomRow, randomCol] != Enemy &&
                    arena[randomRow, randomCol] != Potion)
                {
                    arena[randomRow, randomCol] = Enemy;
                    numEnemies++;
                }
                if(numEnemies >= numEnemiesLimit)
                {
                    stopSpawning = true;
                }
            }
            // ~~~~ YOUR CODE STOPS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            // All done
            return arena;
        }

        /// <summary>
        /// Given a reference to a 2d arena and the player's current location, 
        /// print every character using the correct colors.
        /// </summary>
        /// <param name="arena">A reference to the arena to print. This could be ANY size.</param>
        /// <param name="playerLoc">The player's location in a 1d array with element [row, col]</param>
        private static void PrintArena(char[,] arena, int[] playerLoc)
        {
            // TODO: Implement the PrintArena method
            // ~~~~ YOUR CODE STARTS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            for(int r = 0; r < arena.GetLength(0); r++)
            {
                for(int c = 0;c < arena.GetLength(1); c++)
                {
                    if (arena[r, c] == Wall)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(arena[r, c]);
                    }
                    else if(arena[r, c] == Enemy)
                    {
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.Write(arena[r, c]);
                    }
                    else if(r == playerLoc[0] && c == playerLoc[1])
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(Player);
                    }
                    else if (arena[r,c] == PlayerStart || arena[r,c] == Exit)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(arena[r, c]);
                    }
                    else if (arena[r,c] == Potion)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(arena[r, c]);
                    }
                    else
                    {
                        Console.Write(arena[r,c]);
                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            // ~~~~ YOUR CODE STOPS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }
    }
}