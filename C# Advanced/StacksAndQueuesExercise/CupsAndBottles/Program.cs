namespace CupsAndBottles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine()
                .Split()
                .Reverse()
                .Select(int.Parse)
                .ToArray();

            int[] filledBottles = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> cups = new Stack<int>(cupsCapacity);

            Stack<int> bottles = new Stack<int>(filledBottles);

            int wastedWater = 0;

            while (true)
            {
                if (cups.Any() == false)
                {
                    Console.WriteLine($"Bottles: {string.Join(' ', bottles)}");
                    break;
                }

                if (bottles.Any() == false)
                {
                    Console.WriteLine($"Cups: {string.Join(' ', cups)}");
                    break;
                }

                int currentCup = cups.Peek();

                int currentBottle = bottles.Peek();

                if (currentBottle < currentCup)
                {
                    cups.Push(cups.Pop() - bottles.Pop());
                }
                else
                {
                    wastedWater += bottles.Pop() - cups.Pop();
                }
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
