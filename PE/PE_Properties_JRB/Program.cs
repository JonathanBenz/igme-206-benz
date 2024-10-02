/* Author: Jonathan Benz
 * PE - Properties
 * No known issues */
namespace PE_Properties_JRB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaring variables
            string title;
            string author;
            int numPages;
            string owner;
            int totalTimesRead;

            string userInput;
            bool isDone = false;

            // Prompting for input
            Console.WriteLine("Welcome to Book Simulator 2024\n");

            Console.Write("What is the book's title? ");
            title = Console.ReadLine();

            Console.Write("Who is the book's author? ");
            author = Console.ReadLine();

            Console.Write("How many pages does it have? ");
            numPages = int.Parse(Console.ReadLine());

            Console.Write("Who is the book's current owner? ");
            owner = Console.ReadLine();

            // Instantiating the Book
            Book book = new Book(title, author, numPages, owner);

            // Looping for input
            do
            {
                Console.Write("\nWhat would you like to do? ");
                userInput = Console.ReadLine();

                switch(userInput)
                {
                    case "title":
                        Console.WriteLine("The title is {0}.", book.Title);
                        break;
                    case "author":
                        Console.WriteLine("The author is {0}.", book.Author);
                        break;
                    case "pages":
                        Console.WriteLine("The book has {0} pages.", book.NumPages);
                        break;
                    case "owner":
                        Console.Write("Would you like to change the owner (yes/no)? ");
                        string answer = Console.ReadLine();
                        answer = answer.Trim().ToLower();
                        if (answer.Equals("yes"))
                        {
                            Console.Write("Who is the new owner? ");
                            book.Owner = Console.ReadLine();
                            Console.WriteLine("The new owner is {0}.", book.Owner);
                        }
                        else if (answer.Equals("no"))
                        {
                            Console.WriteLine("Ok, {0} is still the owner.", book.Owner);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input, please try again.");
                        }
                        break;
                    case "read":
                        book.TotalTimesRead++;
                        Console.WriteLine("The total times read is now {0}.", book.TotalTimesRead);
                        break;
                    case "print":
                        book.Print();
                        break;
                    case "done":
                        Console.WriteLine("Goodbye");
                        isDone = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
            }
            while (!isDone);
        }
    }
}
