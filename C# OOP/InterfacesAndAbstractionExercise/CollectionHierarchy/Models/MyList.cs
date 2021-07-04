using CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class MyList : IMyList
    {
        public List<string> Collection { get; private set; }

        public int ElementsCount { get; private set; }

        public MyList()
        {
            Collection = new List<string>();
            ElementsCount = Collection.Count;
        }

        public int Add(string text)
        {
            Collection.Insert(0, text);
            return 0;
        }

        public string Remove()
        {
            string toReturn = Collection[0];

            Collection.RemoveAt(0);

            return toReturn;
        }
    }
}
