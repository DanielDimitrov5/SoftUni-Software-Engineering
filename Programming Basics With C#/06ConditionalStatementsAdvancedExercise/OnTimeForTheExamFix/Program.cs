using System;

namespace Fix
{
    class Program
    {
        static void Main(string[] args)
        {
            int startHour = int.Parse(Console.ReadLine());
            int startMinutes = int.Parse(Console.ReadLine());
            int arriveHour = int.Parse(Console.ReadLine());
            int arriveMinute = int.Parse(Console.ReadLine());
            int startMinutesPlusHour = startHour * 60 + startMinutes;
            int arriveMinutesPlusHour = arriveHour * 60 + arriveMinute;
            int minutesTotal = 0;
            string output = string.Empty;
            string time = string.Empty;
            //Late
            if (startMinutesPlusHour < arriveMinutesPlusHour)
            {
                time = "Late";
            }
            //On time
            else if (startMinutesPlusHour >= arriveMinutesPlusHour && startMinutesPlusHour - arriveMinutesPlusHour <= 30)
            {
                time = "On time";
            }
            else
            {
                time = "Early";
            }
            Console.WriteLine(time);
            if (time == "Late")
            {
                minutesTotal = arriveMinutesPlusHour - startMinutesPlusHour;
            }
            else if (time == "On time" || time == "Early")
            {
                minutesTotal = startMinutesPlusHour - arriveMinutesPlusHour;
            }
            if (time == "Late")
            {
                if (arriveMinutesPlusHour - startMinutesPlusHour < 60)
                {
                    output = $"{minutesTotal} minutes after the start";
                }
                else if (minutesTotal % 60 < 10)
                {
                    output = $"{minutesTotal / 60}:0{minutesTotal % 60} hours after the start";
                }
                else
                {
                    output = $"{minutesTotal / 60}:{minutesTotal % 60} hours after the start";
                }
            }
            else
            {

                if (minutesTotal < 60 && minutesTotal != 0)
                {
                    output = $"{minutesTotal} minutes before the start";
                }
                else if (minutesTotal % 60 < 10 && minutesTotal != 0)
                {
                    output = $"{minutesTotal / 60}:0{minutesTotal % 60} hours before the start";
                }
                else if (minutesTotal % 60 >= 10 && minutesTotal != 0)
                {
                    output = $"{minutesTotal / 60}:{minutesTotal % 60} hours before the start";
                }
            }
            Console.WriteLine(output);
        }
    }
}
