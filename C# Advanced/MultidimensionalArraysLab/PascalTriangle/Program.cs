using System;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[][] triangle = new long[n][];

            for (int row = 0; row < n; row++)
            {
                triangle[row] = new long[row + 1];

                for (int col = 0; col < triangle[row].Length; col++)
                {
                    long sum = 0;

                    if (row - 1 >= 0 && triangle[row - 1].Length > col)
                    {
                        sum += triangle[row - 1][col];
                    }

                    if (row - 1 >= 0 && col - 1 >= 0)
                    {
                        sum += triangle[row - 1][col - 1];
                    }

                    if (sum == 0)
                    {
                        sum = 1;
                    }

                    triangle[row][col] = sum;
                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < triangle[row].Length; col++)
                {
                    Console.Write(triangle[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
