// New child class by Jonathan Benz
namespace PE_Inheritance_JRB
{
    internal class DrawSquareItem : MenuItem
    {
        // ~~~ FIELDS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private int size;

        // ~~~ PROPERTIES ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // None specific to this child class

        // ~~~ CONSTRUCTORS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public DrawSquareItem(string keyword, string description, string actionText)
            : base(keyword, description, actionText)
        {
        }

        // ~~~ OVERRIDES from Object ~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // None specific to this child class

        // ~~~ METHODS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // The child class can do as much as it likes when overriding!
        public override void Run()
        {
            // Setup
            Console.WriteLine(actionText);

            bool inputSuccessful = int.TryParse(Console.ReadLine(), out size);

            if (inputSuccessful)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        Console.Write("? ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }
    }
}
