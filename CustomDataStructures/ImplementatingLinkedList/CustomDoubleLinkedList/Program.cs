using System;

namespace CustomDoubleLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList linkedList = new DoubleLinkedList();

            for (int i = 0; i < 5; i++)
            {
                linkedList.AddHead(new Node(i + 1));
            }

            for (int i = 0; i < 5; i++)
            {
                linkedList.AddTail(new Node(i + 1));
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
        }
    }
}
