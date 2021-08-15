using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (racerOne.IsAvailable() == false && racerTwo.IsAvailable() == false)
            {
                return "Race cannot be completed because both racers are not available!";
            }

            if (racerTwo.IsAvailable() == false)
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }

            if (racerOne.IsAvailable() == false)
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }

            double racingBehaviorMultiplierRacerOne = racerOne.RacingBehavior == "strict" ? 1.2 : 1.1;

            double chanceOfWinningRacerOne =
                racerOne.Car.HorsePower * racerOne.DrivingExperience * racingBehaviorMultiplierRacerOne;

            double racingBehaviorMultiplierRacerTwo = racerTwo.RacingBehavior == "strict" ? 1.2 : 1.1;

            double chanceOfWinningRacerTwo =
                racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racingBehaviorMultiplierRacerTwo;

            racerOne.Race();
            racerTwo.Race();

            string winner = chanceOfWinningRacerOne > chanceOfWinningRacerTwo ? racerOne.Username : racerTwo.Username;

            return $"{racerOne.Username} has just raced against {racerTwo.Username}! {winner} is the winner!";
        }
    }
}