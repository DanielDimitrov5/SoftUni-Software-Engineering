using System;
using System.Linq;

namespace AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<decimal, decimal> vatAdder = x => x * 1.2m;

            decimal[] prices = Console.ReadLine()
                .Split(", ")
                .Select(decimal.Parse)
                .Select(vatAdder)
                .ToArray();

            foreach (var price in prices)
            {
                Console.WriteLine($"{price:F2}");
            }
        }
    }
}
