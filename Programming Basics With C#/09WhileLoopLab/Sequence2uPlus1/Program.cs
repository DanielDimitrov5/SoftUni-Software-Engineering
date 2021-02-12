using System;

namespace Sequence2uPlus1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
             int currentNumber = 1;

            while (n >= currentNumber)
            {
                Console.WriteLine(currentNumber);
                currentNumber = currentNumber * 2 + 1;
            }
        }
    }
}
