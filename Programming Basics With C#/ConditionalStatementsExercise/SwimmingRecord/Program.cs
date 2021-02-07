using System;

namespace SwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double worldRecord = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double time = double.Parse(Console.ReadLine());

            double target = distance * time;
            double slowTimes = Math.Floor(distance / 15);
            double deley = slowTimes * 12.5;

            double finaleResult = (target) + deley;
            if (finaleResult < worldRecord)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {finaleResult:f2} seconds.");
            }
            else
            {
                double fail = Math.Abs(worldRecord - finaleResult);
                Console.WriteLine($"No, he failed! He was {fail:f2} seconds slower.");
            }
        }
    }
}
