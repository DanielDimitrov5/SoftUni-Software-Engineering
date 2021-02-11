using System;

namespace DivideWithoutReminder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double dividedByTwoCount = 0.00;
            double dividedByThreeCount = 0.00;
            double dividedByFourCount = 0.00;
            double p1 = 0.00;
            double p2 = 0.00;
            double p3 = 0.00;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num % 2 == 0)
                {
                    dividedByTwoCount++;
                }
                if (num % 3 == 0)
                {
                    dividedByThreeCount++;
                }
                if (num % 4 == 0)
                {
                    dividedByFourCount++;
                }
            }
            p1 = dividedByTwoCount / n * 100;
            Console.WriteLine($"{p1:f2}%");
            p2 = dividedByThreeCount / n * 100;
            Console.WriteLine($"{p2:f2}%");
            p3 = dividedByFourCount / n * 100;
            Console.WriteLine($"{p3:f2}%");
        }
    }
}
