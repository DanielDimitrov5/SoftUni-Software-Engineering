using System;

namespace SpecialNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1111; i <= 9999; i++)
            {
                int number = i;
                bool isSpecial = true;

                while (number > 0)
                {
                   int lastDigit = number % 10;

                    if (lastDigit == 0 || n % lastDigit != 0)
                    {
                        isSpecial = false;
                        break;
                    }
                    number /= 10;
                }
                if (isSpecial)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
