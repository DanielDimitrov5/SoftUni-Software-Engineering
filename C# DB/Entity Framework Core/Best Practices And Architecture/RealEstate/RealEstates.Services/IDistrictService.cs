namespace RealEstates.Services
{
    using System.Collections.Generic;

    using RealEstates.Services.Dtos;

    public interface IDistrictService
    {
        IEnumerable<DistrictDto> DistrictsInfo();

        IEnumerable<DistrictWithAveragePricePerSquareMeterDto> DistrictWithAveragePricePerSquareMeter();
    }
}