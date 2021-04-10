using System;
using System.Linq;

namespace Froggy
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Lake lake = new Lake(input);

            int[] oredered = new int[input.Length];

            int index = 0;

            foreach (var stone in lake)
            {
                oredered[index++] = stone;
            }

            Console.WriteLine(string.Join(", ", oredered));
        }
    }
}
