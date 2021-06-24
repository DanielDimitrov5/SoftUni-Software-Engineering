using System;

namespace Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                char[] chars = Console.ReadLine().ToCharArray();

                for (int j = 0; j < n; j++)
                {

                    matrix[i, j] = chars[j];
                }
            }

            Tuple<int, int> coordinates = GetCoordinates(matrix, 'S');

            int row = coordinates.Item1;
            int col = coordinates.Item2;

            matrix[row, col] = '-';

            int sum = 0;

            while (true)
            {
                if (sum >= 50)
                {
                    Console.WriteLine("Good news! You succeeded in collecting enough money!");
                    matrix[row, col] = 'S';
                    break;
                }

                string command = Console.ReadLine();

                switch (command)
                {
                    case "up": row--; break;
                    case "down": row++; break;
                    case "left": col--; break;
                    case "right": col++; break;
                }

                if (row < 0 || row >= n || col < 0 || col >= n)
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    break;
                }

                if (char.IsDigit(matrix[row, col]))
                {
                    sum += int.Parse(matrix[row, col].ToString());

                    matrix[row, col] = '-';
                }
                else if (matrix[row, col] == 'O')
                {
                    matrix[row, col] = '-';

                    Tuple<int, int> pillarCoordinates = GetCoordinates(matrix, 'O');

                    row = pillarCoordinates.Item1;
                    col = pillarCoordinates.Item2;

                    matrix[row, col] = '-';
                }
            }

            Console.WriteLine($"Money: {sum}");

            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    Console.Write(matrix[r, c]);
                }
                Console.WriteLine();
            }
        }

        public static Tuple<int, int> GetCoordinates(char[,] matrix, char ch)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] == ch)
                    {
                        return new Tuple<int, int>(r, c);
                    }
                }
            }

            return null;
        }
    }
}
