using System;
using System.Xml;

namespace Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());

            for (int L = 0; L < rooms; L++)
            {
                Console.Write($"L{floors}{L} ");
                if (L == rooms - 1)
                {
                    Console.WriteLine();
                }
            }

            for (int i = floors - 1; i >= 1; i--)
            {
                for (int j = 0; j < rooms; j++)
                {
                    if (i % 2 == 1)
                    {
                        Console.Write($"A{i}{j} ");
                        if (j == rooms - 1)
                        {
                            Console.WriteLine();
                        }
                    }
                    else if (i % 2 == 0)
                    {
                        Console.Write($"O{i}{j} ");
                        if (j == rooms - 1)
                        {
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}
