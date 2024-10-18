using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6_CritterFarm
{
    internal class Bunny : Critter
    {
        /// <summary>
        /// By default, bunnies start with a hunger level of 2 and a boredom level of 5
        /// </summary>
        /// <param name="name"> Name of the pet. </param>
        public Bunny(string name)
            : base(name, CritterType.Bunny, 2, 5)
        {
        }
        /// <summary>
        /// This constructor should only be used when loading a saved critter from a file
        /// </summary>
        /// <param name="name"> Name of the pet. </param>
        /// <param name="currentHunger"> Hunger level loaded in from file. </param>
        /// <param name="currentBoredom"> Boredom level loaded in from file. </param>
        public Bunny(string name, int currentHunger, int currentBoredom)
            : base(name, CritterType.Bunny, currentHunger, currentBoredom)
        {
        }
        /// <summary>
        /// Calculates the Bunny's frustration level
        /// and sets its mood based on the irritationLevel. 
        /// </summary>
        protected override void UpdateMood()
        {
            int irritationLevel = Hunger * Boredom;
            if (irritationLevel > GenAngryLvl)
            {
                mood = CritterMood.Angry;
            }
            else if (irritationLevel > GenFrustrationLvl)
            {
                mood = CritterMood.Frustrated;
            }
            else
            {
                mood = CritterMood.Happy;
            }
        }

        /// <summary>
        /// Specialized method that only the bunny has. 
        /// Given a random percant chance, the bunny may eat all of your mom's flowers, 
        /// drastically reducing its hunger. 
        /// </summary>
        /// <param name="rng"> Random object to be passed to enable rng use for this method. </param>
        /// <param name="percentChance"> Percantage for this behavior to happen. </param>
        public void EatAllYourMomsFlowers(Random rng, int percentChance)
        {
            int random = rng.Next(100);
            if(random <= percentChance)
            {
                Console.WriteLine("{0} also got really hungry and ate all of your mother's flowers. What a feast!", Name);
                Hunger = 0;
            }
        }
    }
}
