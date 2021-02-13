using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double vacationPrise = double.Parse(Console.ReadLine());
            double money = double.Parse(Console.ReadLine());
            int spendCounter = 0;
            int dayCount = 0;

            if (vacationPrise <= money)
            {
                Console.WriteLine("You saved the money for 0 days.");
            }
            else
            {
                while (true)
                {
                    string spendSave = Console.ReadLine();
                    if (spendSave == "spend")
                    {
                        double spend = double.Parse(Console.ReadLine());
                        spendCounter++;
                        money -= spend;
                        if (money < 0)
                        {
                            money = 0;
                        }
                        if (spendCounter == 5)
                        {
                            Console.WriteLine($"You can't save the money.\n{dayCount + 1}");
                            break;
                        }
                    }
                    else if (spendSave == "save")
                    {
                        double save = double.Parse(Console.ReadLine());
                        spendCounter = 0;
                        money += save;
                    }
                    dayCount++;
                    if (vacationPrise <= money)
                    {
                        Console.WriteLine($"You saved the money for {dayCount} days.");
                        break;
                    }
                }
            }
        }
    }
}
