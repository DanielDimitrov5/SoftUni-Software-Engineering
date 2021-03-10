namespace KeyRevolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrise = int.Parse(Console.ReadLine());

            int barrelSize = int.Parse(Console.ReadLine());

            int[] bulletsArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            
            int[] locksArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int prize = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(bulletsArray);

            Queue<int> locks = new Queue<int>(locksArray);

            int bulletsInitialCount = bullets.Count;

            int roundsCounter = 0;

            while (locks.Any())
            {
                if (bullets.Any() == false)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");

                    Environment.Exit(0);
                }

                if (bullets.Pop() <= locks.Peek())
                {
                    locks.Dequeue();

                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                roundsCounter++;

                if (roundsCounter == barrelSize && bullets.Any())
                {
                    Console.WriteLine("Reloading!");

                    roundsCounter = 0;
                }
            }

            int earnedMoney = prize - (bulletsInitialCount - bullets.Count) * bulletPrise;

            Console.WriteLine($"{bullets.Count} bullets left. Earned ${earnedMoney}");
        }
    }
}
