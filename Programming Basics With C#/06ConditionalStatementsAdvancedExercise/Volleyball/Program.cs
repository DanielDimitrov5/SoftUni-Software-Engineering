using System;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfYear = Console.ReadLine();
            double p = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            double weekendsPerYear = 48.0;
            double weekendsInSofia = 0.0;
            double soturdayGamesSofia = 0.0;
            double holidays = 0.6666666666666667;
            double holidaysGames = 0.0;
            double gamesInSofia = 0.0;
            double moreGames = 1.0;
            weekendsInSofia = weekendsPerYear - h;
            soturdayGamesSofia = weekendsInSofia * 0.75;
            holidaysGames = p * holidays;
            gamesInSofia = soturdayGamesSofia + holidaysGames + h;
            if (typeOfYear == "leap")
            {
                moreGames = 1.15;
            }

            Console.WriteLine(Math.Floor(gamesInSofia * moreGames));
        }
    }
}
