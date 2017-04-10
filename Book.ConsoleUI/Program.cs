using System;
using Book.Comparers;
using Book.Services;
using Book.Storages;
using Book.UserExceptions;

namespace Book.ConsoleUI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("=== Test Equals ===");
            Book romAndJul = new Book("Romeo and Juliet", "William Shakespeare", "tradegy", 171);
            Book romAndJulCopy = new Book("Romeo and Juliet", "William Shakespeare", "tradegy", 171);

            Console.WriteLine(romAndJul);
            Console.WriteLine(romAndJulCopy);
            Console.WriteLine("Are equals? {0}", romAndJul.Equals(romAndJulCopy) ? "Yes" : "No");

            Console.WriteLine();

            Book almostRomAndJul = new Book("Almost Romeo and Juliet", "William Shakespeare", "tradegy", 170);

            Console.WriteLine(romAndJul);
            Console.WriteLine(almostRomAndJul);
            Console.WriteLine("Are equals? {0}", romAndJul.Equals(almostRomAndJul) ? "Yes" : "No");
            Console.WriteLine("==== end Test Equals ====");

            Console.WriteLine();
            Console.WriteLine("=== Test GetHashCode ===");

            Console.WriteLine("Different books:");
            Console.WriteLine($"{romAndJul.GetHashCode()} and {almostRomAndJul.GetHashCode()}");
            Console.WriteLine("The same books:");
            Console.WriteLine($"{romAndJul.GetHashCode()} and {romAndJulCopy.GetHashCode()}");
            Console.WriteLine("=== end Test GetHashCode ===");

            Console.WriteLine();
            Console.WriteLine("===== Test BookListStorage =====");

            Book myBook = new Book("Death Note", "Andrei Khotko", "Detective", 100);
            Book parasyte = new Book("Parasyte", "Hey Layla", "Horror", 1021);
            Book elfenLied = new Book("Elfen Lied", "Hayavo Miodzaki", "Comedy", 94);

            BookListService service = new BookListService();


            try
            {
                service.AddBook(myBook);
                service.AddBook(parasyte);
                service.AddBook(elfenLied);
                service.AddBook(almostRomAndJul);
                service.AddBook(romAndJul);
                service.AddBook(romAndJulCopy); // Exception here
            }
            catch (DuplicateBookException ex)
            {
                Console.WriteLine($"Error : {ex.Message}"); // temporary substitution of logging, SO SORRY FOR THAT :(
                //Do logging
            }

            Book result = service.FindBookByTag(b => b.Name == "Elfen Lied");
            Console.WriteLine($"Result of FindBookByTag Name = ElfnLied : {result}");

            PrintService(service, "Before sort");

            service.SortBooksByTag(new NameComparer());

            PrintService(service, "After sort");
            Console.WriteLine("=== end Test BookListStorage ===");

            string fileName = "storage.bin";
            Console.WriteLine($"Saving storage to file {fileName}...");

            IBookListStorage storage = new BinaryFileStorage(fileName);
            service.SaveStorage(storage);

            var newService = new BookListService();;
            newService.LoadStorage(storage);

            newService.RemoveBook(myBook);

            PrintService(newService, "New Service");
            Console.ReadLine();
        }

        private static void PrintService(BookListService service, string message = "Printing service")
        {
            Console.WriteLine($"=== {message} ===");
            foreach (Book book in service)
                Console.WriteLine(book);

            Console.WriteLine($"=======================");
            Console.WriteLine();
        }
    }
}
