using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Func<List<int>, string, List<int>> manipulator = (list, command) =>
            {
                switch (command)
                {
                    case "add": return list.Select(x => x + 1).ToList();
                    case "multiply": return list.Select(x => x * 2).ToList();
                    case "subtract": return list.Select(x => x - 1).ToList();
                    default: return list;
                }
            };

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", list));
                }
                else
                {
                    list = manipulator(list, command);
                }
            }
        }
    }
}
