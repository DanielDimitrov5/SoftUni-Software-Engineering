using System;

namespace Easter
{
    class Program
    {
        static void Main(string[] args)
        {
            double flourPrise = double.Parse(Console.ReadLine());
            double flourAmount = double.Parse(Console.ReadLine());
            double sugarAmount = double.Parse(Console.ReadLine());
            double eggsAmount = double.Parse(Console.ReadLine());
            double maqAmount = double.Parse(Console.ReadLine());

            double sugarPrise = flourPrise * 0.75;
            double eggsPrise = flourPrise * 1.1;
            double maqPrise = sugarPrise * 0.2;

            Console.WriteLine($"{flourPrise * flourAmount + sugarAmount * sugarPrise + eggsAmount * eggsPrise + maqAmount * maqPrise:f2}");
        }
    }
}
