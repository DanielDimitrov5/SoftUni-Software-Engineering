using System;

namespace SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int nonPrimeSum = 0;
            int primeSum = 0;
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "stop")
                {
                    break;
                }
                int num = int.Parse(command);
                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }
                for (int i = 2; i <= (int)Math.Sqrt(num); i++)
                {
                    if (num % i == 0)
                    {
                        nonPrimeSum += num;
                        break;
                    }
                }
                sum += num;
                primeSum = sum - nonPrimeSum;
            }

            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");
        }
    }
}
