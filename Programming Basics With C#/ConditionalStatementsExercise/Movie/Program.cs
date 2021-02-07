using System;

namespace Movie
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int mutes = int.Parse(Console.ReadLine());
            double clothingPrise = double.Parse(Console.ReadLine());

            double decorPrise = budget * 0.1;
            double totalClothingPrise = clothingPrise * mutes;
            if (mutes >= 150)
            {
                totalClothingPrise = totalClothingPrise * 0.9;
            }
            double totalMoneyNeeded = decorPrise + totalClothingPrise;
            if (budget >= totalMoneyNeeded)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget - totalMoneyNeeded:f2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {totalMoneyNeeded - budget:f2} leva more.");
            }

        }
    }
}
