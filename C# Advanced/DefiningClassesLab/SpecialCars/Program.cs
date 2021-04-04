using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecialCars
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();

            string tireInput = string.Empty;

            while ((tireInput = Console.ReadLine()) != "No more tires")
            {
                string[] tireTokens = tireInput.Split();

                Tire[] tireSet = new Tire[]
                {
                    new Tire(int.Parse(tireTokens[0]), double.Parse(tireTokens[1])),
                    new Tire(int.Parse(tireTokens[2]), double.Parse(tireTokens[3])),
                    new Tire(int.Parse(tireTokens[4]), double.Parse(tireTokens[5])),
                    new Tire(int.Parse(tireTokens[6]), double.Parse(tireTokens[7]))
                };

                tires.Add(tireSet);
            }

            List<Engine> engines = new List<Engine>();

            string engineInput = string.Empty;

            while ((engineInput = Console.ReadLine()) != "Engines done")
            {
                string[] engineTokens = engineInput.Split();

                Engine engine = new Engine(int.Parse(engineTokens[0]), double.Parse(engineTokens[1]));

                engines.Add(engine);
            }

            List<Car> cars = new List<Car>();

            string carProps = string.Empty;

            while ((carProps = Console.ReadLine()) != "Show special")
            {
                string[] props = carProps.Split();

                string make = props[0];
                string model = props[1];
                int year = int.Parse(props[2]);
                double fuelQuantity = double.Parse(props[3]);
                double fuelConsumption = double.Parse(props[4]);
                int engineIndex = int.Parse(props[5]);
                int tiresIndex = int.Parse(props[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]);

                cars.Add(car);
            }

            foreach (var car in cars
                .Where(car => car.Year >= 2017)
                .Where(hp => hp.Engine.HorsePower >= 330)
                .Where(x => x.Tires.Sum(y => y.Pressure) >= 9 && x.Tires.Sum(y => y.Pressure) <= 10))
            {
                car.FuelQuantity -= car.FuelConsumption * 20 / 100;

                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Make: {car.Make}");
                sb.AppendLine($"Model: {car.Model}");
                sb.AppendLine($"Year: {car.Year}");
                sb.AppendLine($"HorsePowers: {car.Engine.HorsePower}");
                sb.Append($"FuelQuantity: {car.FuelQuantity}");

                Console.WriteLine(sb.ToString());
            }
        }
    }
}
