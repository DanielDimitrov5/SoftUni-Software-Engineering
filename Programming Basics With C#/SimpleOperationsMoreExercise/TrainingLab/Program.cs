using System;

namespace TrainingLab
{
    class Program
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());

            double lenghtToCm = lenght * 100;
            double widthToCm = width * 100 - 100;

            lenghtToCm = Math.Floor(lenghtToCm / 120);
            widthToCm = Math.Floor(widthToCm / 70);

            double workPlaces = lenghtToCm * widthToCm - 3;

            Console.WriteLine(workPlaces);
        }
    }
}
