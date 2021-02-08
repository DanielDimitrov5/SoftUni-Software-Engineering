using System;

namespace SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int nights = days - 1;
            string typeOfRoom = Console.ReadLine();
            string rating = Console.ReadLine();
            double firstPrise = 0;
            double discount = 0;
            double extraDiscount = 0;
            switch (typeOfRoom)
            {
                case "apartment":
                    if (nights < 10)
                    {
                        discount = 0.7;
                    }
                    else if (nights >= 10 && nights <= 15)
                    {
                        discount = 0.65;
                    }
                    else
                    {
                        discount = 0.5;
                    }
                    break;
                case "president apartment":
                    if (nights < 10)
                    {
                        discount = 0.9;
                    }
                    else if (nights >= 10 && nights <= 15)
                    {
                        discount = 0.85;
                    }
                    else
                    {
                        discount = 0.8;
                    }
                    break;
                default:
                    discount = 1;
                    break;
            }
            switch (typeOfRoom)
            {
                case "apartment":
                    firstPrise = (nights * 25) * discount;
                    break;
                case "room for one person":
                    firstPrise = (nights * 18) * discount;
                    break;
                case "president apartment":
                    firstPrise = (nights * 35) * discount;
                    break;
            }
            double prise = firstPrise;
            switch (rating)
            {
                case "positive":
                    extraDiscount = 1.25;
                    break;
                default:
                    extraDiscount = 0.9;
                    break;

            }
            double totalPrise = prise * extraDiscount;
            Console.WriteLine($"{totalPrise:f2}");



        }
    }
}
