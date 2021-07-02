using System;

using VihiclesExtended.Exeptions;

namespace VihiclesExtended.Models
{
    public abstract class Vihicle
    {
        protected double fuelQuantity;
        protected double fuelConsumption;
        protected double tankCapacity;

        public Vihicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.fuelConsumption = fuelConsumption;
            this.tankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;

            private set
            {
                if (tankCapacity < value)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }

        public virtual void Drive(double distance)
        {
            if (FuelQuantity >= fuelConsumption * distance)
            {
                FuelQuantity -= fuelConsumption * distance;

                Console.WriteLine($"{GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException(Exeption.InvalidFuelAmount);
            }

            if (tankCapacity >= fuelQuantity + amount)
            {
                fuelQuantity += amount;
            }
            else
            {
                Console.WriteLine($"Cannot fit {amount} fuel in the tank");
            }
        }
    }
}
