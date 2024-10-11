﻿// Class borrowed from DynamicMenus.ZIP File
// Modified by Jonathan Benz

namespace PE_Inheritance_JRB
{
    /// <summary>
    /// The MenuItem parent class defines the core data managed by
    /// and behavior of all menu item objects (of this or any child type)
    /// </summary>
    class MenuItem
    {
        // ~~~ FIELDS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        protected string actionText;
        protected string description;
        protected string keyword;

        // ~~~ PROPERTIES ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public string Keyword
        {
            get { return keyword; }
        }

        // ~~~ CONSTRUCTORS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // If we don't explicitly define ANY constructors, C# will make
        // one for us that works like this:

       /* protected MenuItem() 
            : this("DEFAULT", "Test a default MenuItem", "Ran the default!")
        {
        }*/

        // But we may not want a default version of this class to ever
        // be instantiated. Making it protected means that default child
        // classes can be instanted, but not the parent.

        // Public parameterized constructor to setup a simple MenuItem object
        public MenuItem(string keyword, string description, string actionText)
        {
            this.keyword = keyword.ToUpper();
            this.description = description;
            this.actionText = actionText;
        }

        // ~~~ OVERRIDES from Object ~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Override ToString to give the keyword and description
        public override string ToString()
        {
            return "\t" + Keyword.ToUpper() + ": " + description;
        }

        // ~~~ METHODS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // By default, MenuItems print out their action text.
        public virtual void Run()
        {
            Console.WriteLine(actionText);
        }
    }
}