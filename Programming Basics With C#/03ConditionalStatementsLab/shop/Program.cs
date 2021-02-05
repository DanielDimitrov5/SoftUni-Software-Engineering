using System;
using System.Net.Sockets;

namespace shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double excursionPrice = double.Parse(Console.ReadLine());
            int puzzles = int.Parse(Console.ReadLine());
            int doll = int.Parse(Console.ReadLine());
            int teddyBear = int.Parse(Console.ReadLine());
            int minion = int.Parse(Console.ReadLine());
            int truck = int.Parse(Console.ReadLine());

            int soldToys = puzzles + doll + teddyBear + minion + truck;

            double puzzlesSold = puzzles * 2.60;
            double dollSold = doll * 3;
            double teddyBearSold = teddyBear * 4.10;
            double minionSold = minion * 8.20;
            double truckSold = truck * 2;
            
            double totalSum = puzzlesSold +dollSold + teddyBearSold + minionSold + truckSold;

            if (soldToys >= 50)
            {
                double discount = totalSum * 0.25;
                double afterDiscount = totalSum - discount;
                double rent = afterDiscount * 0.1;
                double afterRent = afterDiscount - rent;
                if (afterRent > excursionPrice)
                {
                    double moneyLeft = afterRent - excursionPrice;
                    Console.WriteLine($"Yes! {moneyLeft:F2} lv left.");

                }
            }
                else
            {
                Console.WriteLine($"Not enough money! {excursionPrice - totalSum * 0.9:f2} lv needed.");
            }
            
               


            
        }
    }
}
