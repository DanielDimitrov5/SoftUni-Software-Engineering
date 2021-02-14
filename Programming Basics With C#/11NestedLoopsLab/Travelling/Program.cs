using System;

namespace Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string destination = Console.ReadLine();
                if (destination == "End")
                {
                    break;
                }
                double prise = double.Parse(Console.ReadLine());
                while (true)
                {
                    double savings = double.Parse(Console.ReadLine());
                    prise -= savings;
                    if (prise <= 0)
                    {
                        Console.WriteLine($"Going to {destination}!");
                        break;
                    }

                }
            }
        }
    }
}
