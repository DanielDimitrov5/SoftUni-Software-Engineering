using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning.Models
{
    public class Bakery
    {
        private HashSet<Employee> data;

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new HashSet<Employee>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count
        {
            get => data.Count;
        }

        public void Add(Employee employee)
        {
            if (Count < Capacity)
            {
                data.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            if (data.Any(x => x.Name == name))
            {
                data.RemoveWhere(x => x.Name == name);

                return true;
            }

            return false;
        }

        public Employee GetOldestEmployee()
        {
            return data.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public Employee GetEmployee(string name)
        {
            return data.FirstOrDefault(x => x.Name == name);
        }

        public string Report()
        {
            StringBuilder sb =  new StringBuilder();

            sb.AppendLine($"Employees working at Bakery {Name}:");

            foreach (Employee employee in data)
            {
                sb.AppendLine(employee.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
