using System;
using System.Linq;

namespace JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsCount = int.Parse(Console.ReadLine());

            int[][] jagged = new int[rowsCount][];

            for (int i = 0; i < rowsCount; i++)
            {
                int[] cols = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jagged[i] = new int[cols.Length];

                for (int j = 0; j < jagged[i].Length; j++)
                {
                    jagged[i][j] = cols[j];
                }
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] array = input.Split();

                string command = array[0];
                int row = int.Parse(array[1]);
                int col = int.Parse(array[2]);
                int value = int.Parse(array[3]);

                if (coordinatesValid(rowsCount, row, col))
                {
                    if (command == "Add")
                    {
                        jagged[row][col] += value;
                    }
                    else if (command == "Subtract")
                    {
                        jagged[row][col] -= value;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }

            }

            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < rowsCount; col++)
                {
                    Console.Write(jagged[row][col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static bool coordinatesValid(int rowsCount, int row, int col)
        {
            if (rowsCount - 1 >= row && row >= 0 && rowsCount - 1 >= col && col >= 0)
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
