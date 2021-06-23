using System;

namespace Re_volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int numberOfCommands = int.Parse(Console.ReadLine());

            int playerX = 0;
            int playerY = 0;

            bool win = false;

            char[,] matrix = new char[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (input[col] == 'f')
                    {
                        playerX = row;
                        playerY = col;
                    }
                }
            }

            for (int i = 0; i < numberOfCommands; i++)
            {
                string command = Console.ReadLine();

                switch (command)
                {
                    case "up":

                        matrix[playerX, playerY] = '-';

                        playerX--;

                        if (playerX < 0)
                        {
                            playerX = matrix.GetLength(0) - 1;
                        }

                        if (matrix[playerX, playerY] == 'B')
                        {
                            playerX--;

                            if (playerX < 0)
                            {
                                playerX = matrix.GetLength(0) - 1;
                            }
                        }
                        else if (matrix[playerX, playerY] == 'T')
                        {
                            playerX++;

                            matrix[playerX, playerY] = 'f';
                        }
                        break;
                    case "down":

                        matrix[playerX, playerY] = '-';

                        playerX++;

                        if (playerX >= matrix.GetLength(0))
                        {
                            playerX = 0;
                        }

                        if (matrix[playerX, playerY] == 'B')
                        {
                            playerX++;

                            if (playerX >= matrix.GetLength(0))
                            {
                                playerX = 0;
                            }
                        }
                        else if (matrix[playerX, playerY] == 'T')
                        {
                            playerX--;

                            matrix[playerX, playerY] = 'f';
                        }
                        break;
                    case "left":

                        matrix[playerX, playerY] = '-';

                        playerY--;

                        if (playerY < 0)
                        {
                            playerY = matrix.GetLength(1) - 1;
                        }

                        if (matrix[playerX, playerY] == 'B')
                        {
                            playerY--;

                            if (playerY < 0)
                            {
                                playerY = matrix.GetLength(1) - 1;
                            }
                        }
                        else if (matrix[playerX, playerY] == 'T')
                        {
                            playerY++;

                            matrix[playerX, playerY] = 'f';
                        }
                        break;
                    case "right":

                        matrix[playerX, playerY] = '-';

                        playerY++;

                        if (playerY >= matrix.GetLength(1))
                        {
                            playerY = 0;
                        }

                        if (matrix[playerX, playerY] == 'B')
                        {
                            playerY++;

                            if (playerY >= matrix.GetLength(1))
                            {
                                playerY = 0;
                            }
                        }
                        else if (matrix[playerX, playerY] == 'T')
                        {
                            playerY--;

                            matrix[playerX, playerY] = 'f';
                        }
                        break;
                }

                if (matrix[playerX, playerY] == 'F')
                {
                    matrix[playerX, playerY] = 'f';

                    Console.WriteLine("Player won!");

                    win = true;
                    break;
                }
            }

            if (!win)
            {
                matrix[playerX, playerY] = 'f';

                Console.WriteLine("Player lost!");
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
