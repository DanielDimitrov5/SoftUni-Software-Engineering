using System;

namespace Painting_Eggs
{
    class Program
    {
        static void Main(string[] args)
        {
            string size = Console.ReadLine();
            string color = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            int priseRed = 0;
            int priseGreen = 0;
            int priseYellow = 0;

            switch (size)
            {
                case "Large":
                    priseRed = 16 * count;
                    priseGreen = 12 * count;
                    priseYellow = 9 * count;
                    if (color == "Red")
                    {
                        Console.WriteLine($"{priseRed * 0.65:f2} leva.");
                    }
                    else if (color == "Green")
                    {
                        Console.WriteLine($"{priseGreen * 0.65:f2} leva.");
                    }
                    else
                    {
                        Console.WriteLine($"{priseYellow * 0.65:f2} leva.");
                    }
                    break;
                case "Medium":
                    priseRed = 13 * count;
                    priseGreen = 9 * count;
                    priseYellow = 7 * count;
                    if (color == "Red")
                    {
                        Console.WriteLine($"{priseRed * 0.65:f2} leva.");
                    }
                    else if (color == "Green")
                    {
                        Console.WriteLine($"{priseGreen * 0.65:f2} leva.");
                    }
                    else
                    {
                        Console.WriteLine($"{priseYellow * 0.65:f2} leva.");
                    }
                    break;
                default:
                    priseRed = 9 * count;
                    priseGreen = 8 * count;
                    priseYellow = 5 * count;
                    if (color == "Red")
                    {
                        Console.WriteLine($"{priseRed * 0.65:f2} leva.");
                    }
                    else if (color == "Green")
                    {
                        Console.WriteLine($"{priseGreen * 0.65:f2} leva.");
                    }
                    else
                    {
                        Console.WriteLine($"{priseYellow * 0.65:f2} leva.");
                    }
                    break;
            }
        }
    }
}
