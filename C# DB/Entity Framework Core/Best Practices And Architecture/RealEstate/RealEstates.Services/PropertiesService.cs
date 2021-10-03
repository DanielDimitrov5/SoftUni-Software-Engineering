using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services.Dtos;

namespace RealEstates.Services
{
    public class PropertiesService : IPropertiesService
    {
        private readonly RealEstateContext context;

        public PropertiesService(RealEstateContext context)
        {
            this.context = context;
        }

        public void Add(
            string district, int price, int floor, int maxFloor, int size, int yardSize, int year, string propertyType, string buildingType)
        {
            Property property = new Property
            {
                Size = size,
                Price = price,
                Floor = (byte)floor,
                TotalFloors = (byte)maxFloor,
                YardSize = yardSize,
                BuildingYear = year
            };


            District dbDistrict = context.Districts.FirstOrDefault(x => x.Name == district);

            if (dbDistrict is null)
            {
                dbDistrict = new District { Name = district };
            }

            property.District = dbDistrict;

            PropertyType dbPropertyType = context.PropertyTypes.FirstOrDefault(x => x.Name == propertyType);

            if (dbPropertyType is null)
            {
                dbPropertyType = new PropertyType { Name = propertyType };
            }

            property.PropertyType = dbPropertyType;

            BuildingType dbBuildingType = context.BuildingTypes.FirstOrDefault(x => x.Name == buildingType);

            if (dbBuildingType is null)
            {
                dbBuildingType = new BuildingType { Name = buildingType };
            }

            property.BuildingType = dbBuildingType;

            context.Properties.Add(property);

            context.SaveChanges();
        }

        public IEnumerable<PropertyDto> Search(int minPrice, int maxPrice, int minSize, int maxSize)
        {
            var properties = context.Properties
                .Where(x => x.Price >= minPrice && x.Price <= maxPrice && x.Size >= minSize && x.Size <= maxSize)
                .Select(x => new PropertyDto
                {
                    Price = x.Price,
                    Size = x.Size,
                    PropertyType = x.PropertyType.Name,
                    BuildingType = x.BuildingType.Name,
                    DistrictName = x.District.Name
                })
                .ToList();

            return properties;
        }
    }
}