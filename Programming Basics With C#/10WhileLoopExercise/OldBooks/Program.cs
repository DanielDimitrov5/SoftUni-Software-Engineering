using System;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            string book = Console.ReadLine();
            int newBookCounter = 0;

            while (true)
            {
                string newBook = Console.ReadLine();
                newBookCounter++;
                if (newBook == "No More Books")
                {
                    Console.WriteLine($"The book you search is not here!\nYou checked {newBookCounter - 1} books.");
                    break;
                }
                if (newBook == book)
                {
                    Console.WriteLine($"You checked {newBookCounter - 1} books and found it.");
                    break;
                }

            }
        }
    }
}
