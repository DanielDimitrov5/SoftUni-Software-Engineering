namespace StackSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(array);

            string command = string.Empty;

            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] input = command.Split();

                string currentCommand = input[0];

                switch (currentCommand)
                {
                    case "add":

                        stack.Push(int.Parse(input[1]));
                        stack.Push(int.Parse(input[2]));
                        break;
                    case "remove":

                        int elemetsToBeRemoved = int.Parse(input[1]);

                        if (stack.Count >= elemetsToBeRemoved)
                        {
                            for (int i = 0; i < elemetsToBeRemoved; i++)
                            {
                                stack.Pop();
                            }
                        }
                        break;
                }
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
