using System;

namespace FruitMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double strawberriesPrise = double.Parse(Console.ReadLine());
            double amountOfBananas = double.Parse(Console.ReadLine());
            double amountOfOranges = double.Parse(Console.ReadLine());
            double amountOfBlueberries = double.Parse(Console.ReadLine());
            double amountOfStrawberries = double.Parse(Console.ReadLine());

            double blueberriesPrise = strawberriesPrise * 0.5;
            double orangersPrise = blueberriesPrise * 0.6;
            double banansPrise = blueberriesPrise * 0.2;

            double strawberries = strawberriesPrise * amountOfStrawberries;
            double bananas = banansPrise * amountOfBananas;
            double oranges = amountOfOranges * orangersPrise;
            double blueberries = blueberriesPrise * amountOfBlueberries;

            double sum = strawberries + bananas + oranges + blueberries;

            Console.WriteLine(sum);
        }
    }
}
