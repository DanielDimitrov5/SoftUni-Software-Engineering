namespace BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = input[0];
            int s = input[1];
            int x = input[2];

            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> numStack = new Queue<int>(array);

            for (int i = 0; i < s; i++)
            {
                numStack.Dequeue();
            }

            if (numStack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                if (numStack.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(numStack.Min());
                }
            }
        }
    }
}
