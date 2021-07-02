using System;
using System.Collections.Generic;
using System.Text;

namespace Vihicles.Models
{
    public abstract class Vihicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        protected Vihicle(double fuelQuantity, double fuelConsumption)
        {
            this.fuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption;
        }

        public double FuelQuntity
        {
            get => fuelQuantity;
        }


        public void Drive(double distance)
        {
            if (fuelQuantity >= fuelConsumption * distance)
            {
                fuelQuantity -= fuelConsumption * distance;

                Console.WriteLine($"{GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double amount)
        {
            fuelQuantity += amount;
        }
    }
}
