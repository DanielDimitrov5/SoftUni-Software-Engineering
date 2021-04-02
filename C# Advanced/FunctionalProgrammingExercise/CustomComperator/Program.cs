using System;
using System.Linq;

namespace CustomComperator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Array.Sort(array, (a, b) =>
            {
                if (a % 2 == 0 && b % 2 != 0)
                {
                    return -1;
                }
                else if (a % 2 != 0 && b % 2 == 0)
                {
                    return 1;
                }

                return a.CompareTo(b);
            });

            Console.WriteLine(string.Join(" ", array));
        }
    }
}
