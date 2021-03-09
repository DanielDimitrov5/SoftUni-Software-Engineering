namespace TrafficJam
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            int carsPassed = 0;

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "green")
                {
                    int currentCount = cars.Count;

                    for (int i = 0; i < Math.Min(n, currentCount); i++)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");

                        carsPassed++;
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
            }

            Console.WriteLine($"{carsPassed} cars passed the crossroads.");
        }
    }
}
