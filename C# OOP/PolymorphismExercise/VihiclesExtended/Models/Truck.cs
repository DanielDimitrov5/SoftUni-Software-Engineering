using System;
using VihiclesExtended.Exeptions;

namespace VihiclesExtended.Models
{
    public class Truck : Vihicle
    {
        private const double airConditionConsumption = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption + airConditionConsumption, tankCapacity)
        { }

        public override void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException(Exeption.InvalidFuelAmount);
            }

            if (tankCapacity >= fuelQuantity + amount)
            {
                fuelQuantity += amount * 0.95;
            }
            else
            {
                Console.WriteLine($"Cannot fit {amount} fuel in the tank");
            }
        }
    }
}
