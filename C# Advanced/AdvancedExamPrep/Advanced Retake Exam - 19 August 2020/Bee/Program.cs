using System;

namespace Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int BeeRow = -1;
            int BeeCol = -1;

            char[,] matrix = new char[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (input[col] == 'B')
                    {
                        BeeRow = row;
                        BeeCol = col;
                    }
                }
            }

            int pollinatedFlowers = 0;

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                matrix[BeeRow, BeeCol] = '.';

                switch (command)
                {
                    case "up": BeeRow--; break;
                    case "down": BeeRow++; break;
                    case "left": BeeCol--; break;
                    case "right": BeeCol++; break;
                }

                if (IsOutside(matrix, BeeRow, BeeCol))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (matrix[BeeRow, BeeCol] == 'O')
                {
                    matrix[BeeRow, BeeCol] = '.';

                    switch (command)
                    {
                        case "up": BeeRow--; break;
                        case "down": BeeRow++; break;
                        case "left": BeeCol--; break;
                        case "right": BeeCol++; break;
                    }

                    if (IsOutside(matrix, BeeRow, BeeCol))
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }
                }

                if (matrix[BeeRow, BeeCol] == 'f')
                {
                    pollinatedFlowers++;
                }

                matrix[BeeRow, BeeCol] = 'B';
            }

            if (pollinatedFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowers} flowers more");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static bool IsOutside(char[,] matrix, int beeRow, int beeCol)
        {
            if (beeRow < 0 || beeRow >= matrix.GetLength(0) || beeCol < 0 || beeCol >= matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }
    }
}
