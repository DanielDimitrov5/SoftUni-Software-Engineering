namespace BalancedPerentheses
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> charStack = new Stack<char>();

            bool isBalanced = true;

            foreach (char ch in input)
            {
                if (ch == '(' || ch == '{' || ch == '[')
                {
                    charStack.Push(ch);
                }
                else if (charStack.Any())
                {
                    if ((charStack.Peek() == '(' && ch == ')') ||
                        (charStack.Peek() == '{' && ch == '}') ||
                        (charStack.Peek() == '[' && ch == ']'))
                    {
                        charStack.Pop();
                    }
                }
                else
                {
                    isBalanced = false;
                }
            }

            if (charStack.Any() || !isBalanced)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
