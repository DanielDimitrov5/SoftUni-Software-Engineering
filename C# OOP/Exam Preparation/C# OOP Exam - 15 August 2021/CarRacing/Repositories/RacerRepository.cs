using System;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
using CarRacing.Utilities.Messages;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private List<IRacer> models;

        public RacerRepository()
        {
            models = new List<IRacer>();
            Models = new List<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models { get; private set; }

        public void Add(IRacer model)
        {
            if (model is null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }

            models.Add(model);
            Models = models;
        }

        public IRacer FindBy(string property)
        {
            return Models.FirstOrDefault(x => x.Username == property);
        }

        public bool Remove(IRacer model)
        {
            bool removed = models.Remove(model);

            Models = models;

            return removed;
        }
    }
}