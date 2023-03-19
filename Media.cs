namespace LibraryManagementSystem;

public class Media : Program
{
    public string? Title { get; set; }
    public string? Author { get; set; }
    public int YearPublished { get; set; }

    public static string ValidAuthor(string choice)
    {

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

