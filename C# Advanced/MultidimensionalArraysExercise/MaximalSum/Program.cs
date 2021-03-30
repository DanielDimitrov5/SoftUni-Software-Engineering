namespace MaximalSum
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int squareSize = 3;

            int[] matrixSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int n = matrixSize[0];
            int m = matrixSize[1];

            int[,] matrix = new int[n, m];

            for (int row = 0; row < n; row++)
            {
                int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int maxSum = int.MinValue;
            int bestRowIndex = 0;
            int bestColIndex = 0;

            for (int row = 0; row < matrix.GetLength(0) - squareSize + 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - squareSize + 1; col++)
                {
                    int sum = 0;

                    for (int i = row; i < row + squareSize; i++)
                    {
                        for (int j = col; j < col + squareSize; j++)
                        {
                            sum += matrix[i, j];
                        }
                    }

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        bestRowIndex = row;
                        bestColIndex = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = bestRowIndex; row < bestRowIndex + squareSize; row++)
            {
                for (int col = bestColIndex; col < bestColIndex + squareSize; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
