using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    public interface IEngineer : ISpecialisedSoldier
    {
        public List<IRepair> Repairs { get; }

        public void AddRepair(IRepair repair);
    }
}
