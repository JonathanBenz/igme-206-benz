using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6_CritterFarm
{
    internal class Horse : Critter
    {
        /// <summary>
        /// By default, horses start with a hunger level of 0 and a boredom level of 0
        /// </summary>
        /// <param name="name"> Name of the pet. </param>
        public Horse(string name)
            : base(name, CritterType.Horse)
        {
        }
        /// <summary>
        /// This constructor should only be used when loading a saved critter from a file
        /// </summary>
        /// <param name="name"> Name of the pet. </param>
        /// <param name="currentHunger"> Hunger level loaded in from file. </param>
        /// <param name="currentBoredom"> Boredom level loaded in from file. </param>
        public Horse(string name, int currentHunger, int currentBoredom)
            : base(name, CritterType.Horse, currentHunger, currentBoredom)
        {
        }
        /// <summary>
        /// Calculates the Horse's frustration level
        /// and sets its mood based on the irritationLevel. 
        /// </summary>
        protected override void UpdateMood()
        {
            int irritationLevel = 2 * Hunger + Boredom;
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
    }
}
