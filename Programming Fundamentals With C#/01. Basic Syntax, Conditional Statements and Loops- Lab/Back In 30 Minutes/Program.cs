using System;

namespace Back_In_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            minutes = minutes + 30;
            hours += minutes / 60;

            if (minutes >= 60)
            {
                minutes = minutes % 60;
                if (hours >= 24)
                {
                    hours = hours - 24;
                }
            }

            Console.WriteLine($"{hours}:{minutes:d2}");
        }
    }
}
