using System.Linq;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : Repository<ICar>
    {
        public override ICar GetByName(string name)
        {
            return this.Models.FirstOrDefault(x => x.Model == name);
        }
    }
}