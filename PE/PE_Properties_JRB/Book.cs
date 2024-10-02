/* Author: Jonathan Benz
 * Book Class
 * No known issues */
namespace PE_Properties_JRB
{
    internal class Book
    {
        // Declaring Class Fields
        private string title;
        private string author;
        private int numPages;
        private string owner;
        private int totalTimesRead;

        // Constructor
        public Book(string title, string author, int numPages, string owner)
        {
            this.title = title;
            this.author = author;
            this.numPages = numPages;
            this.owner = owner;
            totalTimesRead = 0;
        }

        // Properties
        public string Title
        {
            get { return title; }
        }
        public string Author
        {
            get { return author; }
        }
        public int NumPages
        {
            get { return numPages; }
        }

        public string Owner
        {
            get { return owner; }
            set { 
                value = value.Trim();
                if (value != "")
                    {
                        owner = value;
                    }
                }
        }
        public int TotalTimesRead
        {
            get { return totalTimesRead; }
            set
            {
                if (value > totalTimesRead)
                {
                    totalTimesRead = value;
                }
            }
        }

        // Methods
        /// <summary>
        /// Prints information about the book, including it's title, author, number of pages, owner, and total times read. . 
        /// </summary>
        public void Print()
        {
            Console.WriteLine("{0} by {1} has {2} pages.", title, author, numPages);
            Console.WriteLine("It is owned by {0} and has been read {1} times.", owner, totalTimesRead);
        }
    }
}
