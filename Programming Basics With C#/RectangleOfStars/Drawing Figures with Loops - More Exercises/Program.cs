using System;

namespace Drawing_Figures_with_Loops___More_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if (n == 1)
            {
                Console.WriteLine("*");
                Environment.Exit(0);
            }

            int leftRight = (n - 1) / 2;
            int middle = -1;
            int middleB = 0;

            if (n % 2 == 1)
            {
                Console.Write(new string('-', leftRight));
                Console.Write(new string('*', 1));
                Console.Write(new string('-', leftRight));
                Console.WriteLine();

                for (int i = 0; i < ((n - 2) / 2) + 1; i++)
                {
                    Console.Write(new string('-', leftRight - 1));
                    leftRight -= 1;
                    Console.Write(new string('*', 1));
                    Console.Write(new string('-', middle + 2));
                    middle += 2;
                    Console.Write(new string('*', 1));
                    Console.Write(new string('-', leftRight));
                    Console.WriteLine();
                }

                for (int bottom = 0; bottom < (n - 2) / 2; bottom++)
                {
                    Console.Write(new string('-', leftRight + 1));
                    leftRight += 1;
                    Console.Write(new string('*', 1));
                    Console.Write(new string('-', middle - 2));
                    middle -= 2;
                    Console.Write(new string('*', 1));
                    Console.Write(new string('-', leftRight));
                    Console.WriteLine();
                }
            }
            else
            {
                Console.Write(new string('-', leftRight));
                Console.Write(new string('*', 1));
                Console.Write(new string('*', 1));
                Console.Write(new string('-', leftRight));
                Console.WriteLine();

                for (int i = 0; i < (n - 2) / 2; i++)
                {
                    Console.Write(new string('-', leftRight - 1));
                    leftRight -= 1;
                    Console.Write(new string('*', 1));
                    Console.Write(new string('-', middleB + 2));
                    middleB += 2;
                    Console.Write(new string('*', 1));
                    Console.Write(new string('-', leftRight));
                    Console.WriteLine();
                }

                for (int i = 0; i < ((n - 2) / 2) - 1; i++)
                {
                    Console.Write(new string('-', leftRight + 1));
                    leftRight += 1;
                    Console.Write(new string('*', 1));
                    Console.Write(new string('-', middleB - 2));
                    middleB -= 2;
                    Console.Write(new string('*', 1));
                    Console.Write(new string('-', leftRight));
                    Console.WriteLine();
                }
            }

            if (n % 2 == 1)
            {
                Console.Write(new string('-', (n - 1) / 2));
                Console.Write(new string('*', 1));
                Console.Write(new string('-', (n - 1) / 2));
                Console.WriteLine();
            }
            else if (n != 2)
            {
                Console.Write(new string('-', (n - 1) / 2));
                Console.Write(new string('*', 1));
                Console.Write(new string('*', 1));
                Console.Write(new string('-', (n - 1) / 2));
                Console.WriteLine();
            }
        }
    }
}