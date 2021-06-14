using System;

using BirthdayCelebrations.Contaracts;

namespace BirthdayCelebrations.Models
{
    public class Citizen : IIdentifiable, IBirth
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }
        public DateTime Birthday { get; set; }

        public Citizen(string name, int age, string id, DateTime birthday)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthday = birthday;
        }
    }
}
