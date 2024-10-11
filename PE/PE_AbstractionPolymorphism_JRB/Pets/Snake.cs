using System;

namespace PE_AbstractionPolymorphism_JRB.Pets
{
    /// <summary>
    /// Snakes are Pets that say hisssss 
    /// </summary>
    internal class Snake : Pet
    {
        public Snake(string name, DateTime birthday)
            : base(name, birthday, "snake")
        {
        }
        public override void Speak()
        {
            Console.WriteLine(this.Name + " says HISSSSS.");
        }
    }
}
