using System;

namespace Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double change = double.Parse(Console.ReadLine());
            change = change * 1000.00 / 10;
            double twoLeva = 200.00;
            double oneLeva = 100.00;
            double fiftyStotinki = 50.00;
            double twentyStotinki = 20.00;
            double tenStotinki = 10.00;
            double fiveStotinki = 5.00;
            double twoStotinki = 2.00;
            double oneStotinki = 1.00;

            int coinCounter = 0;

            while (true)
            {
                if (change / twoLeva >= 1)
                {
                    coinCounter++;
                    change -= twoLeva;
                }
                else if (change / oneLeva >= 1)
                {
                    coinCounter++;
                    change -= oneLeva;
                }
                else if (change / fiftyStotinki >= 1)
                {
                    coinCounter++;
                    change -= fiftyStotinki;
                }
                else if (change / twentyStotinki >= 1)
                {
                    coinCounter++;
                    change -= twentyStotinki;
                }
                else if (change / tenStotinki >= 1)
                {
                    coinCounter++;
                    change -= tenStotinki;
                }
                else if (change / fiveStotinki >= 1)
                {
                    coinCounter++;
                    change -= fiveStotinki;
                }
                else if (change / twoStotinki >= 1)
                {
                    coinCounter++;
                    change -= twoStotinki;
                }
                else if (change / oneStotinki >= 1)
                {
                    coinCounter++;
                    change -= oneStotinki;
                }

                if (change == 0)
                {
                    break;
                }
            }
            Console.WriteLine(coinCounter);
        }
    }
}
