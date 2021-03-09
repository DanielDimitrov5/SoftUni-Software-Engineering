namespace EvenNumbers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> numbers = new Queue<int>(array);

            Queue<int> evenNumbers = new Queue<int>();

            for (int i = 0; i < array.Length; i++)
            {
                int currentNum = numbers.Peek();

                if (currentNum % 2 == 0)
                {
                    evenNumbers.Enqueue(currentNum);
                }

                numbers.Dequeue();
            }

            Console.WriteLine(string.Join(", ", evenNumbers));
        }
    }
}
