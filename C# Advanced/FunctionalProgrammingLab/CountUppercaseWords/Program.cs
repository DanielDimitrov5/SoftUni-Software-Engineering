using System;
using System.Linq;

namespace CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> upperChecker = x => char.IsUpper(x[0]);

            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(upperChecker)
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, input));
        }
    }
}
