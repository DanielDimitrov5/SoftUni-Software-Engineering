using System;

namespace Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int cakeWidth = int.Parse(Console.ReadLine());
            int cakeLenght = int.Parse(Console.ReadLine());
            int cakeP = cakeWidth * cakeLenght;

            while (cakeP > 0)
            {
                string stop = Console.ReadLine();
                if (stop == "STOP")
                {
                    Console.WriteLine($"{cakeP} pieces are left.");
                    break;
                }
                int piece = int.Parse(stop);
                cakeP -= piece;
            }

            if (cakeP < 0)
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(cakeP)} pieces more.");
            }
        }
    }
}
