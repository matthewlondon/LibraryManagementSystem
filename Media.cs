namespace LibraryManagementSystem;

public class Media : Program
{
    public string? Title { get; set; }
    public string? Author { get; set; }
    public int YearPublished { get; set; }

    public static string ValidAuthor(string choice)
    {
        //excludes all input that are not chars or whitespace
        while (true)
        {
            if (!String.IsNullOrEmpty(choice) && choice.All(c => Char.IsLetter(c) || Char.IsWhiteSpace(c)))
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
        //Ensures input is greater than 0 and less than or equal to current year, only accepting 4-digit ints within
        //those paramteres
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

    //each method below creates list ordered by title, author, or year using lambda expression,
    //only called once in response to user input on case 4 of main switch statement
    public static List<Books> SortByTitle(List<Books> book)
    {
        return book.OrderBy(b => b.Title).ToList();
    }
    public static List<Books> SortByAuthor(List<Books> book)
    {
        return book.OrderBy(b => b.Author).ToList();
    }
    public static List<Books> SortByYear(List<Books> book)
    {
        return book.OrderBy(b => b.YearPublished).ToList();
    }


}

