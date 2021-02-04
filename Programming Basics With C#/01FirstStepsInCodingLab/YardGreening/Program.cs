using System;

namespace YardGreening
{
    class Program
    {
        static void Main(string[] args)
        {
            double YardArea = double.Parse(Console.ReadLine());
            double firstPrise = YardArea * 7.61;
            double finalePrise = firstPrise - firstPrise * 0.18;
            double discount = firstPrise * 0.18;

            Console.WriteLine($"The final price is: {finalePrise} lv.");

            Console.WriteLine($"The discount price is: {discount} lv.");
        }
    }
}
