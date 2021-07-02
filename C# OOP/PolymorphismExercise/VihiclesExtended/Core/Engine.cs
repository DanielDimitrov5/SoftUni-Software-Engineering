using System;
using System.Linq;

using VihiclesExtended.Models;

namespace VihiclesExtended.Core
{
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            string[] carInfo = Console.ReadLine().Split().Skip(1).ToArray();

            double fuelQuantityCar = double.Parse(carInfo[0]);
            double litersPerKmCar = double.Parse(carInfo[1]);
            double tankCapacityCar = double.Parse(carInfo[2]);

            Vihicle car = new Car(fuelQuantityCar, litersPerKmCar, tankCapacityCar);

            string[] truckInfo = Console.ReadLine().Split().Skip(1).ToArray();

            double fuelQuantityTruck = double.Parse(truckInfo[0]);
            double litersPerKmTruck = double.Parse(truckInfo[1]);
            double tankCapacityTruck = double.Parse(truckInfo[2]);

            Vihicle truck = new Truck(fuelQuantityTruck, litersPerKmTruck, tankCapacityTruck);

            string[] busInfo = Console.ReadLine().Split().Skip(1).ToArray();

            double fuelQuantityBus = double.Parse(busInfo[0]);
            double litersPerKmBus = double.Parse(busInfo[1]);
            double tankCapacityBus = double.Parse(busInfo[2]);

            Bus bus = new Bus(fuelQuantityBus, litersPerKmBus, tankCapacityBus);

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
                            case "Bus": bus.Drive(distance); break;
                        }

                        break;
                    case "DriveEmpty":

                        bus.DriveEmpty(distance);

                        break;
                    case "Refuel":
                        try
                        {
                            switch (vihicle)
                            {
                                case "Car": car.Refuel(liters); break;
                                case "Truck": truck.Refuel(liters); break;
                                case "Bus": bus.Refuel(liters); break;
                            }
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                        }

                        break;
                }
            }

            Console.WriteLine($"Car: {Math.Round(car.FuelQuantity, 2):F2}");
            Console.WriteLine($"Truck: {Math.Round(truck.FuelQuantity, 2):F2}");
            Console.WriteLine($"Bus: {Math.Round(bus.FuelQuantity, 2):F2}");
        }
    }
}
