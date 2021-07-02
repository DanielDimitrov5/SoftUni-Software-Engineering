using System;
using System.Collections.Generic;
using System.Text;

namespace Vihicles.Models
{
    public class Car : Vihicle
    {
        private const double airConditionConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption + airConditionConsumption)
        { }
    } 
}
