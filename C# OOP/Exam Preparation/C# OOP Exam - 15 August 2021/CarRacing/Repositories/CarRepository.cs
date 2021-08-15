using System;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
using CarRacing.Utilities.Messages;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> models;

        public CarRepository()
        {
            models = new List<ICar>();
            Models = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models { get; private set; }

        public void Add(ICar model)
        {
            if (model is null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }

            models.Add(model);
            Models = models;
        }

        public ICar FindBy(string property)
        {
            return Models.FirstOrDefault(x => x.VIN == property);
        }

        public bool Remove(ICar model)
        {
            bool removed = models.Remove(model);

            Models = models;

            return removed;
        }
    }
}