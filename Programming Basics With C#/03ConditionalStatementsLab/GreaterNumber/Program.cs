using System;

namespace Toy_Shop
    {
        class Program
        {
            static void Main(string[] args)
            {
                double holidayPrice = double.Parse(Console.ReadLine());
                double puzzleNum = double.Parse(Console.ReadLine());
                double speakingToysNum = double.Parse(Console.ReadLine());
                double toyNum = double.Parse(Console.ReadLine());
                double minionsNum = double.Parse(Console.ReadLine());
                double trucks = double.Parse(Console.ReadLine());

                double numAllToys = puzzleNum + speakingToysNum + toyNum + minionsNum + trucks;

                double pricePuzzle = puzzleNum * 2.60;
                double priceSpeakingToy = speakingToysNum * 3.0;
                double priceToy = toyNum * 4.10;
                double priceMinions = minionsNum * 8.20;
                double priceTrucks = trucks * 2;

                double allToysPrice = pricePuzzle + priceSpeakingToy + priceToy + priceMinions + priceTrucks;

                if (numAllToys >= 50)
                {
                    allToysPrice += -(allToysPrice * 0.25);
                }

                allToysPrice += -(allToysPrice * 0.10);

                if (allToysPrice >= holidayPrice)
                {
                    Console.WriteLine($"Yes! {allToysPrice - holidayPrice:f2} lv left.");
                }
                else
                {
                    Console.WriteLine($"Not enough money! {holidayPrice - allToysPrice:f2} lv needed.");
                }
            }
        }
    }

    

