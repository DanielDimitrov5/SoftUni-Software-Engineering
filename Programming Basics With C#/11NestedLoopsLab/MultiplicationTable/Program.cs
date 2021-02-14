using System;

namespace MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int number = 1; number <= 10; number++)
            {
                for (int multiplayer = 1; multiplayer <= 10; multiplayer++)
                {
                    Console.WriteLine($"{number} * {multiplayer} = {number * multiplayer}");
                }
            }
        }
    }
}
