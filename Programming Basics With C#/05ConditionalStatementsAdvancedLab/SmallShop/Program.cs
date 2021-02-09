using System;

namespace SmallShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string town = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            double prise = 0;

            if (town == "Sofia")
            {
                if (product == "coffee")
                {
                    prise = quantity * 0.50;
                }
                else if (product == "water")
                {
                    prise = quantity * 0.80;
                }
                else if (product == "beer")
                {
                    prise = quantity * 1.20;
                }
                else if (product == "sweets")
                {
                    prise = quantity * 1.45;
                }
                else if (product == "peanuts")
                {
                    prise = quantity * 1.60;
                }
            }
            else if (town == "Plovdiv")
            {
                if (product == "coffee")
                {
                    prise = quantity * 0.40;
                }
                else if (product == "water")
                {
                    prise = quantity * 0.70;
                }
                else if (product == "beer")
                {
                    prise = quantity * 1.15;
                }
                else if (product == "sweets")
                {
                    prise = quantity * 1.30;
                }
                else if (product == "peanuts")
                {
                    prise = quantity * 1.50;
                }
            }
            else if (town == "Varna")
            {
                if (product == "coffee")
                {
                    prise = quantity * 0.45;
                }
                else if (product == "water")
                {
                    prise = quantity * 0.70;
                }
                else if (product == "beer")
                {
                    prise = quantity * 1.10;
                }
                else if (product == "sweets")
                {
                    prise = quantity * 1.35;
                }
                else if (product == "peanuts")
                {
                    prise = quantity * 1.55;
                }
            }
            Console.WriteLine(prise);
        }
    }
}

