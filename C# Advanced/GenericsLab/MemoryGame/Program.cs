using System;
using System.Collections.Generic;
using System.Linq;

namespace MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            int numberOfMoves = 0;

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                int[] coordinates = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int x = coordinates[0];
                int y = coordinates[1];

                numberOfMoves++;

                if ((x >= 0 && x < elements.Count && y >= 0 && y < elements.Count) && x != y)
                {
                    if (elements[x] == elements[y])
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {elements[x]}!");

                        string itemToRemove = elements[x];

                        elements.RemoveAll(items => items == itemToRemove);

                        if (!elements.Any())
                        {
                            Console.WriteLine($"You have won in {numberOfMoves} turns!");

                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Try again!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input! Adding additional elements to the board");

                    elements.Insert((elements.Count) / 2, $"-{numberOfMoves}a");
                    elements.Insert(elements.Count / 2, $"-{numberOfMoves}a");
                }
            }

            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
