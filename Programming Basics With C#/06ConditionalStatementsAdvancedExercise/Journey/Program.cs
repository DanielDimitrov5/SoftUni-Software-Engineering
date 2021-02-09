using System;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string destination = "";
            double spendableMoney = 0;
            string campOrHotel = "";
            if (budget <= 100)
            {
                destination = "Bulgaria";
                if (season == "summer")
                {
                    spendableMoney = 0.3;
                }
                else
                {
                    spendableMoney = 0.7;
                }
            }
            else if (budget <= 1000)
            {
                destination = "Balkans";
                if (season == "summer")
                {
                    spendableMoney = 0.4;
                }
                else
                {
                    spendableMoney = 0.8;
                }
            }
            else
            {
                destination = "Europe";
                spendableMoney = 0.9;
            }
            if (destination == "Europe" || season == "winter")
            {
                campOrHotel = "Hotel";
            }
            else
            {
                campOrHotel = "Camp";
            }
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{campOrHotel} - {budget * spendableMoney:f2}");
        }
        
    }
}
