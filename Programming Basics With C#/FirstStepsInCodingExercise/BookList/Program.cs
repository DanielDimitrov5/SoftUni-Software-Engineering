using System;

namespace BookList
{
    class Program
    {
        static void Main(string[] args)
        {
            double pages = double.Parse(Console.ReadLine());
            double pagesForOneHour = double.Parse(Console.ReadLine());
            double days = double.Parse(Console.ReadLine());

            double fullReading = pages / pagesForOneHour;
            double daysNeeded = fullReading / days;

            Console.WriteLine(daysNeeded);
        }
    }
}
