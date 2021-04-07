using System;
using System.Collections.Generic;

namespace GenericCountMethod
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Box<double>> list = new List<Box<double>>();

            for (int i = 0; i < n; i++)
            {
                Box<double> box = new Box<double>(double.Parse(Console.ReadLine()));
                list.Add(box);
            }

            double value = double.Parse(Console.ReadLine());

            int result = GreaterCount(list, value);

            Console.WriteLine(result);

        }

        private static int GreaterCount<T>(List<Box<T>> list, T value)
            where T : IComparable
        {
            int count = 0;

            foreach (var item in list)
            {
                if (item.type.CompareTo(value) > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
