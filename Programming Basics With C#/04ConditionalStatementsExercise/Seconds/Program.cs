using System;

namespace Seconds
{
    class Program
    {
        static void Main(string[] args)
        {

            int firstTime = int.Parse(Console.ReadLine());
            int secondTime = int.Parse(Console.ReadLine());
            int thirdTime = int.Parse(Console.ReadLine());

            int totalSeconds = firstTime + secondTime + thirdTime;
            if (firstTime <= 50 && secondTime <= 50 && thirdTime <= 50)
            {
                int minutes = totalSeconds / 60;
                int seconds = totalSeconds % 60;

                if (seconds < 10)
                {
                    Console.WriteLine($"{minutes}:0{seconds}");
                }
                else
                {
                    Console.WriteLine($"{minutes}:{seconds}");
                }
            }


        }
    }
}
