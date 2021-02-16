using System;

namespace SumOfEvenOddPossitions
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int lastNum = int.Parse(Console.ReadLine());
            

            for (int i = firstNum; i <= lastNum; i++)
            {
                string currentNum = i.ToString();
                int oddSum = 0;
                int evenSum = 0;

                for (int j = 0; j < currentNum.Length; j++)
                {
                    int currentDiggit = int.Parse(currentNum[j].ToString());
                    if (j % 2 == 0)
                    {
                        oddSum += currentDiggit;
                    }
                    else if (j % 2 == 1)
                    {
                        evenSum += currentDiggit;
                    }
                }
                if (evenSum == oddSum)
                {
                    Console.Write(currentNum + " ");
                }
            }
        }

    }
}
