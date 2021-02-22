using System;

namespace _5._Month_Printer
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int numMonth = num - 1;

            string[] months = new string[12];
            months[0] = "January";
            months[1] = "February";
            months[2] = "March";
            months[3] = "April";
            months[4] = "May";
            months[5] = "June";
            months[6] = "July";
            months[7] = "August";
            months[8] = "September";
            months[9] = "October";
            months[10] = "November";
            months[11] = "December";

            try
            {
                Console.WriteLine(months[numMonth]);
            }
            catch (Exception)
            {
                Console.WriteLine("Error!");
            }
        }
    }
}
