using Microsoft.Win32.SafeHandles;
using System.ComponentModel.Design;

namespace BioBokaren2
{
    internal class Program
    {
       // Movie data
       static string[] movies = { "Draktränaren", "Lilo & Stitch", "Tuffa gänget 2", "Tron: Ares" };
       static string[] movieTimes = { "12:00", "12:15", "18:15", "20:15" };

        // Pricing
        static int moviePrice = 120;

        // Constants
        const double tax_rate = 0.25;
        const double student_discount = 0.15;
        const string currency = "SEK";
        const string student_code = "STUDENT2025";

        // State variables
        static bool isStudent = false;
        static int selectedMovie = 0;
        static int selectedTickets = 0;
        static string selectedTime = "";
        static double totalPrice = 0.0;
        static double CalculatePrice(int tickets, double basePrice)
        {
            return tickets * basePrice;
        }
        static double CalculatePrice(int tickets, double basePrice, double discountPercent)
        {
            return tickets * basePrice * (1 - discountPercent);
        }

        // Helper methods
        static int ReadInt(string prompt, int min, int max)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out int value) && value >= min && value <= max)
                    return value;
                Console.WriteLine("Ogiltigt val, försök igen.");
            }
        }
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
            Console.WriteLine("\nTillgängliga filmer:\n");
            for (int i = 0; i < movies.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {movies[i]} - {movieTimes[i]}");
            }
        }
        static void ChooseMovie()
        {
            ShowMovies();
            selectedMovie = ReadInt("\nVälj en film (1-4): ", 1, movies.Length) - 1;
            selectedTime = movieTimes[selectedMovie];
            Console.WriteLine($"\nDu valde: {movies[selectedMovie]} vid {movieTimes[selectedMovie]}");

            selectedTickets = ReadInt("\nAnge antal biljetter (1-10): ", 1, int.MaxValue);
        }
        static void StudentDiscount()
        {
            if (isStudent)
            {
                Console.WriteLine("\nStudentrabatt är aktiverad.");
                Console.WriteLine("\nVill du avaktivera den? (y/n): ");
                string input = Console.ReadLine();
                if (input?.Trim().ToUpper() == "Y")
                {
                    isStudent = false;
                    Console.WriteLine("\nStudentrabatt borttagen.");
                }
                else
                {
                    Console.WriteLine("\nStudentrabatt kvarstår.");
                }
            }
            else
            {
                Console.WriteLine("\nAnge din rabattkod: ");
                if (Console.ReadLine() == student_code)
                {
                    Console.WriteLine("\nStudentrabatt aktiverad!");
                    isStudent = true;
                }
                else
                {
                    Console.WriteLine("Felaktig kod, ingen rabatt aktiverad.");
                    isStudent = false;
                }
            }
        }
        static void CalculateTotalPrice()
        {
            if (isStudent)
            {
                totalPrice = CalculatePrice(selectedTickets, moviePrice, student_discount) * (1 + tax_rate);
            }
            else
            {
                totalPrice = CalculatePrice(selectedTickets, moviePrice) * (1 + tax_rate);
            }
        }
        static void PrintReceipt()
        {
            CalculateTotalPrice();
            Console.WriteLine("\n--- KVITTO ---");
            Console.WriteLine($"Film: {movies[selectedMovie]}");
            Console.WriteLine($"Tid: {selectedTime}");
            Console.WriteLine($"Antal biljetter: {selectedTickets}");
            Console.WriteLine($"Studentrabatt aktiverad: {(isStudent ? "Ja" : "Nej")}");
            Console.WriteLine($"Totalpris: {totalPrice:F2} {currency}");
            Console.WriteLine("---------------\n");
        }


        // Main program loop
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                ShowMenu();
                Console.WriteLine("Välj ett alternativ (1-5):");
                string menyChoice = Console.ReadLine();

                switch (menyChoice)
                {
                    case "1":
                        ShowMovies();
                        break;

                    case "2":
                        ChooseMovie();
                        break;

                    case "3":
                        StudentDiscount();
                        break;

                    case "4":
                        PrintReceipt();
                        break;

                    case "5":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }
                Console.WriteLine("\nTryck ENTER för att fortsätta");
                Console.ReadKey();
            }
        }
    }
}
