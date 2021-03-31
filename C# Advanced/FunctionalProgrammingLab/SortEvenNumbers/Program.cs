using System;
using System.Collections.Generic;
using System.Linq;

namespace SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 == 1)
                {
                    numbers.RemoveAt(i);
                    i--;
                }
            }

            List<int> sorted = new List<int>();


            while (numbers.Any())
            {
                int max = int.MinValue;

                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] > max)
                    {
                        max = numbers[i];
                    }
                }

                numbers.Remove(max);
                sorted.Insert(0, max);
            }

            Console.WriteLine(string.Join(", ", sorted));
        }
    }
}
