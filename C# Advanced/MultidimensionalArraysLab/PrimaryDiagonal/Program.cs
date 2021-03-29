using System;
using System.Linq;

namespace PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];

            for (int i = 0; i < matrixSize; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            int primaryDiagonal = 0;

            for (int i = 0; i < matrixSize; i++)
            {
                primaryDiagonal += matrix[i, i];
            }

            Console.WriteLine(primaryDiagonal);
        }
    }
}
