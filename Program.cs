namespace LibraryManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var Library = new List<Books>();
            FindLibrary(Library);
            Console.WriteLine("Welcome to your Personal Library Management System.");

            //start master loop
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
                        //print a list of all books with their respective progress level
                        Console.WriteLine("");
                        foreach (Books book in Library)
                            Console.WriteLine($"{book.Title} : {book.Progress}% complete");
                        break;

                    case 4:
                        SortBook(Library);
                        break;
                    case 5:
                        SaveLibrary(Library);
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

        //Tries to parse input string as int, returns if true and reprompts if else.
        //this method is called several times when retrieving user input
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
            Console.WriteLine("");
            Console.WriteLine("How many books would you like to add? ");
            var numberOfBooks = ValidInt(Console.ReadLine());

            //Where the user enters all properties of the book they're adding, several helper methods to 
            //validate input
            for (int i = 0; i < numberOfBooks; i++)
            {
                Books book = new();

                Console.WriteLine("");
                Console.WriteLine("What is the title?");
                book.Title = Console.ReadLine().ToLower();

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

                //Ensures that user does not enter a current page that is larger than the total
                //number of pages in the book.
                while (book.CurrentPage > book.MaxPage)
                {
                    Console.WriteLine("What page are you on?");
                    choice = Console.ReadLine();
                    book.CurrentPage = Books.ValidPageCount(choice);
                }

                //current page divided by max page and rounded to the nearest whole number for easier handling
                book.Progress = Math.Round((Decimal.ToDouble(book.CurrentPage) / Decimal.ToDouble(book.MaxPage) * 100), 0);

                Library.Add(book);

            }

            //lets the user know the number of books entered after each batch of book entries
            Console.WriteLine($"You added {numberOfBooks} book(s)");
        }

        public static void RemoveBook(List<Books> Library)
        {
            //library is empty if the collection has no data, otherwise continue logic of RemoveBook
            if (Library.Count == 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Your library is empty.");
                return;
            }
            Console.WriteLine("Enter the title of the book to be removed:");

            //tolower the input to standardize validation
            var bookTitleToRemove = Console.ReadLine().ToLower();

            //check if bookTitleToRemove matches any book.Title in book and remove that instance
            var bookToRemove = Library.FirstOrDefault(book => book.Title == bookTitleToRemove);

            if (bookToRemove == null)
            {
                Console.WriteLine($"'{bookTitleToRemove}' not found in the library.");
            }
            else
            {
                Library.Remove(bookToRemove);
                Console.WriteLine($"Book '{bookTitleToRemove}' removed successfully.");
            }
        }

        public static void SortBook(List<Books> Library)
        {
            if (Library.Count == 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Your library is empty.");
                return;
            }
            Console.WriteLine("Enter 1 to sort by title");
            Console.WriteLine("Enter 2 to sort by author");
            Console.WriteLine("Enter 3 to sort by publication year");
            var input = ValidInt(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.WriteLine("");
                    var sortedByTitle = Books.SortByTitle(Library);
                    foreach (var book in sortedByTitle)
                        Console.WriteLine($"{book.Title} by {book.Author} in {book.YearPublished}");
                    break;
                case 2:
                    Console.WriteLine("");
                    var sortedByAuthor = Books.SortByAuthor(Library);
                    foreach (var book in sortedByAuthor)
                        Console.WriteLine($"{book.Title} by {book.Author} in {book.YearPublished}");
                    break;
                case 3:
                    Console.WriteLine("");
                    var sortedByYear = Books.SortByYear(Library);
                    foreach (var book in sortedByYear)
                        Console.WriteLine($"{book.Title} by {book.Author} in {book.YearPublished}");
                    break;
            }
        }

        //Checks for existence of library.txt, first time users will not have this file and it
        //will be created upon exit with method call to SaveLibrary
        public static void FindLibrary(List<Books> Library)
        {
            if (File.Exists("library.txt"))
            {
                string[] lines = File.ReadAllLines("library.txt");

                foreach (string line in lines)
                {
                    string[] details = line.Split(',');
                    Books book = new()
                    {
                        Title = details[0],
                        Author = details[1],
                        YearPublished = int.Parse(details[2]),
                        MaxPage = int.Parse(details[3]),
                        CurrentPage = int.Parse(details[4]),
                        Progress = int.Parse(details[5])
                    };
                    Library.Add(book);
                }
            }

        }

        public static void SaveLibrary(List<Books> Library)
        {
            //write all entries to library.txt, next time user opend console application their entries
            //will populate the library and upon will create new library.txt with all entries
            using StreamWriter writer = new("library.txt");
            foreach (Books book in Library)
            {
                writer.WriteLine($"{book.Title},{book.Author},{book.YearPublished},{book.MaxPage},{book.CurrentPage},{book.Progress}");
            }
        }
    }
}