using System;
using System.Collections.Generic;
using System.Linq;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int coalAmount = 0;

            Queue<string> commands = new Queue<string>(Console.ReadLine().Split());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine().Split().Select(char.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];

                    if (input[col] == 'c')
                    {
                        coalAmount++;
                    }
                }
            }

            int[] start = GetStarPossition(matrix);
            int startRow = start[0];
            int startCol = start[1];

            int coal = 0;

            while (commands.Any())
            {
                bool skipCommand = false;

                switch (commands.Dequeue())
                {
                    case "up":
                        startRow -= 1;

                        if (startRow < 0)
                        {
                            startRow++;
                            skipCommand = true;
                        }
                        break;
                    case "left":
                        startCol -= 1;

                        if (startCol < 0)
                        {
                            startCol++;
                            skipCommand = true;
                        }
                        break;
                    case "right":
                        startCol += 1;

                        if (startCol > matrix.GetLength(1) - 1)
                        {
                            startCol--;
                            skipCommand = true;
                        }
                        break;
                    case "down":
                        startRow += 1;

                        if (startRow > matrix.GetLength(0) - 1)
                        {
                            startRow--;
                            skipCommand = true;
                        }
                        break;
                }

                if (skipCommand == false)
                {
                    char currentChar = matrix[startRow, startCol];

                    if (currentChar == 'e')
                    {
                        Console.WriteLine($"Game over! ({startRow}, {startCol})");
                        Environment.Exit(0);
                    }
                    else if (currentChar == 'c')
                    {
                        coal++;

                        matrix[startRow, startCol] = '*';

                        if (coal == coalAmount)
                        {
                            Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");

                            Environment.Exit(0);
                        }
                    }
                }
            }

            Console.WriteLine($"{coalAmount - coal} coals left. ({startRow}, {startCol})");
        }

        private static int[] GetStarPossition(char[,] matrix)
        {
            bool startFound = false;

            int startRow = 0;
            int startCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 's')
                    {
                        startFound = true;

                        startRow = row;
                        startCol = col;

                        break;
                    }
                }

                if (startFound)
                {
                    break;
                }
            }

            return new int[] { startRow, startCol };
        }
    }
}
