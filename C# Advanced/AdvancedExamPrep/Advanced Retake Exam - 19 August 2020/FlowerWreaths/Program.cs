using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int whreats = 0;

            int storedFlowers = 0;

            while (lilies.Any() && roses.Any())
            {
                if (lilies.Peek() + roses.Peek() == 15)
                {
                    whreats++;

                    lilies.Pop();
                    roses.Dequeue();
                }
                else if (lilies.Peek() + roses.Peek() > 15)
                {
                    lilies.Push(lilies.Pop() - 2);
                }
                else
                {
                    storedFlowers += lilies.Pop() + roses.Dequeue();
                }
            }

            whreats += storedFlowers / 15;

            if (whreats >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {whreats} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - whreats} wreaths more!");
            }
        }
    }
}
