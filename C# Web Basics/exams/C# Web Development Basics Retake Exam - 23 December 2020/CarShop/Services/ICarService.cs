using CarShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services
{
    public interface ICarService
    {
        void AddCar(string ownerId, string model, int year, string image, string plateNumber);

        ICollection<CarViewModel> GetAllCarsForClient(string ownerId); 

        ICollection<CarViewModel> GetAllCarsForMechanic();
    }
}
