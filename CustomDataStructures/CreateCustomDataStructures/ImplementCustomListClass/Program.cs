using System;
using System.Collections.Generic;

namespace ImplementCustomListClass
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList list = new CustomList();

            list.Add(1);
            list.Add(3);
            list.Add(4);

            Console.WriteLine(list.ToString());

            list.Insert(1, 2);

            Console.WriteLine(list.ToString());

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
