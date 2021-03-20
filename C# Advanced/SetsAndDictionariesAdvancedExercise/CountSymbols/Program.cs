using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> occurances = new Dictionary<char, int>();

            foreach (char ch in input)
            {
                if (!occurances.ContainsKey(ch))
                {
                    occurances.Add(ch, 0);
                }

                occurances[ch]++;
            }

            foreach (var occurance in occurances.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{occurance.Key}: {occurance.Value} time/s");
            }
        }
    }
}
