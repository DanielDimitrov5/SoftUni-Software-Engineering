using System;

namespace EasterDecoration
{
    class Program
    {
        static void Main(string[] args)
        {
            int customers = int.Parse(Console.ReadLine());

            double prise = 0;
            int goods = 0;
            double totalSales = 0;

            for (int i = 0; i < customers; i++)
            {
                while (true)
                {
                    string command = Console.ReadLine();
                    if (command == "Finish")
                    {
                        if (goods % 2 == 0)
                        {
                            prise *= 0.8;
                        }
                        totalSales += prise;
                        Console.WriteLine($"You purchased {goods} items for {prise:f2} leva.");
                        prise = 0;
                        goods = 0;
                        break;
                    }

                    if (command == "basket")
                    {
                        prise += 1.5;
                    }
                    else if (command == "wreath")
                    {
                        prise += 3.8;
                    }
                    else
                    {
                        prise += 7;
                    }
                    goods++;

                }
            }
            Console.WriteLine($"Average bill per client is: {totalSales / customers:f2} leva.");
        }
    }
}
