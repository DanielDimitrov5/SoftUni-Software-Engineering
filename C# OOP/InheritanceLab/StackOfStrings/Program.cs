using System;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();

            stack.Push("1");
            stack.Push("2");
            stack.Push("3");

            foreach (var item in stack)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine("-----------");

            StackOfStrings newStack = new StackOfStrings();

            newStack.Push("1");
            newStack.Push("2");
            newStack.Push("3");

            stack.AddRange(newStack);

            foreach (var item in stack)
            {
                Console.Write(item + " ");
            }
        }
    }
}
