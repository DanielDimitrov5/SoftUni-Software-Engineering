namespace VihiclesExtended.Models
{
    public class Bus : Vihicle
    {
        private const double airConditionConsumptionBus = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption + airConditionConsumptionBus, tankCapacity)
        { }

        public void DriveEmpty(double distance)
        {
            this.fuelConsumption -= airConditionConsumptionBus;

            base.Drive(distance);
        }
    }
}
