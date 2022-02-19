using SharedTrip.Models;
using System.Collections.Generic;

namespace SharedTrip.Services
{
    public interface ITripService
    {
        void AddTrip(string startingPoint, string endPoint, string departureTime, string carImage, int seats, string description);

        ICollection<TripViewModel> GetAllTrips();

        TripViewModel GetTripById(string tripId);

        void AddUserToTrip(string userId, string tripId);

        bool AreThereSeatsAvailable(string tripId);

        bool IsUserInATrip(string userId, string tripId);
    }
}
