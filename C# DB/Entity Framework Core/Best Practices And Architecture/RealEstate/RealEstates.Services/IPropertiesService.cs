using System.Collections.Generic;
using RealEstates.Models;
using RealEstates.Services.Dtos;

namespace RealEstates.Services
{
    public interface IPropertiesService
    {
        void Add(string district, int price,
            int floor, int maxFloor, int size, int yardSize,
            int year, string propertyType, string buildingType);

        IEnumerable<PropertyDto> Search(int minPrice, int maxPrice, int minSize, int maxSize);
    }
}