using System;

namespace CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int bakers = int.Parse(Console.ReadLine());
            int cakes = int.Parse(Console.ReadLine());
            int waffles = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());

            int cakesPerDay = cakes * 45;
            double wafflesPerDay = waffles * 5.80;
            double pancakesPerDay = pancakes * 3.20;

            double oneDayProffit = (cakesPerDay + wafflesPerDay + pancakesPerDay) * bakers;
            double campaignSum = oneDayProffit * days;
            double campaignProffit = campaignSum * 0.875;

            Console.WriteLine(campaignProffit);

        }
    }
}
