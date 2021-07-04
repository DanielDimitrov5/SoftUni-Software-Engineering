using CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        public List<string> Collection { get; set; }

        public AddRemoveCollection()
        {
            Collection = new List<string>();
        }

        public int Add(string text)
        {
            Collection.Insert(0, text);

            return 0;
        }

        public string Remove()
        {
            string toReturn = Collection[Collection.Count - 1];

            Collection.RemoveAt(Collection.Count - 1);

            return toReturn;
        }
    }
}
