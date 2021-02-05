using System;

namespace ToyShop
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
            double totalSum = puzzles * 2.60 + doll * 3 + teddyBear * 4.10 + minion * 8.20 + truck * 2;
            double toysSold = puzzles + doll + teddyBear + minion + truck;

            if (toysSold >= 50)
            {
                totalSum = totalSum * 0.75;
            }
                totalSum = totalSum * 0.9;
            if (totalSum >= excursionPrice)
            {
                Console.WriteLine($"Yes! {totalSum - excursionPrice:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {excursionPrice - totalSum:f2} lv needed.");
            }
            

            
                


            


        }
    }
}
