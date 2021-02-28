using System;
using System.Collections.Generic;

namespace CustomLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomLinkedList<int> linkedList = new CustomLinkedList<int>();
            CustomLinkedList<char> linkedList1 = new CustomLinkedList<char>();

            for (int i = 0; i < 5; i++)
            {
                linkedList.AddHead(new Node<int>(i + 1));
            }

            for (int i = 0; i < 5; i++)
            {
                linkedList.AddTail(new Node<int>(i + 1));
            }

            linkedList.Foreach(x => Console.WriteLine(x.Value));

            Console.WriteLine("--------------");

            for (int i = 0; i < 3; i++)
            {
                linkedList.RemoveHead();
            }

            for (int i = 0; i < 3; i++)
            {
                linkedList.RemoveTail();
            }

            linkedList.Foreach(x => Console.WriteLine(x.Value));

            Console.WriteLine("--------------");

            Console.WriteLine(string.Join(" ", linkedList.ToArray()));

            linkedList.Reverse(); //Reverse not fully functional

            Console.WriteLine(string.Join(" ", linkedList.ToArray()));

            var genericList = new CustomLinkedList<string>();

            genericList.AddHead(new Node<string>("Stefan"));
            genericList.AddHead(new Node<string>("Gogi"));
            genericList.AddHead(new Node<string>("Muci"));
            genericList.AddHead(new Node<string>("Pesho"));

            genericList.Foreach(x => Console.WriteLine(x.Value));

            var nestedList = new CustomLinkedList<List<char>>();

            nestedList.AddHead(new Node<List<char>>(new List<char>() { 'a', 'b', 'v' }));
            nestedList.AddTail(new Node<List<char>>(new List<char>() { 'g', 'd', 'e' }));

            nestedList.Foreach(x => Console.WriteLine(string.Join(" ", x.Value)));
        }
    }
}
