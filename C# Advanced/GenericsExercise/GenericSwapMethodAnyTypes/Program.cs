using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodAnyTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box<int>> list = new List<Box<int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Box<int> box = new Box<int>(int.Parse(Console.ReadLine()));
                list.Add(box);
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Swap<int>(list, indexes[0], indexes[1]);

            Console.WriteLine(string.Join(Environment.NewLine, list));
        }

        public static void Swap<T>(List<Box<T>> list, int firstIndex, int secondIndex)
        {
            var temp = list[firstIndex];

            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }
    }
}
