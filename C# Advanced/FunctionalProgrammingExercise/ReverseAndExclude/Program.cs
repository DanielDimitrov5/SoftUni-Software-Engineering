using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Reverse().Select(int.Parse).ToList();
            int divider = int.Parse(Console.ReadLine());

            Func<int, bool> checker = n => n % divider != 0;

            Func<List<int>, List<int>> remover = list => list.Where(checker).ToList();

            Console.WriteLine(string.Join(" ", remover(numbers)));
        }
    }
}
