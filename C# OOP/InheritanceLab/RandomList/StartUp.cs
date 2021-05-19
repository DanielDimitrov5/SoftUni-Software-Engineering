using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list1 = new RandomList(new List<string> { "1", "2", "3", "4", "5", "6", "71", "8", "9", "11" });
            RandomList list2 = new RandomList();

            list2.AddElement("1");
            list2.AddElement("2");
            list2.AddElement("3");
            list2.AddElement("4");

            Console.WriteLine(list1.RandomString());
            Console.WriteLine(list2.RandomString());
        }
    }
}
