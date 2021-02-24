using System;
using System.Collections.Generic;

namespace ImplementCustomListClass
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> l = new List<int>();

            l.Find(x => x > 1);

            Predicate<int> pred = x=>x > 1;

            CustomList list = new CustomList();

            for (int i = 0; i < 10; i++)
            {
                list.Add(i + 1);
            }

            Console.WriteLine(list.ToString());

            list.Reverse();

            Console.WriteLine(list.ToString());

            list.Reverse();

            Console.WriteLine(list.ToString());

            list.Swap(0, 9);

            Console.WriteLine(list.ToString());

            Console.WriteLine(list.Contains(2));
            Console.WriteLine(list.Contains(15));
            Console.WriteLine(list.Count);

            for (int i = 0; i < 3; i++)
            {
                list.RemoveAt(0);
            }

            Console.WriteLine(list.Count);

            int curr = list[56]; //exeption
        }
    }
}
