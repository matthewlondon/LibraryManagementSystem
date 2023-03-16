using System.Runtime.CompilerServices;

namespace LibraryManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to your Personal Library Management System.");
            var recordList = new List<Book>();
            int input;
            while (true)
            {
                Prompt();
                var choiceString = Console.ReadLine();
                while (!int.TryParse(choiceString, out input))
                {
                    Console.WriteLine("Please enter a valid option.");
                    choiceString = Console.ReadLine();
                }

                switch (input)
                {
                    case 1:
                        //need to verify input is only int
                        Console.WriteLine("How many books would you like to add? ");
                        var numberOfBooks = int.Parse(Console.ReadLine());

                        for (int i = 0; i < numberOfBooks; i++)
                        {
                            Book book = new Book();

                            Console.WriteLine("");
                            Console.WriteLine("What is the title?");
                            book.title = Console.ReadLine();

                            Console.WriteLine("What is the author's name?");
                            string choice = Console.ReadLine();
                            book.author = ValidAuthor(choice);

                            Console.WriteLine("What year was the book published");
                            choice = Console.ReadLine();
                            book.yearPublished = ValidYear(choice);

                            Console.WriteLine("How many pages is the book?");
                            choice = Console.ReadLine();
                            book.maxPage = ValidPageCount(choice);

                            //Need to ensure current page does not exceed max page
                            Console.WriteLine("What page are you on?");
                            choice = Console.ReadLine();
                            book.currentPage = ValidPageCount(choice);
                            
                            book.progress = (Decimal.ToDouble(book.currentPage) / Decimal.ToDouble(book.maxPage) * 100);
                            
                            recordList.Add(book);
                            
                        }
                        Console.WriteLine($"You added {numberOfBooks} book(s)");
                        break;

                    case 2:
                        Console.WriteLine("Enter the title of the book to be removed:");
                        var bookTitleToRemove = Console.ReadLine();
                            var bookToRemove = recordList.FirstOrDefault(book => book.title == bookTitleToRemove);

                            if (bookToRemove != null)
                            {
                                recordList.Remove(bookToRemove);
                                Console.WriteLine($"Book '{bookTitleToRemove}' removed successfully.");
                            }
                            else
                            {
                                Console.WriteLine($"Book '{bookTitleToRemove}' not found in the library.");
                            }
                        break;

                    case 3:
                        Console.WriteLine("Check book Progress");
                        foreach (Book book in recordList)
                            Console.WriteLine($"{book.title} : {book.progress}% complete");
                        break;

                    case 4:
                        Console.WriteLine("Listed Book(s)");
                        foreach (Book book in recordList)
                        Console.WriteLine($"{book.title} by {book.author} in {book.yearPublished} : {book.progress}% complete");
                        break;

                    case 5:
                        Console.WriteLine("Exiting the program");
                        return;

                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
        static void Prompt()
        {
            Console.WriteLine("");
            Console.WriteLine("Please enter an option from the list below:");
            Console.WriteLine("1 Add a book");
            Console.WriteLine("2 Remove a book");
            Console.WriteLine("3 Check progress on all books");
            Console.WriteLine("4 List the book(s) in your library");
            Console.WriteLine("5 to exit");
        }

        public static string ValidAuthor(string choice)
        {

            while(true)
            {
                if(!String.IsNullOrEmpty(choice) && choice.All(Char.IsLetter))
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("Invalid input, please try again.");
                    choice = Console.ReadLine();

                }
            }
        }

        public static int ValidYear(string choice)
        {
            while (true)
            {
                if (int.TryParse(choice, out int year) && year > 0 && year <= 2023)
                {
                    return year;
                }
                else
                {
                    Console.WriteLine("Invalid input, please try again");
                    choice = Console.ReadLine();
                }
            }
        }

        public static int ValidPageCount(string choice)
        {
            while (true)
            {
                if (int.TryParse(choice, out int validInt) && validInt >= 0)
                {
                    return validInt;
                }
                else
                {
                    Console.WriteLine("Invalid input, please try again");
                    choice = Console.ReadLine();
                }
            }
        }
    }
}
