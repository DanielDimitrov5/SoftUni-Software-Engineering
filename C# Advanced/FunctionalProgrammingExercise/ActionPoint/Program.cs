using System;
using System.Linq;

namespace ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Action<string[]> printer = x =>
            {
                foreach (var name in x)
                {
                    Console.WriteLine($"Sir {name}");
                }
            };

            printer(input);
        }
    }
}
