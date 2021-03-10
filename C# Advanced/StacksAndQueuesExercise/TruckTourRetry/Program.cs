namespace TruckTourRetry
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<KeyValuePair<int, int>> petrolPumps = new Queue<KeyValuePair<int, int>>(n);

            for (int i = 0; i < n; i++)
            {
                int[] pumpDetails = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int petrolAmount = pumpDetails[0];
                int distance = pumpDetails[1];

                KeyValuePair<int, int> kvp = new KeyValuePair<int, int>(petrolAmount, distance);

                petrolPumps.Enqueue(kvp);
            }


            for (int i = 0; i < n; i++)
            {
                bool runSuccessful = true;

                int fuel = 0;

                for (int j = 0; j < n; j++)
                {
                    int pumpFuel = petrolPumps.Peek().Key;
                    int nextPumpDistace = petrolPumps.Peek().Value;

                    fuel += pumpFuel;

                    fuel -= nextPumpDistace;

                    if (fuel < 0)
                    {
                        runSuccessful = false;
                    }

                    petrolPumps.Enqueue(petrolPumps.Dequeue());
                }

                if (runSuccessful)
                {
                    Console.WriteLine(i);
                    break;
                }

                petrolPumps.Enqueue(petrolPumps.Dequeue());
            }
        }
    }
}
