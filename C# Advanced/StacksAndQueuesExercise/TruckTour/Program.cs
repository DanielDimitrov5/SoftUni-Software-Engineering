namespace TruckTour
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

            Queue<KeyValuePair<int, int>> copy = new Queue<KeyValuePair<int, int>>();

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

                copy.Enqueue(kvp);
            }

            int fuel = 0;

            int index = 0;

            while(copy.Count() > 1)
            {
                fuel += copy.Peek().Key;

                if (fuel >= copy.Peek().Value)
                {
                    fuel -= copy.Dequeue().Value;
                }
                else
                {
                    fuel = 0;

                    index++;

                    copy = petrolPumps;

                    for (int j = 0; j < index; j++)
                    {
                        copy.Enqueue(copy.Dequeue());
                    }
                }
            }

            Console.WriteLine(index);
        }
    }
}
