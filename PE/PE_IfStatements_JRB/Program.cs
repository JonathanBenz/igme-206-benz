/* Author: Jonathan Benz
 * PE - If Statements
 * No known issues. */
namespace PE_IfStatements_JRB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaring and initializing variables
            string sense;

            string sense1 = "doritos";
            string sense2 = "monster energy";
            string sense3 = "call of duty black ops 2";

            // Displaying the options of senses at the top for ease of convenience
            Console.WriteLine($"Potential senses you can use as input: \"{sense1}\", \"{sense2}\", or \"{sense3}\"\n");

            Console.Write("What does the NPC in your game sense? ");
            sense = Console.ReadLine();
            sense = sense.ToLower().Trim();

            // If Else Scenarios
            if (sense.Equals(sense1))
            {
                Console.WriteLine("The NPC consumes the Doritos with great gluttony.");
            }
            else if(sense.Equals(sense2))
            {
                Console.WriteLine("The NPC chugs the Monster Energy and becomes a super-charged mutant.");
            }
            else if(sense.Equals(sense3))
            {
                Console.Write("Is the NPC playing multiplayer or zombies? ");
                string input = Console.ReadLine();
                input = input.ToLower().Trim();
                if(input.Equals("multiplayer"))
                {
                    Console.WriteLine("The NPC racks up a 30-kill-streak and hits some nasty trickshots.");
                }
                else if(input.Equals("zombies"))
                {
                    Console.WriteLine("The NPC loads up Origins and reaches round 30!");
                }
                else
                {
                    Console.WriteLine("The NPC just plays the campaign.");
                }
            }
            else
            {
                Console.WriteLine("The NPC is completely baffled about what to do.");
            }
        }
    }
}
