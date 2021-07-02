using System;
using System.Collections.Generic;
using System.Text;

namespace Vihicles.Models
{
    public class Truck : Vihicle
    {
        private const double airConditionConsumption = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption + airConditionConsumption)
        { }

        public override void Refuel(double amount)
        {
            base.Refuel(amount * 0.95);
        }
    }
}
