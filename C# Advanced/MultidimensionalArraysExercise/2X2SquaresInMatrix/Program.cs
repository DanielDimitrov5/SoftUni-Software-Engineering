namespace _2X2SquaresInMatrix
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            char[,] matrix = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                char[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            int squares = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char currentCh = matrix[row, col];

                    bool isCoordinateValid = col + 1 <= matrix.GetLength(1) - 1 && row + 1 <= matrix.GetLength(0) - 1;

                    if (isCoordinateValid)
                    {
                        if (matrix[row, col + 1] == currentCh && matrix[row + 1, col] == currentCh && matrix[row + 1, col + 1] == currentCh)
                        {
                            squares++;
                        }
                    }
                }
            }

            Console.WriteLine(squares);
        }
    }
}
