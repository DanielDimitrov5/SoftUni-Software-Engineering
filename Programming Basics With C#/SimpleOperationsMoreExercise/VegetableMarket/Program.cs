using System;

namespace VegetableMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double vegetablesPrisePerKilogram = double.Parse(Console.ReadLine());
            double fruitsPrisePerKilogram = double.Parse(Console.ReadLine());
            double vegetablesTotalKilograms = double.Parse(Console.ReadLine());
            double fruitsTotalKilograms = double.Parse(Console.ReadLine());

            double proffitFromVegetable = vegetablesPrisePerKilogram * vegetablesTotalKilograms;
            double proffitFromFruits = fruitsPrisePerKilogram * fruitsTotalKilograms;

            double sum = proffitFromVegetable + proffitFromFruits;

            double levaToEuro = sum / 1.94;

            Console.WriteLine($"{levaToEuro:f2}");
        }
    }
}
