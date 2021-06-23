using System;
using System.Collections.Generic;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] gardenDimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = gardenDimensions[0];
            int m = gardenDimensions[1];

            int[,] garden = new int[n, m];

            List<int[]> initialFlowers = new List<int[]>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] coordinates = input.Split().Select(int.Parse).ToArray();

                int row = coordinates[0];
                int col = coordinates[1];

                if (row >= 0 && row < n && col >= 0 && col < m)
                {
                    initialFlowers.Add(coordinates);
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
            }

            foreach (var flower in initialFlowers)
            {
                for (int i = 0; i < garden.GetLength(0); i++)
                {
                    garden[flower[0], i]++;
                }

                for (int i = 0; i < garden.GetLength(1); i++)
                {
                    garden[i, flower[1]]++;
                }

                garden[flower[0], flower[1]]--;
            }

            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    Console.Write(garden[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
