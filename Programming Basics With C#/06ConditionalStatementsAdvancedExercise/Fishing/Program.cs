using System;

namespace Fishing
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishers = int.Parse(Console.ReadLine());
            double rent = 0;
            double discount = 0;
            double evenDiscount = 1;
            switch (season)
            {
                case "Spring":
                    rent = 3000;
                    break;
                case "Winter":
                    rent = 2600;
                    break;
                default:
                    rent = 4200;
                    break;

            }
            if (fishers <= 6)
            {
                discount = 0.9;
            }
            else if (fishers > 6 && fishers <= 11)
            {
                discount = 0.85;
            }
            else
            {
                discount = 0.75;
            }
            if (fishers % 2 == 0 && season != "Autumn")
            {
                evenDiscount = 0.95;
            }
            double totoalPrise = (rent * discount) * evenDiscount;
            if (budget >= totoalPrise)
            {
                Console.WriteLine($"Yes! You have {budget - totoalPrise:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {totoalPrise - budget:f2} leva.");
            }
            

        }
    }
}
