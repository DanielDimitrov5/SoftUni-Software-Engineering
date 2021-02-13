using System;

namespace Steps
{
    class Program
    {
        static void Main(string[] args)
        {
            int stepsGoal = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Going home")
                {
                    int lastSteps = int.Parse(Console.ReadLine());
                    stepsGoal += lastSteps;
                    if (stepsGoal >= 10000)
                    {
                        Console.WriteLine("Goal reached! Good job!");
                        Console.WriteLine($"{stepsGoal - 10000} steps over the goal!");
                    }
                    else
                    {
                        Console.WriteLine($"{10000 - stepsGoal} more steps to reach goal.");
                    }
                    break;
                }
                int steps = int.Parse(command);
                stepsGoal += steps;
                if (stepsGoal >= 10000)
                {
                    Console.WriteLine("Goal reached! Good job!");
                    Console.WriteLine($"{stepsGoal - 10000} steps over the goal!");
                    break;
                }

            }
        }
    }
}
