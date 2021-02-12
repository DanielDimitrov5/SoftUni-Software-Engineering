using System;

namespace MinValue
{
    class Program
    {
        static void Main(string[] args)
        {
            int min = int.MaxValue;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Stop")
                {
                    Console.WriteLine(min);
                    break;
                }

                int number = int.Parse(input);
                if (number < min)
                {
                    min = number;
                }
            }
        }
    }
}
