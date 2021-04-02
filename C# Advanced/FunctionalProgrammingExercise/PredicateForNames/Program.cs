using System;

namespace PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxLength = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split();

            Predicate<string> checker = x => x.Length <= maxLength;

            foreach (var name in names)
            {
                if (checker(name))
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
