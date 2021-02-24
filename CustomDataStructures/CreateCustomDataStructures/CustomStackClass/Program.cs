using System;

namespace CustomStackClass
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStack stack = new CustomStack();

            for (int i = 0; i < 10; i++)
            {
                stack.Push(i + 1);
            }

            Console.WriteLine(stack.Count);

            Console.WriteLine(stack.ToString());

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());

            Console.WriteLine(stack.Count);

            Console.WriteLine(stack.ToString());
        }
    }
}
