using System;
using System.Linq;

namespace Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] nameAdres = Console.ReadLine().Split();

            CustomTuple<string, string> first = new CustomTuple<string, string>(nameAdres[0] + " " + nameAdres[1], nameAdres[2]);

            Console.WriteLine(first);

            string[] drunk = Console.ReadLine().Split();

            string name = drunk[0];
            long beer = long.Parse(drunk[1]);

            CustomTuple<string, long> drunkMan = new CustomTuple<string, long>(name, beer);

            Console.WriteLine(drunkMan);

            string[] numbers = Console.ReadLine().Split();

            long longeger = long.Parse(numbers[0]);
            double floatNum = double.Parse(numbers[1]);

            CustomTuple<long, double> nums = new CustomTuple<long, double>(longeger, floatNum);

            Console.WriteLine(nums);
        }
    }
}
