using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int snakeRow = -1;
            int snakeCol = -1;

            char[,] matrix = new char[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }

            int foodEaten = 0;

            while (true)
            {
                string command = Console.ReadLine();

                matrix[snakeRow, snakeCol] = '.';

                switch (command)
                {
                    case "up": snakeRow--; break;
                    case "down": snakeRow++; break;
                    case "left": snakeCol--; break;
                    case "right": snakeCol++; break;
                }

                if (snakeRow < 0 || snakeRow >= n || snakeCol < 0 || snakeCol >= n)
                {
                    Console.WriteLine("Game over!");
                    break;
                }

                if (matrix[snakeRow, snakeCol] == 'B')
                {
                    matrix[snakeRow, snakeCol] = '.';

                    Tuple<int, int> coordinatesOfB = GetCoordinatesOf(matrix, 'B');

                    int bRow = coordinatesOfB.Item1;
                    int bCol = coordinatesOfB.Item2;

                    snakeRow = bRow;
                    snakeCol = bCol;
                }
                else if (matrix[snakeRow, snakeCol] == '*')
                {
                    foodEaten++;
                }

                if (foodEaten == 10)
                {
                    matrix[snakeRow, snakeCol] = 'S';

                    Console.WriteLine("You won! You fed the snake.");
                    break;
                }
            }

            Console.WriteLine($"Food eaten: {foodEaten}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static Tuple<int, int> GetCoordinatesOf(char[,] matrix, char symbol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        return new Tuple<int, int>(row, col);
                    }
                }
            }

            return null;
        }
    }
}
