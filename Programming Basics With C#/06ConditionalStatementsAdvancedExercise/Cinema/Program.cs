using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string cinema = Console.ReadLine();
            int row = int.Parse(Console.ReadLine());
            int colon = int.Parse(Console.ReadLine());
            int capacity = row * colon;
            double ticketPrise = 0;
            switch (cinema)
            {
                case "Premiere":
                    ticketPrise = 12.00;
                    break;
                case "Normal":
                    ticketPrise = 7.50;
                    break;
                default:
                    ticketPrise = 5.00;
                    break;
            }
            double result = capacity * ticketPrise;
            Console.WriteLine($"{result:f2} leva");
                

        }
    }
}
