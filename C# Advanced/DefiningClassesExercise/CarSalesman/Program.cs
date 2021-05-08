using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>(n);

            for (int i = 0; i < n; i++)
            {
                string[] engineData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = engineData[0];
                int power = int.Parse(engineData[1]);

                Engine newEngine = new Engine(model, power);

                if (engineData.Length == 3)
                {
                    if (int.TryParse(engineData[2], out int disp))
                    {
                        newEngine.Displacement = disp;
                    }
                    else
                    {
                        newEngine.Efficienty = engineData[2];
                    }
                }
                else if (engineData.Length == 4)
                {
                    newEngine.Displacement = int.Parse(engineData[2]);
                    newEngine.Efficienty = engineData[3];
                }

                engines.Add(newEngine);
            }

            int m = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>(m);

            for (int i = 0; i < m; i++)
            {
                string[] carData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carData[0];

                Engine currentEngine = engines.Where(x => x.Model == carData[1]).FirstOrDefault();

                Car newCar = new Car(model, currentEngine);

                if (carData.Length == 3)
                {
                    if (int.TryParse(carData[2], out int weight))
                    {
                        newCar.Weight = weight;
                    }
                    else
                    {
                        newCar.Color = carData[2];
                    }
                }
                else if (carData.Length == 4)
                {
                    newCar.Weight = int.Parse(carData[2]);
                    newCar.Color = carData[3];
                }

                cars.Add(newCar);
            }


            foreach (Car car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
