using System;

namespace CinemaTikets
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentTicket = 0;
            int standardTicket = 0;
            int kidsTicket = 0;
            int totalTicketsSold = 0;
            while (true)
            {
                string movie = Console.ReadLine();
                if (movie == "Finish")
                {
                    break;
                }

                int capacity = int.Parse(Console.ReadLine());
                while (true)
                {
                    string ticketType = Console.ReadLine();
                    if (ticketType == "standard")
                    {
                        standardTicket++;
                    }
                    else if (ticketType == "student")
                    {
                        studentTicket++;
                    }
                    else if (ticketType == "kid")
                    {
                        kidsTicket++;
                    }
                    else if (ticketType == "End")
                    {
                        break;
                    }

                    totalTicketsSold = studentTicket + standardTicket + kidsTicket;

                    if (totalTicketsSold >= capacity)
                    {
                        totalTicketsSold = 0;
                        break;
                    }
                }

                Console.WriteLine($"{movie} - {totalTicketsSold * 100.0 / capacity}% full.");
            }
        }
    }
}
