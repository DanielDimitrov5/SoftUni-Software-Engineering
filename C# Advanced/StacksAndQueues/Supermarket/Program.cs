namespace Supermarket
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();

            string command = Console.ReadLine();

            while (command != "End")
            {
                if (command != "Paid")
                {
                    queue.Enqueue(command);
                }
                else
                {
                    Console.WriteLine(string.Join(Environment.NewLine, queue));

                    queue.Clear();
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
