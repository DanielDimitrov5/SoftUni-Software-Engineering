using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental.Models
{
    public class SkiRental
    {
        private HashSet<Ski> data;

        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new HashSet<Ski>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count
        {
            get => data.Count;
        }

        public void Add(Ski ski)
        {
            if (Count < Capacity)
            {
                data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            return data.Remove(GetSki(manufacturer, model));
        }

        public Ski GetNewestSki()
        {
            return data.OrderByDescending(x => x.Year).FirstOrDefault();
        }

        public Ski GetSki(string manufacturer, string model)
        {
            return data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {Name}:");

            foreach (Ski ski in data)
            {
                sb.AppendLine(ski.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
