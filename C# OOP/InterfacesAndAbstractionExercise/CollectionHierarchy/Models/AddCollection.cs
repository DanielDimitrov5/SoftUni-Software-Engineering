using CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class AddCollection : IAddCollection
    {
        public List<string> Collection { get; set; }

        public AddCollection()
        {
            Collection = new List<string>();
        }

        public int Add(string text)
        {
            Collection.Add(text);

            return Collection.Count - 1;
        }
    }
}
