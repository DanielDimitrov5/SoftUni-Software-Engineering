using System;
using System.Linq;

namespace CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] set = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            Func<int[], int> minFunc = x =>
            {
                int min = int.MaxValue;

                foreach (var item in x)
                {
                    if (item < min)
                    {
                        min = item;
                    }
                }

                return min;
            };

            Console.WriteLine(minFunc(set));
        }
    }
}
