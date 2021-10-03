using System.Collections.Generic;
using RealEstates.Services.Dtos;

namespace RealEstates.Services
{
    public interface IDistrictService
    {
        IEnumerable<DistrictDto> DistrictsInfo();
    }
}