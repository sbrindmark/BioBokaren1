namespace BioBokaren2
{
    internal class Program
    {

       static string[] movies = { "Draktränaren", "Lilo & Stitch", "Tuffa gänget 2", "Tron: Ares" };
       static string[] moviesTimes = { "12:00", "12:15", "18:15", "20:15" };

       static int moviePrice = 120;


        const double tax_rate = 0.25;
        const double student_discount = 0.15;
        const string currency = "SEK";

        static void ShowMenu()
        {
            Console.WriteLine("Välkommen till BioBokaren!\n--------------------------\n");
            Console.WriteLine("1. Lista Filmer");
            Console.WriteLine("2. Välj film & tid, ange biljetter");
            Console.WriteLine("3. Studentrabatt");
            Console.WriteLine("4. Skriv ut kvitto");
            Console.WriteLine("5. Avsluta");
        }

        static void ShowMovies()
        {
            Console.WriteLine("\nTillgängliga filmer:");
            for (int i = 0; i < movies.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {movies[i]} - {moviesTimes[i]}");
            }
        }
        static void ChooseMovie()
        {
            ShowMovies();

            Console.WriteLine("\nVälj en film genom att ange dess nummer:");
            int movieChoice = int.Parse(Console.ReadLine()) - 1;
            Console.WriteLine($"Du valde: {movies[movieChoice]} vid {moviesTimes[movieChoice]}");
            Console.WriteLine("Ange antal biljetter:");
            int ticketCount = int.Parse(Console.ReadLine());
        }


        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                ShowMenu();
                Console.WriteLine("Välj ett alternativ (1-5):");
                int menyChoice= int.Parse(Console.ReadLine());

                switch (menyChoice)
                {
                    case 1:
                        ShowMovies();
                        break;
                    case 2:
                        ChooseMovie();
                        break;
                    case 3:
                        // Implement student discount logic
                        break;
                    case 4:
                        // Implement receipt printing logic
                        break;
                    case 5:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }
            }
        }
    }
}
