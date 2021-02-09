using System;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowers = Console.ReadLine();
            int amount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double prise = 0;
            //double rose = 5;
            //double dahlias = 3.80;
            //double tulips = 2.80;
            //double narcissus = 3;
            //double gladiolus = 2.50;
            double discount = 1;
            
            switch (flowers)
            {
                case "Roses":
                    prise = 5;
                    if (amount > 80)
                    {
                        discount = 0.9;
                    }
                    break;
                case "Dahlias":
                    prise = 3.80;
                    if (amount > 90)
                    {
                        discount = 0.85;
                    }
                    break;
                case "Tulips":
                    prise = 2.80;
                    if (amount > 80)
                    {
                        discount = 0.85;
                    }
                    break;
                case "Narcissus":
                    prise = 3;
                    if (amount < 120)
                    {
                        discount = 1.15;
                    }
                    break;
                case "Gladiolus":
                    prise = 2.50;
                    if (amount < 80)
                    {
                        discount = 1.20;
                    }
                    break;

            }
            double totalPrise = (prise * amount) * discount;
            if (budget >= totalPrise)
            {
                Console.WriteLine($"Hey, you have a great garden with {amount} {flowers} and {budget - totalPrise:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {totalPrise - budget:f2} leva more.");
            }
            


        }  
    }
}
