using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> list = new List<int>();

            for (int i = 1; i < n + 1; i++)
            {
                list.Add(i);
            }

            Func<List<int>, int[], List<int>> func = (list, nums) =>
            {
                List<int> newList = new List<int>();

                foreach (var item in list)
                {
                    bool flag = false;

                    foreach (var num in nums)
                    {
                        if (item % num == 0)
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                            break;
                        }
                    }

                    if (flag)
                    {
                        newList.Add(item);
                    }
                }

                return newList;
            };

            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            list = func(list, nums);

            Console.WriteLine(string.Join(' ', list));
        }
    }
}
