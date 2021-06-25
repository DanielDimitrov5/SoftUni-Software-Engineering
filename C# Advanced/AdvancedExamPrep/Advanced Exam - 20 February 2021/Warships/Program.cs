using System;
using System.Linq;

namespace Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[] attackCoordinates = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);

            int playerOneShips = 0;
            int playerTwoShips = 0;

            char[,] matrix = new char[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == '<')
                    {
                        playerOneShips++;
                    }
                    else if (matrix[row, col] == '>')
                    {
                        playerTwoShips++;
                    }
                }
            }

            int totalShips = playerOneShips + playerTwoShips;

            bool isDraw = true;

            foreach (var coordinates in attackCoordinates)
            {
                int[] splited = coordinates.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int x = splited[0];
                int y = splited[1];

                if (ValidateCoordinates(matrix, x, y))
                {
                    switch (matrix[x, y])
                    {
                        case '>':
                            matrix[x, y] = 'X';
                            playerTwoShips--;
                            break;
                        case '<':
                            matrix[x, y] = 'X';
                            playerOneShips--;
                            break;
                        case '#':

                            if (ValidateCoordinates(matrix, x - 1, y - 1))
                            {
                                if (matrix[x - 1, y - 1] == '>')
                                {
                                    playerTwoShips--;
                                }
                                else if (matrix[x - 1, y - 1] == '<')
                                {
                                    playerOneShips--;
                                }

                                matrix[x - 1, y - 1] = 'X';
                            }

                            if (ValidateCoordinates(matrix, x - 1, y))
                            {
                                if (matrix[x - 1, y] == '>')
                                {
                                    playerTwoShips--;
                                }
                                else if (matrix[x - 1, y] == '<')
                                {
                                    playerOneShips--;
                                }

                                matrix[x - 1, y] = 'X';
                            }

                            if (ValidateCoordinates(matrix, x - 1, y + 1))
                            {
                                if (matrix[x - 1, y + 1] == '>')
                                {
                                    playerTwoShips--;
                                }
                                else if (matrix[x - 1, y + 1] == '<')
                                {
                                    playerOneShips--;
                                }

                                matrix[x - 1, y + 1] = 'X';
                            }

                            if (ValidateCoordinates(matrix, x, y - 1))
                            {
                                if (matrix[x, y - 1] == '>')
                                {
                                    playerTwoShips--;
                                }
                                else if (matrix[x, y - 1] == '<')
                                {
                                    playerOneShips--;
                                }

                                matrix[x, y - 1] = 'X';
                            }

                            if (ValidateCoordinates(matrix, x, y + 1))
                            {
                                if (matrix[x, y + 1] == '>')
                                {
                                    playerTwoShips--;
                                }
                                else if (matrix[x, y + 1] == '<')
                                {
                                    playerOneShips--;
                                }

                                matrix[x, y + 1] = 'X';
                            }

                            if (ValidateCoordinates(matrix, x + 1, y - 1))
                            {
                                if (matrix[x + 1, y - 1] == '>')
                                {
                                    playerTwoShips--;
                                }
                                else if (matrix[x + 1, y - 1] == '<')
                                {
                                    playerOneShips--;
                                }

                                matrix[x + 1, y - 1] = 'X';
                            }

                            if (ValidateCoordinates(matrix, x + 1, y))
                            {
                                if (matrix[x + 1, y] == '>')
                                {
                                    playerTwoShips--;
                                }
                                else if (matrix[x + 1, y] == '<')
                                {
                                    playerOneShips--;
                                }

                                matrix[x + 1, y] = 'X';
                            }

                            if (ValidateCoordinates(matrix, x + 1, y + 1))
                            {
                                if (matrix[x + 1, y + 1] == '>')
                                {
                                    playerTwoShips--;
                                }
                                else if (matrix[x + 1, y + 1] == '<')
                                {
                                    playerOneShips--;
                                }

                                matrix[x + 1, y + 1] = 'X';
                            }
                            break;
                    }
                }

                if (playerOneShips == 0 || playerTwoShips == 0)
                {
                    string winner = playerTwoShips == 0 ? "One" : "Two";

                    int totalShipsDestroyed = totalShips - (playerOneShips + playerTwoShips);

                    Console.WriteLine($"Player {winner} has won the game! {totalShipsDestroyed} ships have been sunk in the battle.");

                    isDraw = false;
                    break;
                }
            }

            if (isDraw)
            {
                Console.WriteLine($"It's a draw! Player One has {playerOneShips} ships left. Player Two has {playerTwoShips} ships left.");
            }
        }

        private static bool ValidateCoordinates(char[,] matrix, int x, int y)
        {
            if (x < 0 || x >= matrix.GetLength(0) || y < 0 || y >= matrix.GetLength(1))
            {
                return false;
            }

            return true;
        }
    }
}
