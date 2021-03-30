namespace DiagonalDifference
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            int primaryDiagonal = 0;

            for (int i = 0; i < n; i++)
            {
                primaryDiagonal += matrix[i, i];
            }

            int secondaryDiagonal = 0;

            int x = 0;
            int y = n - 1;

            for (int i = 0; i < n; i++)
            {
                secondaryDiagonal += matrix[y--, x++];
            }

            int absoluteDiff = Math.Abs(primaryDiagonal - secondaryDiagonal);

            Console.WriteLine(absoluteDiff);
        }
    }
}