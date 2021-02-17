using System;

namespace WeatherForecast
{
    class Program
    {
        static void Main(string[] args)
        {
            double degrees = double.Parse(Console.ReadLine());
            string output = string.Empty;

            if (degrees >= 26 && degrees <= 35)
            {
                output = "Hot";
            }
            else if (degrees >= 20.1 && degrees <= 25.9)
            {
                output = "Warm";
            }
            else if (degrees >= 15 && degrees <= 20)
            {
                output = "Mild";
            }
            else if (degrees >= 12 && degrees <= 14.9)
            {
                output = "Cool";
            }
            else if (degrees >= 5 && degrees <= 11.9)
            {
                output = "Cold";
            }
            else
            {
                output = "unknown";
            }

            Console.WriteLine(output);
        }
    }
}
