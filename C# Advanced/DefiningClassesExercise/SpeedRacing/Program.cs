using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionPerKm = double.Parse(input[2]);

                Car newCar = new Car(model, fuelAmount, fuelConsumptionPerKm);

                cars.Add(newCar);
            }

            string driveCommand = string.Empty;

            while ((driveCommand = Console.ReadLine()) != "End")
            {
                string[] input = driveCommand.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carModel = input[1];
                double amountOfKm = double.Parse(input[2]);

                Car currentCar = cars.Where(x => x.Model == carModel).FirstOrDefault();

                if (currentCar.CanDrive(currentCar.FuelAmount, currentCar.FuelConsumptionPerKilometer, amountOfKm))
                {
                    currentCar.FuelAmount -= amountOfKm * currentCar.FuelConsumptionPerKilometer;
                    currentCar.TravelledDistance += amountOfKm;
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }
}
