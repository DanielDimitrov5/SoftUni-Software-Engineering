using System;
using System.Linq;

namespace SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rowsCount = matrixSize[0];
            int colsCount = matrixSize[1];

            int[,] matrix = new int[rowsCount, colsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < colsCount; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            for (int cols = 0; cols < matrix.GetLength(1); cols++)
            {
                int colSum = 0;

                for (int rows = 0; rows < matrix.GetLength(0); rows++)
                {
                    colSum += matrix[rows, cols];
                }

                Console.WriteLine(colSum);

                colSum = 0;
            }
        }
    }
}
