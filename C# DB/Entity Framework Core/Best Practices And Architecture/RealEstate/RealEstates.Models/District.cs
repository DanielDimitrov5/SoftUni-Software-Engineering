using System.Collections.Generic;

namespace RealEstates.Models
{
    public class District
    {
        public District()
        {
            Properties = new HashSet<Property>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Property> Properties { get; set; }
    }
}