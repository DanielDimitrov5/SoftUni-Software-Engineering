using System;
using System.Collections.Generic;
using System.Linq;

namespace OldestFamilyMember
{
    public class Family
    {
        public Family()
        {
            People = new List<Person>();
        }

        public List<Person> People { get; set; }

        public void AddMember(Person person)
        {
            People.Add(person);
        }

        public Person GetOldestMember()
        {
            Person oldest = People.OrderByDescending(x => x.Age).FirstOrDefault();

            return oldest;
        }
    }
}
