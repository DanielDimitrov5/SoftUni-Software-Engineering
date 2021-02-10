using System;

namespace ForLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int i = 1; i <= num; i += 3)
            {
                Console.WriteLine(i);
            }
        }
    }
}
