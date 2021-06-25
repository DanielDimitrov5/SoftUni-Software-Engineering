using System;
using System.Collections.Generic;
using System.Linq;

namespace TheFightFor_Gondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());

            Queue<int> plates = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            string output = string.Empty;

            bool deffended = true;

            for (int i = 1; i <= waves; i++)
            {
                Stack<int> orcs = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

                if (i % 3 == 0)
                {
                    int newPlate = int.Parse(Console.ReadLine());
                    plates.Enqueue(newPlate);
                }

                while (orcs.Any())
                {
                    if (plates.Any() == false)
                    {
                        break;
                    }

                    if (plates.Peek() > orcs.Peek())
                    {
                        int[] mod = plates.ToArray();

                        mod[0] -= orcs.Pop();

                        plates = new Queue<int>(mod);
                    }
                    else if (plates.Peek() < orcs.Peek())
                    {
                        orcs.Push(orcs.Pop() - plates.Dequeue());
                    }
                    else
                    {
                        orcs.Pop();
                        plates.Dequeue();
                    }
                }

                if (plates.Any() == false)
                {
                    deffended = false;
                    output = string.Join(", ", orcs);
                    break;
                }
            }

            if (deffended)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {output}");
            }
        }
    }
}
