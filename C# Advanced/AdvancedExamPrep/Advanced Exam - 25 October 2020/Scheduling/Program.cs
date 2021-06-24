using System;
using System.Linq;
using System.Collections.Generic;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            int taskToBeKilled = int.Parse(Console.ReadLine());

            while (true)
            {
                if (tasks.Peek() == taskToBeKilled)
                {
                    Console.WriteLine($"Thread with value {threads.Peek()} killed task {tasks.Pop()}");
                    break;
                }

                if (tasks.Peek() <= threads.Peek())
                {
                    tasks.Pop();
                }

                threads.Dequeue();
            }

            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
