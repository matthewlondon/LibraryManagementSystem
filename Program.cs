namespace LibraryManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to your Personal Library Management System.");
            var Library = new List<Books>();
            while (true)
            {
                Prompt();
               int input = ValidInt(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        AddBook(Library);
                        break;

                    case 2:
                        RemoveBook(Library);
                        break;

                    case 3:
                        Console.WriteLine("Check book Progress");
                        foreach (Books book in Library)
                            Console.WriteLine($"{book.Title} : {book.Progress}% complete");
                        break;

                    case 4:
                        Console.WriteLine("Enter 1 to sort by title");
                        Console.WriteLine("Enter 2 to sort by author");
                        Console.WriteLine("Enter 3 to sort by publication year");
                        input = ValidInt(Console.ReadLine());
                        switch(input)
                        { 
                            case 1:
                                Console.WriteLine("Listed Book(s)");
                                var sortedByTitle = Books.SortByTitle(Library);
                                foreach (var book in sortedByTitle)
                                    Console.WriteLine($"{book.Title} by {book.Author} in {book.YearPublished}");
                                break;
                            case 2:
                                Console.WriteLine("Listed Book(s)");
                                var sortedByAuthor = Books.SortByAuthor(Library);
                                foreach (var book in sortedByAuthor)
                                    Console.WriteLine($"{book.Title} by {book.Author} in {book.YearPublished}");
                                break;
                            case 3:
                                Console.WriteLine("Listed Book(s)");
                                var sortedByYear = Books.SortByYear(Library);
                                foreach (var book in sortedByYear)
                                    Console.WriteLine($"{book.Title} by {book.Author} in {book.YearPublished}");
                                break;
                        }

                        //foreach (Books book in Library)
                        //    Console.WriteLine($"{book.Title} by {book.Author} : {book.YearPublished}");
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
            Console.WriteLine("");
        }
        public static int ValidInt(string choice)
        {
            while (true)
            {
                if (int.TryParse(choice, out int year))
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

        public static void AddBook(List<Books> Library)
        {
            Console.WriteLine("How many books would you like to add? ");
            var numberOfBooks = ValidInt(Console.ReadLine());

            for (int i = 0; i < numberOfBooks; i++)
            {
                Books book = new();

                Console.WriteLine("");
                Console.WriteLine("What is the title?");
                book.Title = Console.ReadLine();

                Console.WriteLine("What is the author's name?");
                string choice = Console.ReadLine();
                book.Author = Books.ValidAuthor(choice);

                Console.WriteLine("What year was the book published");
                choice = Console.ReadLine();
                book.YearPublished = Books.ValidYear(choice);

                Console.WriteLine("How many pages is the book?");
                choice = Console.ReadLine();
                book.MaxPage = Books.ValidPageCount(choice);

                Console.WriteLine("What page are you on?");
                choice = Console.ReadLine();
                book.CurrentPage = Books.ValidPageCount(choice);
                while (book.CurrentPage > book.MaxPage)
                {
                    Console.WriteLine("What page are you on?");
                    choice = Console.ReadLine();
                    book.CurrentPage = Books.ValidPageCount(choice);
                }
                book.Progress = Math.Round((Decimal.ToDouble(book.CurrentPage) / Decimal.ToDouble(book.MaxPage) * 100), 0);

                Library.Add(book);

            }
            Console.WriteLine($"You added {numberOfBooks} book(s)");
        }

        public static void RemoveBook(List<Books> Library)
        {
            if (Library.Count == 0)
            {
                Console.WriteLine("Your library is empty.");
                return;
            }
            Console.WriteLine("Enter the title of the book to be removed:");
            var bookTitleToRemove = Console.ReadLine();
            var bookToRemove = Library.FirstOrDefault(book => book.Title == bookTitleToRemove);

            if (bookToRemove != null)
            {
                Library.Remove(bookToRemove);
                Console.WriteLine($"Book '{bookTitleToRemove}' removed successfully.");
            }
            else
            {
                Console.WriteLine($"'{bookTitleToRemove}' not found in the library.");
            }
        }
    }
}