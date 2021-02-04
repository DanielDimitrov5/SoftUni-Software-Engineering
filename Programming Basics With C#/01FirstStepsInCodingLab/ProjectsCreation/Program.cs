using System;

namespace Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int projects = int.Parse(Console.ReadLine());
            int hoursNeeded = projects * 3;

            Console.WriteLine($"The architect {name} will need {hoursNeeded} hours to complete {projects} project/s.");

        }
    }
}
