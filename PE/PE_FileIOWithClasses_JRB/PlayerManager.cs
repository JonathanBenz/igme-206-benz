/* Author: Jonathan Benz
 * PlayerManager Class
 * No known issues */

using System.IO;

namespace PE_FileIOWithClasses_JRB
{
    internal class PlayerManager
    {
        // Declaring fields
        private string fileName;
        private List<Player> players;

        // Constructor
        public PlayerManager()
        {
            fileName = "../../../players.txt";
            players = new List<Player>();
        }

        // Methods

        /// <summary>
        /// Creates an instance of the player, adds it to the list of players, and prints confirmation. 
        /// </summary>
        /// <param name="name"> name of the player. </param>
        /// <param name="strength"> strength of the player. </param>
        /// <param name="health"> health of the player. </param>
        public void CreatePlayer(string name, int strength, int health)
        {
            Player player = new Player(name, strength, health);
            players.Add(player);
            Console.WriteLine("\tAdded {0} to the list.", player.Name);
        }

        /// <summary>
        /// Prints all of the players.
        /// </summary>
        public void Print()
        {
            // If the list is empty
            if(players.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tThere are no players yet.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                foreach(Player player in players)
                {
                    Console.WriteLine(player.ToString());
                }
            }
        }

        /// <summary>
        /// Loads in all player data from a file, and adds it to players.
        /// </summary>
        public void Load()
        {
            players.Clear();
            StreamReader reader = null;
            string playerData = "";

            try
            {
                reader = new StreamReader(fileName);
                while((playerData = reader.ReadLine()) != null)
                {
                    string[] splitPlayerData = playerData.Split(',');
                    Player newPlayer = new Player(splitPlayerData[0], int.Parse(splitPlayerData[1]), int.Parse(splitPlayerData[2]));
                    players.Add(newPlayer);
                }
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tThere is no player data to load.");
                Console.ForegroundColor = ConsoleColor.White;
            }

            // If reading the file was successful
            if(reader != null)
            {
                reader.Close();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\tLoading data from {0}", fileName.Substring(9));
                foreach(Player player in players)
                {
                    Console.WriteLine("\tAdded {0} to the list.", player.Name);
                }
                Console.WriteLine("\tLoaded all data from file.");
                Console.WriteLine("\t{0} players created.", players.Count);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// Saves all information from players to a txt file in CSV format. 
        /// </summary>
        public void Save()
        {
            StreamWriter writer = null;

            // Check that there are players to save in the first place. 
            if(players.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tThere is no player data yet.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            try
            {
                writer = new StreamWriter(fileName);
                foreach(Player player in players)
                {
                    string saveData = String.Format("{0},{1},{2}", player.Name, player.Strength, player.Health);
                    writer.WriteLine(saveData);
                }
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }

            // If save was successful.
            if(writer != null)
            {
                writer.Close();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\tSaved {0} players to file {1}", players.Count, fileName.Substring(9));
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
