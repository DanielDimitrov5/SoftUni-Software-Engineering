using System;
using System.Collections.Generic;
using System.Linq;

namespace WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            Queue<int> scarfs = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            List<int> sets = new List<int>();

            while (hats.Any() && scarfs.Any())
            {
                if (hats.Peek() > scarfs.Peek())
                {
                    sets.Add(hats.Pop() + scarfs.Dequeue());
                }
                else if (hats.Peek() < scarfs.Peek())
                {
                    hats.Pop();
                }
                else if (hats.Peek() == scarfs.Peek())
                {
                    hats.Push(hats.Pop() + 1);
                    scarfs.Dequeue();
                }
            }

            int maxPriceSet = sets.Max();

            Console.WriteLine($"The most expensive set is: {maxPriceSet}");

            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
