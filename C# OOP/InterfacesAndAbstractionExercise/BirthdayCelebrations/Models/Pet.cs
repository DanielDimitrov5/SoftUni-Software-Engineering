using BirthdayCelebrations.Contaracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations.Models
{
    public class Pet : IBirth
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }

        public Pet(string name, DateTime birthday)
        {
            Name = name;
            Birthday = birthday;
        }
    }
}
