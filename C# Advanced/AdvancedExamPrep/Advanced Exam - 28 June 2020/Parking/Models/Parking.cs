using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking.Models
{
    public class Parking
    {
        private HashSet<Car> data;

        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            data = new HashSet<Car>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }

        public int Count
        {
            get => data.Count;
        }

        public void Add(Car car)
        {
            if (Count < Capacity)
            {
                data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            return data.Remove(GetCar(manufacturer, model));
        }

        public Car GetLatestCar()
        {
            return data.OrderByDescending(x => x.Year).FirstOrDefault();
        }

        public Car GetCar(string manufacturer, string model)
        {
            return data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {Type}:");

            foreach (Car car in data)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
