using System;

namespace EasterEggsBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstPlayersEggs = int.Parse(Console.ReadLine());
            int secondPlayersEggs = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            while (input != "End of battle")
            {
                if (input == "one")
                {
                    secondPlayersEggs--;
                }
                else
                {
                    firstPlayersEggs--;
                }

                if (firstPlayersEggs == 0 || secondPlayersEggs == 0)
                {
                    break;
                }

                input = Console.ReadLine();
            }

            if (input == "End of battle")
            {
                Console.WriteLine($"Player one has {firstPlayersEggs} eggs left.");
                Console.WriteLine($"Player two has {secondPlayersEggs} eggs left.");
            }
            else if (firstPlayersEggs == 0)
            {
                Console.WriteLine($"Player one is out of eggs. Player two has {secondPlayersEggs} eggs left.");
            }
            else
            {
                Console.WriteLine($"Player two is out of eggs. Player one has {firstPlayersEggs} eggs left.");
            }
        }
    }
}
