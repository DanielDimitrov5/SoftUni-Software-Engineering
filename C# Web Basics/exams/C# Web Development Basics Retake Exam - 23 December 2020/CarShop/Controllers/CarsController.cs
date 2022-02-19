using CarShop.Services;
using CarShop.ViewModels;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService carService;
        private readonly IUserService userService;

        public CarsController(ICarService carService, IUserService userService)
        {
            this.carService = carService;
            this.userService = userService;
        }

        public HttpResponse All()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            ICollection<CarViewModel> model = null;

            if (userService.IsMechanic(User.Id))
            {
                model = carService.GetAllCarsForMechanic();
            }
            else
            {
                model = carService.GetAllCarsForClient(User.Id);
            }

            return View(model);
        }

        public HttpResponse Add()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            if (userService.IsMechanic(User.Id))
            {
                return Error("Only clients can add cars!");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Add(AddCarInputModel model)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            if (userService.IsMechanic(User.Id))
            {
                return Error("Only clients can add cars!");
            }

            if (model.Model.Length < 5 || model.Model.Length > 20)
            {
                return Error("Model should be between 5 and 20 characters!");
            }

            if (!Regex.IsMatch(model.PlateNumber, @"^[A-Z]{2}\d{4}[A-Z]{2}$"))
            {
                return Error("Must be a valid Plate number (2 Capital English letters, followed by 4 digits, followed by 2 Capital English letters");
            }

            carService.AddCar(User.Id, model.Model, model.Year, model.Image, model.PlateNumber);

            return Redirect("/");
        }
    }
}
