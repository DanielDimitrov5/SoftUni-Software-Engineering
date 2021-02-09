using System;

namespace Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double studioPrisePerNight = 0;
            double apartmentPrisePerNight = 0;
            double discountStudio = 1;
            double discountApartment = 1;
            if (month == "May" || month == "October")
            {
                studioPrisePerNight = 50;
                apartmentPrisePerNight = 65;
            }
            else if (month == "June" || month == "September")
            {
                studioPrisePerNight = 75.20;
                apartmentPrisePerNight = 68.70;
            }
            else if (month == "July" || month == "August")
            {
                studioPrisePerNight = 76;
                apartmentPrisePerNight = 77;
            }
            if ((month == "May" || month == "October")  && nights > 7 && nights <= 14)
            {
                discountStudio = 0.95;
            }
            else if ((month == "May" || month == "October") && nights > 14)
            {
                discountStudio = 0.7;
                discountApartment = 0.9;
            }
            else if ((month == "June" || month == "September") && nights > 14)
            {
                discountStudio = 0.8;
                discountApartment = 0.9;
            }
            else if (nights > 14)
            {
                discountApartment = 0.9;
            }
            double totalPriseStudio = (nights * studioPrisePerNight) * discountStudio;
            double totalPriseApartment = (nights * apartmentPrisePerNight) * discountApartment;
            Console.WriteLine($"Apartment: {totalPriseApartment:f2} lv.");
            Console.WriteLine($"Studio: {totalPriseStudio:f2} lv.");
            
            
        }
    }
}
