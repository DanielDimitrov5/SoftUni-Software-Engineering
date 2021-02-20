using System;

namespace Easter_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int guests = int.Parse(Console.ReadLine());
            double envelopePrise = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            budget *= 0.9;

            if (guests >= 10 && guests <= 15)
            {
                envelopePrise *= 0.85;
            }
            else if (guests > 15 && guests <= 20)
            {
                envelopePrise *= 0.8;
            }
            else if (guests > 20)
            {
                envelopePrise *= 0.75;
            }

            budget -= guests * envelopePrise;

            if (budget >= 0)
            {
                Console.WriteLine($"It is party time! {budget:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"No party! {Math.Abs(budget):f2} leva needed.");
            }
        }
    }
}
