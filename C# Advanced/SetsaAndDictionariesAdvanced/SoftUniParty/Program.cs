using System;
using System.Collections.Generic;

namespace SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vip = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "PARTY")
            {
                if (char.IsDigit(input[0]))
                {
                    vip.Add(input);
                }
                else
                {
                    regular.Add(input);
                }
            }

            string secondInput = string.Empty;

            while ((secondInput = Console.ReadLine()) != "END")
            {
                vip.Remove(secondInput);
                regular.Remove(secondInput);
            }

            Console.WriteLine(vip.Count + regular.Count);

            foreach (var guest in vip)
            {
                Console.WriteLine(guest);
            }

            foreach (var guest in regular)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
