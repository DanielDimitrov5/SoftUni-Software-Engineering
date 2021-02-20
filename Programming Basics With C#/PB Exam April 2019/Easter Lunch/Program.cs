using System;

namespace Easter_Lunch
{
    class Program
    {
        static void Main(string[] args)
        {
            int kozunatsiCount = int.Parse(Console.ReadLine());
            int eggsCount = int.Parse(Console.ReadLine());
            int cookiesCount = int.Parse(Console.ReadLine());

            double eggPaint = eggsCount * 12 * 0.15;

            double total = kozunatsiCount * 3.2 + eggsCount * 4.35 + cookiesCount * 5.4 + eggPaint;
            Console.WriteLine($"{total:f2}");
        }
    }
}
