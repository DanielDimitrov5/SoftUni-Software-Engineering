﻿namespace RealEstates.Models
{
    using System.Collections.Generic;

    public class Tag
    {
        public Tag()
        {
            Properties = new HashSet<Property>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Property> Properties { get; set; }
    }
}