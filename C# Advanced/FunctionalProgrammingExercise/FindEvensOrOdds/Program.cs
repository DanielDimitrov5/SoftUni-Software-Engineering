using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int x = range[0];
            int y = range[1];

            string criteria = Console.ReadLine();

            List<int> numbers = new List<int>();

            for (int i = x; i <= y; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> evenOdd = x =>
            {
                switch (criteria)
                {
                    case "even": return x % 2 == 0;
                    case "odd": return x % 2 != 0;
                    default: return false;
                }
            };

            foreach (var item in numbers)
            {
                if (evenOdd(item))
                {
                    Console.Write(item + " ");
                }
            }
        }
    }
}
