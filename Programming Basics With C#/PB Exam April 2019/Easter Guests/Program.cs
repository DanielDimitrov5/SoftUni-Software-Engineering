using System;

namespace Easter_Guests
{
    class Program
    {
        static void Main(string[] args)
        {
            double guests = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double kozunatsi = Math.Ceiling(guests / 3);
            double eggs = guests * 2;

            double prise = kozunatsi * 4 + eggs * 0.45;

            if (budget >= prise)
            {
                Console.WriteLine($"Lyubo bought {kozunatsi} Easter bread and {eggs} eggs.");
                Console.WriteLine($"He has {budget - prise:f2} lv. left.");
            }
            else
            {
                Console.WriteLine("Lyubo doesn't have enough money.");
                Console.WriteLine($"He needs {prise - budget:f2} lv. more.");
            }
        }
    }
}
