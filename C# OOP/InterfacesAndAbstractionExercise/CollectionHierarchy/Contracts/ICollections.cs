using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Contracts
{
    public interface ICollections : IAdd
    {
        public List<string> Collection { get; }
    }
}
