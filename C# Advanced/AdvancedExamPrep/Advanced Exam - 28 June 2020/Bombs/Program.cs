using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> bombs = new Dictionary<int, string>()
            {
                { 40, "Datura Bombs" },
                { 60, "Cherry Bombs" },
                { 120, "Smoke Decoy Bombs" }
            };

            Dictionary<string, int> createdBombs = new Dictionary<string, int>()
            {
                { "Datura Bombs" , 0 },
                { "Cherry Bombs" , 0 },
                { "Smoke Decoy Bombs", 0 }
            };

            Queue<int> bombEffects = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> bombCasings = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            while (bombEffects.Any() && bombCasings.Any() && createdBombs.Any(x => x.Value < 3))
            {
                int bomb = bombEffects.Peek() + bombCasings.Peek();

                if (bombs.ContainsKey(bomb))
                {
                    createdBombs[bombs[bomb]]++;

                    bombEffects.Dequeue();
                    bombCasings.Pop();

                    continue;
                }

                bombCasings.Push(bombCasings.Pop() - 5);
            }

            Console.WriteLine(createdBombs.All(x => x.Value >= 3) ? "Bene! You have successfully filled the bomb pouch!" :
                                                                    "You don't have enough materials to fill the bomb pouch.");

            Console.WriteLine($"Bomb Effects: {(bombEffects.Any() ? string.Join(", ", bombEffects) : "empty")}");

            Console.WriteLine($"Bomb Casings: {(bombCasings.Any() ? string.Join(", ", bombCasings) : "empty")}");

            foreach (var bomb in createdBombs.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }
    }
}
