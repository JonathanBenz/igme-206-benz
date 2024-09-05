/* Author: Jonathan Benz
 * HW 1: Character Story
 * No Known Issues */
namespace HW1_CharacterStory_JRB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaring and initializing all variables that will be used throughout the story
            const double PriceOfMtnDew = 2.99;
            const int XPNeededToLevelUp = 5;
            const int MaxHP = 100;
            int damagePerBlow = 10;
            double damageMitigation = 0.25f;
            string cashierName = "Pasquale";
            string heroName = "Daniel";
            // currentHealth is the same as MaxHP at the very start
            double currentHealth = MaxHP;
            int currentXP = 0;
            // Upon defeating a hostile, gain xpGain
            int xpGain = 10;
            bool isLeveledUp = false;

            // Writing down the introduction
            Console.WriteLine("+++++ Introduction +++++");
            Console.WriteLine("Introducing " + heroName + ", a thirsty gamer walking to " +
                "7/11 in the hopes of acquiring a legendary bottle of Mtn. Dew.");
            Console.WriteLine();

            // Presenting heroName's starting stats
            Console.WriteLine("+++++ Character Stats +++++");
            Console.WriteLine("Max Health: " + MaxHP);
            Console.WriteLine("Current Health: " + currentHealth);
            Console.WriteLine("XP Needed to Level Up: " + XPNeededToLevelUp);
            Console.WriteLine("CurrentXP: " + currentXP);
            Console.WriteLine("Has leveled up?: " + isLeveledUp);
            Console.WriteLine();

            // Writing down the adventure
            Console.WriteLine("+++++ The Adventure +++++");
            Console.WriteLine(heroName + " grabs the legendary cold bottle of Mtn. Dew and " +
                "makes his way toward the cashier, whose name is " + cashierName + ".");
            Console.WriteLine();
            Console.WriteLine("\"This Mtn. Dew costs $" + PriceOfMtnDew + ". " +
                "However, I refuse to sell it to you, because I don't think you are a " +
                "worthy gamer,\" says " + cashierName + ".");
            Console.WriteLine();
            Console.WriteLine("\"Impossible! I will fight you for it then. " +
                "You have left me no choice...\" proclaims " + heroName + ".");
            Console.WriteLine();
            Console.WriteLine(heroName + " runs toward " + cashierName + " and gives him " +
                "an uppercut from Hell!");
            // 1st Calculation
            // Calculating damage done after mitigation. Rounds the value to nearest tenth place
            Console.WriteLine("This dealt " + Math.Round(damagePerBlow * (1 - damageMitigation), 1) +
                " damage to " + cashierName + "!");
            Console.WriteLine();
            Console.WriteLine(cashierName + " retaliates with a suplex through the counter!");
            // 2nd Calculation
            // Calculate damage done using a modulus operator
            Console.WriteLine(heroName + " takes " + (damagePerBlow % 6) + " damage!");
            // 3rd Calculation
            // Calculates remaining health left for heroName
            Console.WriteLine(heroName + " has " + (currentHealth -= (damagePerBlow % 6)) +
                " health remaining!");
            Console.WriteLine();
            Console.WriteLine("\"Oh, you're going to pay quite dearly for that...,\" " + heroName + " says.");
            Console.WriteLine();
            Console.WriteLine(heroName + " gets up to perform an RKO out of nowhere on " +
                cashierName + "! This move is super effective!");
            // 4th Calculation
            // Calculates the damage done from the super effective RKO
            Console.WriteLine(cashierName + " takes " + (damagePerBlow * 999) / 10 + " damage and gets " +
                "absolutely knocked out!!!");
            Console.WriteLine();
            // 5th Calculation
            // Calculates the new amount of current XP
            Console.WriteLine(heroName + " gains " + (currentXP += xpGain) + " XP points from this encounter.");
            if(currentXP > XPNeededToLevelUp)
            {
                isLeveledUp = true;
                Console.WriteLine(heroName + " leveled up!");
            }
            Console.WriteLine();

            // Writing the conclusion
            Console.WriteLine("+++++ Conclusion +++++");
            Console.WriteLine("With bloodied hands, " + heroName + " can finally enjoy a sip " +
                "of his Mtn. Dew. \nTHE END!");
            Console.WriteLine();

            // Final heroName stats
            Console.WriteLine("+++++ Final Character Stats +++++");
            Console.WriteLine("Max Health: " + MaxHP);
            Console.WriteLine("Current Health: " + currentHealth);
            Console.WriteLine("XP Needed to Level Up: " + XPNeededToLevelUp);
            Console.WriteLine("CurrentXP: " + currentXP);
            Console.WriteLine("Has leveled up?: " + isLeveledUp);
        }
    }
}
