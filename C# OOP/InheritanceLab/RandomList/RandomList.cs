using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private List<string> list;

        public RandomList()
        {
            this.list = new List<string>();
        }
        public RandomList(IEnumerable<string> list)
        {
            this.list = new List<string>(list);
        }

        public string RandomString()
        {
            Random rnd = new Random();

            int index = rnd.Next(0, list.Count - 1);

            string element = list[index];

            list.RemoveAt(index);

            return element;
        }
        public void AddElement(string element)
        {
            list.Add(element);
        }

    }
}
