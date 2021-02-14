using System;
using System.Globalization;

namespace SumOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            int combinationCounter = 0;
            bool combination = false;

            for (int i = num1; i <= num2; i++)
            {
                for (int j = num1; j <= num2; j++)
                {
                    combinationCounter++;
                    if (i + j == magicNumber)
                    {
                        combination = true;
                        Console.WriteLine($"Combination N:{combinationCounter} ({i} + {j} = {magicNumber})");
                        break;
                    }
                }
                if (combination)
                {
                    break;
                }
            }
            if (!false)
            {
                Console.WriteLine($"{combinationCounter} combinations - neither equals {magicNumber}");
            }
        }
    }
}
