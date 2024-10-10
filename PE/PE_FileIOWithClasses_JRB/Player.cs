/* Author: Jonathan Benz
 * Player Class
 * No known issues */
namespace PE_FileIOWithClasses_JRB
{
    internal class Player
    {
        // Declaring Fields and Properties
        private string name;
        private int strength;
        private int health;

        public string Name { get { return name; } }
        public int Strength { get { return strength; } }
        public int Health { get { return health; } }

        // Constructor
        public Player(string name, int strength, int health)
        {
            this.name = name;
            this.strength = strength;
            this.health = health;
        }

        // Methods

        /// <summary>
        /// Prints out the player's information. 
        /// </summary>
        /// <returns> string of the player's information. </returns>
        public override string ToString()
        {
            string playerInfo = String.Format("\tPlayer: {0}. Stength {1}, Health {2}.", name, strength, health);
            return playerInfo;
        }
    }
}
