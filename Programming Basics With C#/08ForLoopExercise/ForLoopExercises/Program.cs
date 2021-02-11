using System;

namespace ForLoopExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double p1Nums = 0.00;
            double p2Nums = 0.00;
            double p3Nums = 0.00;
            double p4Nums = 0.00;
            double p5Nums = 0.00;
            double p1 = 0.00;
            double p2 = 0.00;
            double p3 = 0.00;
            double p4 = 0.00;
            double p5 = 0.00;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num < 200)
                {
                    p1Nums++;
                }
                else if (num >= 200 && num <= 399)
                {
                    p2Nums++;
                }
                else if (num >= 400 && num <= 599)
                {
                    p3Nums++;
                }
                else if (num >= 599 && num <= 799)
                {
                    p4Nums++;
                }
                else
                {
                    p5Nums++;
                }
            }
            p1 = p1Nums / n * 100;
            Console.WriteLine($"{p1:f2}%");
            p2 = p2Nums / n * 100;
            Console.WriteLine($"{p2:f2}%");
            p3 = p3Nums / n * 100;
            Console.WriteLine($"{p3:f2}%");
            p4 = p4Nums / n * 100;
            Console.WriteLine($"{p4:f2}%");
            p5 = p5Nums / n * 100;
            Console.WriteLine($"{p5:f2}%");
        }
    }
}
