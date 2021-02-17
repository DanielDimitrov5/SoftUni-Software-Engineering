using System;

namespace HausePainting
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double sidesP = (2 * (x * x)) - 2.4 + (2 * (x * y) - 4.5);
            double greenPaintL = sidesP / 3.4;
            Console.WriteLine($"{greenPaintL:f2}");

            double roofP = 2 * (x * y) + (2 * (x * h / 2));
            double redpaint = roofP / 4.3;
            Console.WriteLine($"{redpaint:f2}");
        }
    }
}
