namespace BoxOfT
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] pirateShip = Console.ReadLine().Split('>').Select(int.Parse).ToArray();
            int[] warship = Console.ReadLine().Split('>').Select(int.Parse).ToArray();

            int maxHealth = int.Parse(Console.ReadLine());

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Retire")
            {
                string[] token = input.Split();

                string command = token[0];

                switch (command)
                {
                    case "Fire":

                        int fireIndex = int.Parse(token[1]);
                        int dmg = int.Parse(token[2]);

                        if (fireIndex >= 0 && fireIndex < warship.Length)
                        {
                            warship[fireIndex] -= dmg;

                            if (warship[fireIndex] <= 0)
                            {
                                Console.WriteLine("You won! The enemy ship has sunken.");
                                Environment.Exit(0); //stops the program
                            }
                        }
                        break;
                    case "Defend":

                        int startIndex = int.Parse(token[1]);
                        int endIndex = int.Parse(token[2]);
                        int damage = int.Parse(token[3]);

                        if (startIndex >= 0 && endIndex < pirateShip.Length)
                        {
                            for (int i = startIndex; i <= endIndex; i++)
                            {
                                pirateShip[i] -= damage;

                                if (pirateShip[i] <= 0)
                                {
                                    Console.WriteLine("You lost! The pirate ship has sunken.");
                                    Environment.Exit(0);
                                }
                            }
                        }
                        break;
                    case "Repair":

                        int repairIndex = int.Parse(token[1]);
                        int health = int.Parse(token[2]);

                        if (repairIndex >= 0 && repairIndex < pirateShip.Length)
                        {
                            pirateShip[repairIndex] += health;

                            if (pirateShip[repairIndex] > maxHealth)
                            {
                                pirateShip[repairIndex] = maxHealth;
                            }
                        }
                        break;
                    case "Status":

                        int count = 0;

                        foreach (var section in pirateShip)
                        {
                            if (section < maxHealth * 0.2)
                            {
                                count++;
                            }
                        }

                        Console.WriteLine($"{count} sections need repair.");
                        break;
                }
            }

            Console.WriteLine($"Pirate ship status: {pirateShip.Sum()}");
            Console.WriteLine($"Warship status: {warship.Sum()}");
        }
    }
}
