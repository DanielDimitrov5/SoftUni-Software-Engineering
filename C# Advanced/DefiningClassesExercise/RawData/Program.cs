using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>(n);

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", 6, StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];

                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);

                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];

                Cargo cargo = new Cargo(cargoWeight, cargoType);

                double[] tireData = input[5].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

                Tire[] tireSet = new Tire[4]
                {
                    new Tire(tireData[0], (int)tireData[1]),
                    new Tire(tireData[2], (int)tireData[3]),
                    new Tire(tireData[4], (int)tireData[5]),
                    new Tire(tireData[6], (int)tireData[7])
                };

                Car newCar = new Car(model, engine, cargo, tireSet);

                cars.Add(newCar);
            }

            string command = Console.ReadLine();

            Func<Car, bool> filter = car =>
            {
                if (command == "fragile")
                {
                    return car.Cargo.CargoType == "fragile" && car.Tires.Any(tire => tire.TirePressure <= 1);
                }
                else if (command == "flamable")
                {
                    return car.Cargo.CargoType == "flamable" && car.Engine.EnginePower > 250;
                }

                return false;
            };

            foreach (Car car in cars.Where(filter))
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
