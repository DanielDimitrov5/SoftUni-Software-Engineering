using System;

namespace CelsiusToFahrenheit
{
    class Program
    {
        static void Main(string[] args)
        {
            double celsious = double.Parse(Console.ReadLine());

            double fahrenheit = celsious / 5.0 * 9.0 + 32.0;

            Console.WriteLine($"{fahrenheit:f2}");
        }
    }
}
