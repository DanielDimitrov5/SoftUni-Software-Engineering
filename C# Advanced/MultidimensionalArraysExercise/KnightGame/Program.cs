using System;

namespace KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            
            int removedKnights = 0;

            while (true)
            {
                int maxKnight = 0;
                int knightRow = -1;
                int knightCol = -1;

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (matrix[row, col] != 'K')
                        {
                            continue;
                        }

                        int currentKnightTargets = GetKnightTargetsCount(matrix, row, col);

                        if (currentKnightTargets > maxKnight)
                        {
                            maxKnight = currentKnightTargets;

                            knightRow = row;
                            knightCol = col;
                        }

                    }
                }

                if (maxKnight == 0)
                {
                    break;
                }

                matrix[knightRow, knightCol] = '0';

                removedKnights++;
            }

            Console.WriteLine(removedKnights);
        }

        private static int GetKnightTargetsCount(char[,] matrix, int row, int col)
        {
            int count = 0;

            int row1 = row + 2;
            int col1 = col + 1;

            if (ValidCoordinates(matrix, row1, col1) && matrix[row1, col1] == 'K')
            {
                count++;
            }

            int row2 = row + 2;
            int col2 = col - 1;

            if (ValidCoordinates(matrix, row2, col2) && matrix[row2, col2] == 'K')
            {
                count++;
            }

            int row3 = row - 2;
            int col3 = col + 1;

            if (ValidCoordinates(matrix, row3, col3) && matrix[row3, col3] == 'K')
            {
                count++;
            }

            int row4 = row - 2;
            int col4 = col - 1;

            if (ValidCoordinates(matrix, row4, col4) && matrix[row4, col4] == 'K')
            {
                count++;
            }

            int row5 = row + 1;
            int col5 = col + 2;

            if (ValidCoordinates(matrix, row5, col5) && matrix[row5, col5] == 'K')
            {
                count++;
            }

            int row6 = row + 1;
            int col6 = col - 2;

            if (ValidCoordinates(matrix, row6, col6) && matrix[row6, col6] == 'K')
            {
                count++;
            }

            int row7 = row - 1;
            int col7 = col + 2;

            if (ValidCoordinates(matrix, row7, col7) && matrix[row7, col7] == 'K')
            {
                count++;
            }

            int row8 = row - 1;
            int col8 = col - 2;

            if (ValidCoordinates(matrix, row8, col8) && matrix[row8, col8] == 'K')
            {
                count++;
            }

            return count;
        }

        private static bool ValidCoordinates(char[,] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
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
