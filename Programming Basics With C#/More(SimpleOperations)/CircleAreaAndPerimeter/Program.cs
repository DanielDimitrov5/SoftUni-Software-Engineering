using System;

namespace CircleAreaAndPerimeter
{
    class Program
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());

            double area = r * r * Math.PI;
            Console.WriteLine($"{area:f2}");

            double perimeter = 2 * r * Math.PI;
            Console.WriteLine($"{perimeter:f2}");
        }
    }
}
