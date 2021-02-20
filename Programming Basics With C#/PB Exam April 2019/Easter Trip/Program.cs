using System;

namespace Easter_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string date = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            int prisePerNight = 0;

            if (destination == "France")
            {
                if (date == "21-23")
                {
                    prisePerNight = 30;
                }
                else if (date == "24-27")
                {
                    prisePerNight = 35;
                }
                else
                {
                    prisePerNight = 40;
                }
            }
            else if (destination == "Italy")
            {
                if (date == "21-23")
                {
                    prisePerNight = 28;
                }
                else if (date == "24-27")
                {
                    prisePerNight = 32;
                }
                else
                {
                    prisePerNight = 39;
                }
            }
            else if (destination == "Germany")
            {
                if (date == "21-23")
                {
                    prisePerNight = 32;
                }
                else if (date == "24-27")
                {
                    prisePerNight = 37;
                }
                else
                {
                    prisePerNight = 43;
                }
            }

            int totalPrise = prisePerNight * nights;

            Console.WriteLine($"Easter trip to {destination} : {totalPrise:f2} leva.");
        }
    }
}
