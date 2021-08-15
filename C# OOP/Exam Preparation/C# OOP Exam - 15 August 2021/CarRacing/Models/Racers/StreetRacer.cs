using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const int drivingExperience = 10;
        private const string racingBehavior = "aggressive";

        public StreetRacer(string username, ICar car)
            : base(username, racingBehavior, drivingExperience, car)
        {
        }

        public override void Race()
        {
            base.Race();

            DrivingExperience += 5;
        }
    }
}