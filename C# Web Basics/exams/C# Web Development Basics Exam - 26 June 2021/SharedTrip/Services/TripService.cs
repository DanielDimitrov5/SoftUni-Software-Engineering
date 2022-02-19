using SharedTrip.Data;
using SharedTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Services
{
    public class TripService : ITripService
    {
        private readonly ApplicationDbContext context;

        public TripService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void AddTrip(string startingPoint, string endPoint, string departureTime, string carImage, int seats, string description)
        {
            Trip trip = new Trip
            {
                StartPoint = startingPoint,
                EndPoint = endPoint,
                DepartureTime = DateTime.Parse(departureTime),
                ImagePath = carImage,
                Seats = seats,
                Description = description,
            };

            context.Trips.Add(trip);

            context.SaveChanges();
        }

        public void AddUserToTrip(string userId, string tripId)
        {
            UserTrip userTrip = new UserTrip
            {
                UserId = userId,
                TripId = tripId
            };

            context.UserTrips.Add(userTrip);

            context.Trips.Find(tripId).Seats--;

            context.SaveChanges();
        }

        public bool AreThereSeatsAvailable(string tripId)
        {
            return context.Trips.Find(tripId).Seats > 0;
        }

        public ICollection<TripViewModel> GetAllTrips()
        {
            var trips = context.Trips.Select(x => new TripViewModel
            {
                Id = x.Id,
                StartPoint = x.StartPoint,
                EndPoint = x.EndPoint,
                DepartureTime = x.DepartureTime.ToString(),
                Seats = x.Seats,
            })
                .ToArray();

            return trips;
        }

        public TripViewModel GetTripById(string tripId)
        {
            var trip = context.Trips.FirstOrDefault(x => x.Id == tripId);

            if (trip == null)
            {
                return null;
            }

            TripViewModel tripViewModel = new TripViewModel
            {
                Id = tripId,
                StartPoint = trip.StartPoint,
                EndPoint = trip.EndPoint,
                DepartureTime = trip.DepartureTime.ToString(),
                Description = trip.Description,
                Seats = trip.Seats,
                Path = trip.ImagePath,
            };

            return tripViewModel;
        }

        public bool IsUserInATrip(string userId, string tripId)
        {
            return context.UserTrips.Any(x => x.UserId == userId && x.TripId == tripId);
        }
    }
}
