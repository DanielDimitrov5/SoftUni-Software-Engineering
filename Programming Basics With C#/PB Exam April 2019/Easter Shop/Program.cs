using System;

namespace Easter_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingAmountOfEggs = int.Parse(Console.ReadLine());
            int eggsSold = 0;
            int sold = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Close")
                {
                    Console.WriteLine("Store is closed!");
                    Console.WriteLine($"{eggsSold} eggs sold.");
                    break;
                }
                if (command == "Buy")
                {
                    int eggs = int.Parse(Console.ReadLine());
                    startingAmountOfEggs -= eggs;
                    eggsSold += eggs;
                    sold = eggs;
                }
                else
                {
                    int eggs = int.Parse(Console.ReadLine());
                    startingAmountOfEggs += eggs;
                }
                if (startingAmountOfEggs < 0)
                {
                    Console.WriteLine($"Not enough eggs in store!");
                    Console.WriteLine($"You can buy only {startingAmountOfEggs + sold}.");
                    break;
                }
            }
        }
    }
}
