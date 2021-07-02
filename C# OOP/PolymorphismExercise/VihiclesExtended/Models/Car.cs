namespace VihiclesExtended.Models
{
    public class Car : Vihicle
    {
        private const double airConditionConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption + airConditionConsumption, tankCapacity)
        { }
    } 
}
