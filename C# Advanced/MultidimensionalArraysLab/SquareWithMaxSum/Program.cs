namespace SquareWithMaxSum
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rowCount = rowsAndCols[0];
            int colCount = rowsAndCols[1];

            int[,] matrix = new int[rowCount, colCount];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            int maxValue = int.MinValue;
            int bestRowIndex = 0;
            int bestColIndex = 0;

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int currentValue = 0;

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {

                    if (validSquare(matrix, rows, cols))
                    {
                        currentValue = matrix[rows, cols] + matrix[rows, cols + 1] + matrix[rows + 1, cols] + matrix[rows + 1, cols + 1];

                        if (currentValue > maxValue)
                        {
                            maxValue = currentValue;
                            bestRowIndex = rows;
                            bestColIndex = cols;
                        }
                    }
                }
            }

            for (int i = bestRowIndex; i < bestRowIndex + 2; i++)
            {
                for (int j = bestColIndex; j < bestColIndex + 2; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(maxValue);
        }

        private static bool validSquare(int[,] matrix, int rows, int cols)
        {
            if (rows + 1 <= matrix.GetLength(0) - 1 && cols + 1 <= matrix.GetLength(1) - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
