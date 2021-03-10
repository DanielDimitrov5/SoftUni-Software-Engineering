namespace MaxAndMinElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> nums = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();

                int number = int.Parse(command[0]);

                switch (number)
                {
                    case 1:
                        nums.Push(int.Parse(command[1]));
                        break;
                    case 2:

                        nums.TryPop(out int popPossible);
                        
                        break;
                    case 3:

                        if (nums.Count > 0)
                        {
                            Console.WriteLine(nums.Max());
                        }
                        break;
                    case 4:

                        if (nums.Count > 0)
                        {
                            Console.WriteLine(nums.Min());
                        }
                        break;
                }

            }

            Console.WriteLine(string.Join(", ", nums));
        }
    }
}
