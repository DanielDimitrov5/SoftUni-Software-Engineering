namespace MatchingBrackets
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            Stack<int> openingBrackets = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    openingBrackets.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int startIndex = openingBrackets.Pop();

                    string subExpression = expression.Substring(startIndex, i - startIndex + 1);

                    Console.WriteLine(subExpression);
                }
            }
        }
    }
}
