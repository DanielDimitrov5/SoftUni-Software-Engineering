using System;

namespace EasterEggs
{
    class Program
    {
        static void Main(string[] args)
        {
            int paitedEggs = int.Parse(Console.ReadLine());

            int redCounter = 0;
            int orangeCounter = 0;
            int blueCounter = 0;
            int greenCounter = 0;
            int max = 0;

            for (int i = 0; i < paitedEggs; i++)
            {
                string color = Console.ReadLine();

                if (color == "red")
                {
                    redCounter++;
                }
                else if (color == "orange")
                {
                    orangeCounter++;
                }
                else if (color == "blue")
                {
                    blueCounter++;
                }
                else
                {
                    greenCounter++; 
                }
            }

            Console.WriteLine($"Red eggs: {redCounter}");
            Console.WriteLine($"Orange eggs: {orangeCounter}");
            Console.WriteLine($"Blue eggs: {blueCounter}");
            Console.WriteLine($"Green eggs: {greenCounter}");

            string maxColor = "";
            if (redCounter > max)
            {
                max = redCounter;
                maxColor = "red";
            }
            if (orangeCounter > max)
            {
                max = orangeCounter;
                maxColor = "orange";
            }
            if (blueCounter > max)
            {
                max = blueCounter;
                maxColor = "blue";
            }
            if (greenCounter > max)
            {
                max = greenCounter;
                maxColor = "green";
            }

            Console.WriteLine($"Max eggs: {max} -> {maxColor}");
        }
    }
}
