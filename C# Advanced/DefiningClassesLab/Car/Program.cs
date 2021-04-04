using System;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Tire[] tires = new Tire[4]
            {
                new Tire(1, 2.5),
                new Tire(1, 2.3),
                new Tire(2, 2.2),
                new Tire(2, 2.4),
            };

            Engine engine = new Engine(560, 6300);

            Car newCar = new Car("Lambo", "Lambo", 2009, 75, 20, engine, tires);

            Console.WriteLine(newCar.WhoAmI());
        }
    }
}
