using System;

namespace OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int startHour = int.Parse(Console.ReadLine());
            int startMinutes = int.Parse(Console.ReadLine());
            int arriveHour = int.Parse(Console.ReadLine());
            int arriveMinute = int.Parse(Console.ReadLine());
            string time = string.Empty;
            int hh = 0;
            int mm = 0;
            // On time
            if ((startHour >= arriveHour) && startHour - arriveHour <= 1 && startMinutes - arriveMinute <= 30 
                && arriveMinute - arriveMinute >= 0)
            {
                if (startHour == arriveHour && startMinutes - arriveMinute <= 30)
                {
                    mm = startMinutes - arriveMinute;
                }
                else if (startHour - arriveHour == 1 && startMinutes + 60 - arriveMinute <= 30)
                {
                    mm = startMinutes + 60 - arriveMinute;
                }
                time = "On time";
            }
            Console.WriteLine(time);
        }
    }
}
