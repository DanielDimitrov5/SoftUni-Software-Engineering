using System;

namespace depoditCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double deposit = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double interest = deposit * percent / 100;
            double oneMonthInterest = interest / 12;
            double sum = deposit + (months * oneMonthInterest);

            Console.WriteLine(sum);

                //.общата сума е 200лв депозит +(3(срок на депозита) * 0.95 лв)
        }
    }
}
