using System;

namespace SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());

            int n = int.Parse(Console.ReadLine());

            char[][] maze = new char[n][];

            for (int i = 0; i < n; i++)
            {
                char[] row = Console.ReadLine().ToCharArray();

                maze[i] = row;
            }

            Tuple<int, int> marioIndex = FindIndex(maze, 'M');

            int marioX = marioIndex.Item1;
            int marioY = marioIndex.Item2;

            maze[marioX][marioY] = '-';

            while (true)
            {
                lives--;

                string[] moveCommand = Console.ReadLine().Split();

                string moveDirection = moveCommand[0];

                int spawnX = int.Parse(moveCommand[1]);
                int spawnY = int.Parse(moveCommand[2]);

                maze[spawnX][spawnY] = 'B';

                switch (moveDirection)
                {
                    case "W":

                        if (IsOutside(maze, marioX - 1, marioY) == false)
                        {
                            marioX--;
                        }

                        break;
                    case "S":

                        if (IsOutside(maze, marioX + 1, marioY) == false)
                        {
                            marioX++;
                        }

                        break;
                    case "A":

                        if (IsOutside(maze, marioX, marioY - 1) == false)
                        {
                            marioY--;
                        }

                        break;
                    case "D":

                        if (IsOutside(maze, marioX, marioY + 1) == false)
                        {
                            marioY++;
                        }

                        break;
                }

                if (maze[marioX][marioY] == 'B')
                {
                    lives -= 2;
                }
                else if (maze[marioX][marioY] == 'P')
                {
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                    maze[marioX][marioY] = '-';
                    break;
                }

                if (lives > 0)
                {
                    maze[marioX][marioY] = '-';
                }
                else
                {
                    Console.WriteLine($"Mario died at {marioX};{marioY}.");
                    maze[marioX][marioY] = 'X';
                    break;
                }
            }


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < maze[i].Length; j++)
                {
                    Console.Write(maze[i][j]);
                }
                Console.WriteLine();
            }
        }

        private static Tuple<int, int> FindIndex(char[][] maze, char x)
        {
            for (int row = 0; row < maze.GetLength(0); row++)
            {
                for (int col = 0; col < maze[row].Length; col++)
                {
                    if (maze[row][col] == x)
                    {
                        return new Tuple<int, int>(row, col);
                    }
                }
            }

            return null;
        }

        private static bool IsOutside(char[][] maze, int x, int y)
        {
            if (x < 0 || x >= maze.GetLength(0) || y < 0 || y >= maze[0].Length)
            {
                return true;
            }

            return false;
        }
    }
}
