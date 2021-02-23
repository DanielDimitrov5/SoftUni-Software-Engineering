using System;

namespace Fishland
{
    class Program
    {
        static void Main(string[] args)
        {
            double mackerel = double.Parse(Console.ReadLine());    
            double sprat = double.Parse(Console.ReadLine());    
            double bonitoKilograms = double.Parse(Console.ReadLine());    
            double horseMackerelKilograms = double.Parse(Console.ReadLine());    
            double shelsKilograms = double.Parse(Console.ReadLine());

            double bonitoPrise = mackerel * 1.6;
            double horseMackerelPrise = sprat * 1.8;
            double shelsPrise = 7.50;

            double bonitoTotal = bonitoPrise * bonitoKilograms;
            double horse = horseMackerelKilograms * horseMackerelPrise;
            double shels = shelsKilograms * shelsPrise;

            Console.WriteLine($"{bonitoTotal + horse +shels:f2}");
        }
    }
}
