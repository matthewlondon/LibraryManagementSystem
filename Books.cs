namespace LibraryManagementSystem
{
    public class Books : Media
    {
        public int MaxPage { get; set; }
        public int CurrentPage { get; set; }
        public double Progress { get; set; }

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


