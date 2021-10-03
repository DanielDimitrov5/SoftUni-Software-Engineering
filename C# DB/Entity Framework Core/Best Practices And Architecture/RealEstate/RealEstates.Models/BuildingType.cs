using System.Collections.Generic;

namespace RealEstates.Models
{
    public class BuildingType
    {
        public BuildingType()
        {
            Properties = new HashSet<Property>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Property> Properties { get; set; }
    }
}