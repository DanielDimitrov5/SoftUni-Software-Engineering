using RealEstates.Services.Dtos;
using System.Collections.Generic;
using System.Linq;
using RealEstates.Data;

namespace RealEstates.Services
{
    public class DistrictService : IDistrictService
    {
        private readonly RealEstateContext context;

        public DistrictService(RealEstateContext context)
        {
            this.context = context;
        }

        public IEnumerable<DistrictDto> DistrictsInfo()
        {
            var districts = context.Districts
                .Select(x => new DistrictDto
                {
                    District = x.Name,
                    PropertyCount = x.Properties.Count,
                    AveragePrice = (decimal)x.Properties.Average(p => p.Price)
                })
                .ToList();

            return districts;
        }
    }
}