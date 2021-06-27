using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic.Models
{
    public class Clinic
    {
        private HashSet<Pet> data;

        public int Capacity { get; set; }

        public Clinic(int capacity)
        {
            Capacity = capacity;
            data = new HashSet<Pet>(Capacity);
        }

        public int Count
        {
            get => data.Count;
        }

        public void Add(Pet pet)
        {
            if (Count < Capacity)
            {
                data.Add(pet);
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

        public Pet GetPet(string name, string owner)
        {
            return data.FirstOrDefault(x => x.Name == name && x.Owner == owner);
        }

        public Pet GetOldestPet()
        {
            return data.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("The clinic has the following patients:");

            foreach (Pet pet in data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
