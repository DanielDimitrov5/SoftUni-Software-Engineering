using System;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            double hight = double.Parse(Console.ReadLine());

            double freeSpace = width * length * hight;
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Done")
                {
                    break;
                }

                double boxes = double.Parse(input);
                freeSpace -= boxes;

                if (freeSpace < 0)
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(freeSpace)} Cubic meters more.");
                    break;
                }
            }
            if (freeSpace >= 0)
            {
                Console.WriteLine($"{freeSpace} Cubic meters left.");
            }
        }
    }
}
