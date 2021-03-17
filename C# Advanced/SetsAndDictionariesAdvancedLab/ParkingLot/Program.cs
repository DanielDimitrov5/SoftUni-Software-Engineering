using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carNumbers = new HashSet<string>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] data = input.Split(", ");

                string inOut = data[0];
                string number = data[1];

                if (inOut == "IN")
                {
                    carNumbers.Add(number);
                }
                else
                {
                    carNumbers.Remove(number);
                }

                input = Console.ReadLine();
            }

            if (carNumbers.Any())
            {
                foreach (var number in carNumbers)
                {
                    Console.WriteLine(number);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
