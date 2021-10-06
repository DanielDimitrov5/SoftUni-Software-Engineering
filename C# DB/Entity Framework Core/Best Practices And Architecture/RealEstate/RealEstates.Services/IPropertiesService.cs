namespace RealEstates.Services
{
    using System.Collections.Generic;

    using RealEstates.Services.Dtos;

    public interface IPropertiesService
    {
        void Add(string district, int price,
            int floor, int maxFloor, int size, int yardSize,
            int year, string propertyType, string buildingType);

        IEnumerable<PropertyDto> Search(int minPrice, int maxPrice, int minSize, int maxSize);

        IEnumerable<PropertyDto> TagFilter(string tags);
    }
}