namespace SnakeMoves
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            char[,] matrix = new char[rows, cols];

            string word = Console.ReadLine();

            string fullWord = string.Empty;

            for (int i = 0; i < (rows * cols) / word.Length; i++)
            {
                fullWord += word;
            }

            for (int i = 0; i < (rows * cols) % word.Length; i++)
            {
                fullWord += word[i];
            }

            for (int i = 0; i < fullWord.Length;)
            {
                for (int j = 0; j < rows; j++)
                {
                    for (int k = 0; k < cols; k++)
                    {
                        matrix[j, k] = fullWord[i];
                        i++;
                    }

                    j++;

                    if (matrix.GetLength(0) > j)
                    {
                        for (int l = cols - 1; l >= 0; l--)
                        {
                            matrix[j, l] = fullWord[i];
                            i++;
                        }
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
