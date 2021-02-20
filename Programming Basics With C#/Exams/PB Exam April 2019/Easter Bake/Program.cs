using System;

namespace Easter_Bake
{
    class Program
    {
        static void Main(string[] args)
        {
            int kozunatsi = int.Parse(Console.ReadLine());
            double maxSugar = 0;
            double maxFlour = 0;
            double totalSugar = 0;
            double totalFlour = 0;

            for (int i = 0; i < kozunatsi; i++)
            {
                double sugar = double.Parse(Console.ReadLine());
                double flour = double.Parse(Console.ReadLine());
                if (sugar > maxSugar)
                {
                    maxSugar = sugar;
                }
                if (flour > maxFlour)
                {
                    maxFlour = flour;
                }
                totalSugar += sugar;
                totalFlour += flour;
            }

            Console.WriteLine($"Sugar: {Math.Ceiling(totalSugar / 950)}");
            Console.WriteLine($"Flour: {Math.Ceiling(totalFlour / 750)}");
            Console.WriteLine($"Max used flour is {maxFlour} grams, max used sugar is {maxSugar} grams.");
        }
    }
}
