using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Dictionary<double, int> keyValuePairs = new Dictionary<double, int>(array.Length - 1);

            foreach (double value in array)
            {
                if (keyValuePairs.ContainsKey(value) == false)
                {
                    keyValuePairs.Add(value, 0);
                }

                keyValuePairs[value]++;
            }

            foreach (var item in keyValuePairs)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
