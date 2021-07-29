namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const int cubicCentimeters = 5000;
        private const int minHorsePower = 400;
        private const int maxHorsePower = 600;

        public MuscleCar(string model, int horsePower) 
            : base(model, horsePower, cubicCentimeters, minHorsePower, maxHorsePower)
        {
        }
    }
}