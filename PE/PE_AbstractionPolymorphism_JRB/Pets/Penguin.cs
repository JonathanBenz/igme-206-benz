using System;

namespace PE_AbstractionPolymorphism_JRB.Pets
{
    /// <summary>
    /// Penguins are Pets that say waddle waddle
    /// </summary>
    internal class Penguin : Pet
    {
        public Penguin(string name, DateTime birthday)
            : base(name, birthday, "penguin")
        {
        }
        public override void Speak()
        {
            Console.WriteLine(this.Name + " says WADDLE WADDLE.");
        }
    }
}
