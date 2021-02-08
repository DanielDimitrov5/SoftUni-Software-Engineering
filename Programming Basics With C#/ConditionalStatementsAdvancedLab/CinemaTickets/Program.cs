using System;

namespace CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();
            int ticketPrise = 0;
            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Friday":
                    ticketPrise = 12;
                    break;
                case "Wednesday":
                case "Thursday":
                    ticketPrise = 14;
                    break;
                default:
                    ticketPrise = 16;
                    break;


            }
            Console.WriteLine(ticketPrise);
        }
    }
}
