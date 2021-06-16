using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        public List<IPrivate> Privates { get; }

        public void AddPrivate(IPrivate @private);
    }
}
