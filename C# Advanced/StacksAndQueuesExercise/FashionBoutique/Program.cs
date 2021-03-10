namespace FashionBoutique
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> cloths = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            int rackCapacity = int.Parse(Console.ReadLine());

            int currentRack = rackCapacity;

            int racks = 1;

            while (cloths.Count > 0)
            {
                if (cloths.Peek() <= currentRack)
                {
                    currentRack -= cloths.Pop();
                }
                else
                {
                    racks++;
                    currentRack = rackCapacity;
                }
            }

            Console.WriteLine(racks);
        }
    }
}
