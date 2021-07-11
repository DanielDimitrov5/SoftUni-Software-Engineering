using System;

namespace MultiplicationTable2
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int start = int.Parse(Console.ReadLine());

            for (int i = start; i <= 10; i++)
            {
                Console.WriteLine($"{num} X {i} = {num * i}");
            }
            if (start > 10)
            {
                Console.WriteLine($"{num} X {start} = {num * start}");
            }

        }
    }
}
