using System;

namespace Easter_Cpmpetition
{
    class Program
    {
        static void Main(string[] args)
        {
            int kozunatsi = int.Parse(Console.ReadLine());
            int totalPoints = 0;
            int currentMax = int.MinValue;
            string currentWinner = string.Empty;

            for (int i = 0; i < kozunatsi; i++)
            {
                string baker = Console.ReadLine();
                while (true)
                {
                    string command = Console.ReadLine();
                    if (command == "Stop")
                    {
                        Console.WriteLine($"{baker} has {totalPoints} points.");
                        if (totalPoints > currentMax)
                        {
                            Console.WriteLine($"{baker} is the new number 1!");
                            currentMax = totalPoints;
                            currentWinner = baker;
                        }
                        totalPoints = 0;
                        break;
                    }

                    int points = int.Parse(command);
                    totalPoints += points;
                }
            }

            Console.WriteLine($"{currentWinner} won competition with {currentMax} points!");
        }
    }
}
