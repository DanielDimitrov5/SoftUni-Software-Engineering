namespace HotPotato
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> kids = new Queue<string>(Console.ReadLine().Split());

            int tosses = int.Parse(Console.ReadLine());

            int tossCount = 0;

            while (kids.Count > 1)
            {
                tossCount++;

                if (tosses == tossCount)
                {
                    Console.WriteLine("Removed " + kids.Dequeue());
                    tossCount = 0;
                }
                else
                {
                    kids.Enqueue(kids.Dequeue());
                }
            }

            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}
