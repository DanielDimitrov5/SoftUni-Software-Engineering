using CarShop.Data;
using CarShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext context;

        public CarService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void AddCar(string ownerId, string model, int year, string image, string plateNumber)
        {
            Car car = new Car
            {
                Model = model,
                Year = year,
                PictureUrl = image,
                PlateNumber = plateNumber,
                OwnerId = ownerId,
            };

            context.Cars.Add(car);

            context.SaveChanges();
        }

        public ICollection<CarViewModel> GetAllCarsForClient(string ownerId)
        {
            var cars = context.Cars.Where(x => x.OwnerId == ownerId).Select(x => new CarViewModel
            {
                Id = x.Id,
                Model = x.Model,
                Image = x.PictureUrl,
                FixedIssues = x.Issues.Where(x => x.IsFixed).Count(),
                RemainingIssues = x.Issues.Where(x => !x.IsFixed).Count(),
                Plate = x.PlateNumber,
                Year = x.Year,
            })
                .ToArray();

            return cars;
        }

        public ICollection<CarViewModel> GetAllCarsForMechanic()
        {
            var cars = context.Cars.Where(x => x.Issues.Any(x=>!x.IsFixed)).Select(x => new CarViewModel
            {
                Id = x.Id,
                Model = x.Model,
                Image = x.PictureUrl,
                FixedIssues = x.Issues.Where(x => x.IsFixed).Count(),
                RemainingIssues = x.Issues.Where(x => !x.IsFixed).Count(),
                Plate = x.PlateNumber,
                Year = x.Year,
            })
                .ToArray();

            return cars;
        }
    }
}
