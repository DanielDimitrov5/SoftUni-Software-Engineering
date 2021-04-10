using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStack<int> stack = new CustomStack<int>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input.Split(" ", 2);

                switch (command[0])
                {
                    case "Push":

                        int[] integers = command[1].Split(", ").Select(int.Parse).ToArray();
                        stack.Push(integers);

                        break;
                    case "Pop":

                        if (stack.Count == 0)
                        {
                            Console.WriteLine("No elements");
                        }
                        else
                        {
                            stack.Pop();
                        }
                        break;
                }
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
