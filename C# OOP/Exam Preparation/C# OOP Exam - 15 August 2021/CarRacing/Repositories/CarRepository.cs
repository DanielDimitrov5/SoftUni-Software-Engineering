using System;
using System.Linq;
using System.Collections.Generic;

using CarRacing.Utilities.Messages;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> models;

        public CarRepository()
        {
            models = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models => new List<ICar>(models);

        public void Add(ICar model)
        {
            if (model is null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }

            models.Add(model);
        }

        public ICar FindBy(string property)
        {
            return Models.FirstOrDefault(x => x.VIN == property);
        }

        public bool Remove(ICar model)
        {
            bool removed = models.Remove(model);

            return removed;
        }
    }
}