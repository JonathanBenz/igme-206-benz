using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6_CritterFarm
{
    internal class Penguin : Critter
    {
        /// <summary>
        /// By default, penguins start with a hunger level of 5 and a boredom level of 0
        /// </summary>
        /// <param name="name"> Name of the pet. </param>
        public Penguin(string name) 
            : base(name, CritterType.Penguin, 5)
        {
        }
        /// <summary>
        /// This constructor should only be used when loading a saved critter from a file
        /// </summary>
        /// <param name="name"> Name of the pet. </param>
        /// <param name="currentHunger"> Hunger level loaded in from file. </param>
        /// <param name="currentBoredom"> Boredom level loaded in from file. </param>
        public Penguin(string name, int currentHunger, int currentBoredom) 
            : base(name, CritterType.Penguin, currentHunger, currentBoredom)
        {
        }
        /// <summary>
        /// Calculates the Penguin's frustration level (in this case arbritrarily using the distance formula)
        /// and sets its mood based on the irritationLevel. 
        /// </summary>
        protected override void UpdateMood()
        {
            int irritationLevel = (int) Math.Sqrt(Math.Pow(Hunger, 2) + Math.Pow(Boredom, 2));
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
