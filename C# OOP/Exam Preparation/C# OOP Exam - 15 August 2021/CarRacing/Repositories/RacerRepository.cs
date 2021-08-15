using System;
using System.Linq;

using System.Collections.Generic;
using CarRacing.Utilities.Messages;
using CarRacing.Repositories.Contracts;
using CarRacing.Models.Racers.Contracts;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private List<IRacer> models;

        public RacerRepository()
        {
            models = new List<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models => new List<IRacer>(models);

        public void Add(IRacer model)
        {
            if (model is null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }

            models.Add(model);
        }

        public IRacer FindBy(string property)
        {
            return Models.FirstOrDefault(x => x.Username == property);
        }

        public bool Remove(IRacer model)
        {
            bool removed = models.Remove(model);

            return removed;
        }
    }
}