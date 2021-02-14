using System;

namespace CinemaTikets
{
    class Program
    {
        static void Main(string[] args)
        {
            double studentTicket = 0;
            double standardTicket = 0;
            double kidsTicket = 0;
            double studentTicketD = 0;
            double standardTicketD = 0;
            double kidsTicketD = 0;
            double ticketsSold = 0;
            double totalTicketsSold = 0;
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
                        standardTicketD++;
                    }
                    else if (ticketType == "student")
                    {
                        studentTicket++;
                        studentTicketD++;
                    }
                    else if (ticketType == "kid")
                    {
                        kidsTicket++;
                        kidsTicketD++;
                    }
                    else if (ticketType == "End")
                    {
                        standardTicket = 0;
                        studentTicket = 0;
                        kidsTicket = 0;
                        break;
                    }

                    ticketsSold = studentTicket + standardTicket + kidsTicket;
                    totalTicketsSold = standardTicketD + studentTicketD + kidsTicketD;

                    if (ticketsSold >= capacity)
                    {
                        standardTicket = 0;
                        studentTicket = 0;
                        kidsTicket = 0;
                        break;
                    }
                }

                Console.WriteLine($"{movie} - {ticketsSold / capacity * 100:f2}% full.");
            }

            Console.WriteLine($"Total tickets: {totalTicketsSold}");
            Console.WriteLine($"{studentTicketD / totalTicketsSold * 100:f2}% student tickets.");
            Console.WriteLine($"{standardTicketD / totalTicketsSold * 100:f2}% standard tickets.");
            Console.WriteLine($"{kidsTicketD / totalTicketsSold * 100:f2}% kids tickets."); 
        }
    }
}
