using System;

namespace SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            char symbol = char.Parse(Console.ReadLine());

            bool symbolFound = false;

            for (int rows = 0; rows < n; rows++)
            {
                for (int cols = 0; cols < n; cols++)
                {
                    if (matrix[rows, cols] == symbol)
                    {
                        Console.WriteLine($"({rows}, {cols})");

                        symbolFound = true;

                        break;
                    }
                }

                if (symbolFound)
                {
                    break;
                }
            }

            if (!symbolFound)
            {
                Console.WriteLine("{0} does not occur in the matrix", symbol);
            }
        }
    }
}
