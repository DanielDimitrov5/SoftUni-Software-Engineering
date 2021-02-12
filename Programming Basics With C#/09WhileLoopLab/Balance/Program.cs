using System;

namespace Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            double sum = 0.0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "NoMoreMoney")
                {
                    Console.WriteLine($"Total: {sum:f2}");
                    break;
                }

                double increase = double.Parse(input);

                if (increase >= 0)
                { 
                sum = sum + increase;
                }

                if (increase < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    Console.WriteLine($"Total: {sum:f2}");
                    break;
                }
                Console.WriteLine($"Increase: {increase:f2}");
            }
        }
    }
}
