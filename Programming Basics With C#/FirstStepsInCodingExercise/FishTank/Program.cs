using System;

namespace FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double hight = double.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double volumeCm3 = lenght * width * hight;
            double volumeL = volumeCm3 * 0.001;
            double percent1 = percent * 0.01;
            double realVolume = volumeL * (1 - percent1);

            double result = realVolume;

            Console.WriteLine(result);
        }
    }
}
