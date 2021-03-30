using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double[][] matrix = new double[n][];

            for (int row = 0; row < n; row++)
            {
                double[] input = Console.ReadLine().Split().Select(double.Parse).ToArray();

                matrix[row] = input;
            }

            for (int row = 0; row < n - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int i = 0; i < matrix[row].Length; i++)
                    {
                        matrix[row][i] *= 2;
                        matrix[row + 1][i] *= 2;
                    }
                }
                else
                {
                    for (int i = 0; i < matrix[row].Length; i++)
                    {
                        matrix[row][i] /= 2;
                    }

                    for (int j = 0; j < matrix[row + 1].Length; j++)
                    {
                        matrix[row + 1][j] /= 2;
                    }
                }
            }

            string inputCommand = string.Empty;

            while ((inputCommand = Console.ReadLine()) != "End")
            {
                string[] commandArray = inputCommand.Split();

                string command = commandArray[0];

                int row = int.Parse(commandArray[1]);
                int col = int.Parse(commandArray[2]);

                int value = int.Parse(commandArray[3]);

                bool validCoordinates = row >= 0 && matrix.Length > row && col >= 0 && matrix[row].Length > col;

                if (validCoordinates)
                {
                    switch (command)
                    {
                        case "Add":
                            matrix[row][col] += value;
                            break;
                        case "Subtract":
                            matrix[row][col] -= value;
                            break;
                    }
                }
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row]));
            }
        }
    }
}
