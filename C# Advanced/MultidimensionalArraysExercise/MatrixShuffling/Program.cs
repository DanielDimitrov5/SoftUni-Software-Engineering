namespace MatrixShuffling
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rowSize = matrixSize[0];
            int colSize = matrixSize[1];

            string[,] matrix = new string[rowSize, colSize];

            for (int row = 0; row < rowSize; row++)
            {
                string[] input = Console.ReadLine().Split();

                for (int col = 0; col < colSize; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string pattern = @"^((swap) (?<row1>\d+) (?<col1>\d+) (?<row2>\d+) (?<col2>\d+))$";

                Match match = Regex.Match(command, pattern);

                if (match.Success)
                {
                    int row1 = int.Parse(match.Groups["row1"].Value);
                    int col1 = int.Parse(match.Groups["col1"].Value);
                    int row2 = int.Parse(match.Groups["row2"].Value);
                    int col2 = int.Parse(match.Groups["col2"].Value);
                    
                    if (Math.Max(row1, row2) < matrix.GetLength(0) && Math.Max(col1, col2) < matrix.GetLength(1))
                    {
                        string data1 = matrix[row1, col1];
                        string data2 = matrix[row2, col2];

                        matrix[row1, col1] = data2;
                        matrix[row2, col2] = data1;

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                Console.Write(matrix[row, col] + " ");
                            }

                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
