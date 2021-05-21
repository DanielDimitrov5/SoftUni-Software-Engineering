using System;

namespace FirstAndReserveTeam
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] test = new int[] { 1, 2 };

            Console.WriteLine(string.Join(" - ", test));

            test[0] = test[0] ^ test[1];
            test[1] = test[1] ^ test[0];
            test[0] = test[0] ^ test[1];

            Console.WriteLine(string.Join(" - ", test));
        }
    }
}
