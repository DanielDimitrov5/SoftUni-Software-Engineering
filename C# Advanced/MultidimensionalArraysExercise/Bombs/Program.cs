namespace Bombs
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            string[] coordinates = Console.ReadLine().Split();

            for (int i = 0; i < coordinates.Length; i++)
            {
                int[] currentCoordinates = coordinates[i].Split(',').Select(int.Parse).ToArray();

                int row = currentCoordinates[0];
                int col = currentCoordinates[1];

                int row1 = row - 1;
                int col1 = col - 1;

                if (matrix[row, col] > 0)
                {
                    if (Bombs(matrix, row1, col1))
                    {
                        matrix[row1, col1] -= matrix[row, col];
                    }

                    int row2 = row - 1;
                    int col2 = col;

                    if (Bombs(matrix, row2, col2))
                    {
                        matrix[row2, col2] -= matrix[row, col];
                    }

                    int row3 = row - 1;
                    int col3 = col + 1;

                    if (Bombs(matrix, row3, col3))
                    {
                        matrix[row3, col3] -= matrix[row, col];
                    }

                    int row4 = row;
                    int col4 = col + 1;

                    if (Bombs(matrix, row4, col4))
                    {
                        matrix[row4, col4] -= matrix[row, col];
                    }

                    int row5 = row;
                    int col5 = col - 1;

                    if (Bombs(matrix, row5, col5))
                    {
                        matrix[row5, col5] -= matrix[row, col];
                    }

                    int row6 = row + 1;
                    int col6 = col - 1;

                    if (Bombs(matrix, row6, col6))
                    {
                        matrix[row6, col6] -= matrix[row, col];
                    }

                    int row7 = row + 1;
                    int col7 = col;

                    if (Bombs(matrix, row7, col7))
                    {
                        matrix[row7, col7] -= matrix[row, col];
                    }

                    int row8 = row + 1;
                    int col8 = col + 1;

                    if (Bombs(matrix, row8, col8))
                    {
                        matrix[row8, col8] -= matrix[row, col];
                    }

                    matrix[row, col] = 0;
                }
            }

            int aliveCells = 0;
            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static bool Bombs(int[,] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1) && matrix[row, col] > 0)
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
