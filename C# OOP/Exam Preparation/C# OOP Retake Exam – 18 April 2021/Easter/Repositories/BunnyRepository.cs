using System.Linq;
using System.Collections.Generic;

using Easter.Repositories.Contracts;
using Easter.Models.Bunnies.Contracts;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private List<IBunny> bunnies;

        public BunnyRepository()
        {
            bunnies = new List<IBunny>();
        }

        public IReadOnlyCollection<IBunny> Models { get; private set; } = new List<IBunny>();

        public void Add(IBunny model)
        {
            bunnies.Add(model);

            Models = bunnies;
        }

        public IBunny FindByName(string name)
        {
            return bunnies.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IBunny model)
        {
            if (bunnies.Contains(model))
            {
                bunnies.Remove(model);

                Models = bunnies;

                return true;
            }

            return false;
        }
    }
}