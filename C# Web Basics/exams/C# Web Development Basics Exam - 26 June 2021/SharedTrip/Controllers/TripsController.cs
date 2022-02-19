using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Models;
using SharedTrip.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripService tripService;

        public TripsController(ITripService tripService)
        {
            this.tripService = tripService;
        }

        public HttpResponse Add()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Add(AddTripInputModel model)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            if (model.StartPoint == null)
            {
                return Error("Start point should be specified!");
            }

            if (model.EndPoint == null)
            {
                return Error("End point should be specified!");
            }

            if (model.DepartureTime == null)
            {
                return Error("Departure time should be specified!");
            }

            if (!DateTime.TryParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm", new CultureInfo("en-US"), System.Globalization.DateTimeStyles.None, out var date))
            {
                return Error("Departure time should be in format dd.MM.yyyy HH: mm");
            }

            if (model.Seats < 2 || model.Seats > 6)
            {
                return Error("Seats should be between 2 and 6");
            }

            if (model.Description.Length < 1 || model.Description.Length > 80)
            {
                return Error("Description is required!");
            }

            if (model.Description.Length > 80)
            {
                return Error("Description should be up to 80 characters!");
            }

            tripService.AddTrip(model.StartPoint, model.EndPoint, model.DepartureTime, model.ImagePath, model.Seats, model.Description);

            return Redirect("All");
        }

        public HttpResponse All()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            var model = tripService.GetAllTrips();

            return View(model);
        }

        public HttpResponse Details(string tripId)
        {
            var model = tripService.GetTripById(tripId);

            return View(model);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (tripService.IsUserInATrip(User.Id, tripId))
            {
                return Redirect($"Details?tripId={tripId}");
            }

            if (!tripService.AreThereSeatsAvailable(tripId))
            {
                return Error("No seats available for this trip! :(");
            }

            tripService.AddUserToTrip(User.Id, tripId);

            return Redirect("/");
        }
    }
}
