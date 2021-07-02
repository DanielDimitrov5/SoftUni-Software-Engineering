using System;
using System.Linq;
using Vihicles.Models;

namespace Vihicles
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split().Skip(1).ToArray();

            double fuelQuantityCar = double.Parse(carInfo[0]);
            double litersPerKmCar = double.Parse(carInfo[1]);

            Vihicle car = new Car(fuelQuantityCar, litersPerKmCar);

            string[] truckInfo = Console.ReadLine().Split().Skip(1).ToArray();

            double fuelQuantityTruck = double.Parse(truckInfo[0]);
            double litersPerKmTruck = double.Parse(truckInfo[1]);

            Vihicle truck = new Truck(fuelQuantityTruck, litersPerKmTruck);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string command = input[0];
                string vihicle = input[1];

                double distance = double.Parse(input[2]);
                double liters = distance;

                switch (command)
                {
                    case "Drive":

                        switch (vihicle)
                        {
                            case "Car": car.Drive(distance); break;
                            case "Truck": truck.Drive(distance); break;
                        }

                        break;
                    case "Refuel":

                        switch (vihicle)
                        {
                            case "Car": car.Refuel(liters); break;
                            case "Truck": truck.Refuel(liters); break;
                        }

                        break;
                }
            }

            Console.WriteLine($"Car: {Math.Round(car.FuelQuntity, 2):F2}");
            Console.WriteLine($"Truck: {Math.Round(truck.FuelQuntity, 2):F2}");
        }
    }
}
