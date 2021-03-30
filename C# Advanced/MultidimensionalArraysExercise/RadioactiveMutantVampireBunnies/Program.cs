using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            int playerRow = -1;
            int playerCol = -1;

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];

                    if (input[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            string output = string.Empty;

            int endRow = -1;
            int endCol = -1;

            bool escaped = false;
            bool catched = false;

            Queue<char> moves = new Queue<char>(Console.ReadLine());

            while (moves.Any())
            {
                matrix[playerRow, playerCol] = '.';

                switch (moves.Dequeue())
                {
                    case 'U':
                        playerRow--;
                        break;
                    case 'D':
                        playerRow++;
                        break;
                    case 'L':
                        playerCol--;
                        break;
                    case 'R':
                        playerCol++;
                        break;
                }

                if (playerRow < 0 || playerRow > matrix.GetLength(0) - 1 || playerCol < 0 || playerCol > matrix.GetLength(1) - 1)
                {
                    escaped = true;

                    if (playerRow < 0)
                    {
                        playerRow = 0;
                    }
                    else if (playerRow > matrix.GetLength(0) - 1)
                    {
                        playerRow = matrix.GetLength(0) - 1;
                    }
                    else if (playerCol < 0)
                    {
                        playerCol = 0;
                    }
                    else if (playerCol > matrix.GetLength(1) - 1)
                    {
                        playerCol = matrix.GetLength(1) - 1;
                    }

                    output = $"won: {playerRow} {playerCol}";
                }
                else if (matrix[playerRow, playerCol] == 'B')
                {
                    catched = true;

                    output = $"dead: {playerRow} {playerCol}";
                }
                else
                {
                    matrix[playerRow, playerCol] = 'P';
                }

                Queue<int[]> bunnies = new Queue<int[]>();

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            bunnies.Enqueue(new int[] { row, col });
                        }
                    }
                }

                while (bunnies.Any())
                {
                    int row = bunnies.Peek()[0];
                    int col = bunnies.Peek()[1];

                    if (matrix[Math.Max(0, row - 1), col] == 'P' || matrix[Math.Min(matrix.GetLength(0) - 1, row + 1), col] == 'P' ||
                        matrix[row, Math.Max(0, col - 1)] == 'P' || matrix[row, Math.Min(matrix.GetLength(1) - 1, col + 1)] == 'P')
                    {
                        catched = true;

                        if (matrix[Math.Max(0, row - 1), col] == 'P')
                        {
                            endRow = Math.Max(0, row - 1);
                            endCol = col;
                        }
                        else if (matrix[Math.Min(matrix.GetLength(0) - 1, row + 1), col] == 'P')
                        {
                            endRow = Math.Min(matrix.GetLength(0) - 1, row + 1);
                            endCol = col;
                        }
                        else if (matrix[row, Math.Max(0, col - 1)] == 'P')
                        {
                            endRow = row;
                            endCol = Math.Max(0, col - 1);
                        }
                        else if (matrix[row, Math.Min(matrix.GetLength(1) - 1, col + 1)] == 'P')
                        {
                            endRow = row;
                            endCol = Math.Min(matrix.GetLength(1) - 1, col + 1);
                        }

                        output = $"dead: {endRow} {endCol}";
                    }

                    matrix[Math.Max(0, row - 1), col] = 'B';
                    matrix[Math.Min(matrix.GetLength(0) - 1, row + 1), col] = 'B';
                    matrix[row, Math.Max(0, col - 1)] = 'B';
                    matrix[row, Math.Min(matrix.GetLength(1) - 1, col + 1)] = 'B';

                    bunnies.Dequeue();
                }

                if (escaped || catched)
                {
                    break;
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }

            Console.WriteLine(output);
        }
    }
}
