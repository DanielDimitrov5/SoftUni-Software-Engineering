using System;

namespace _7._Theatre_Promotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfDay = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            int price = 0;

            switch (typeOfDay)
            {
                case "Weekday":
                    if (0 <= age && age <= 18)
                    {
                        price = 12;
                    }
                    if (19 <= age && age <= 64)
                    {
                        price = 18;
                    }
                    if (65 <= age && age <= 122)
                    {
                        price = 12;
                    }
                    break;
                case "Weekend":
                    if (0 <= age && age <= 18)
                    {
                        price = 15;
                    }
                    if (19 <= age && age <= 64)
                    {
                        price = 20;
                    }
                    if (65 <= age && age <= 122)
                    {
                        price = 15;
                    }
                    break;
                case "Holiday":
                    if (0 <= age && age <= 18)
                    {
                        price = 5;
                    }
                    if (19 <= age && age <= 64)
                    {
                        price = 12;
                    }
                    if (65 <= age && age <= 122)
                    {
                        price = 10;
                    }
                    break;
            }
            if (price == 0)
            {
                Console.WriteLine("Error!");
            }
            else
            {
                Console.WriteLine($"{price}$");
            }
        }
    }
}
