using System;
using System.Runtime.CompilerServices;

namespace NumberPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int nCurrent = 1;
            bool flag = false;

            for (int rows = 1; rows <= n; rows++)
            {
                for (int cols = 1; cols <= rows; cols++)
                {
                    Console.Write($"{nCurrent} ");
                    nCurrent++;
                    if (nCurrent > n)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    break;
                }
                Console.WriteLine();
            }
        }
    }
}
