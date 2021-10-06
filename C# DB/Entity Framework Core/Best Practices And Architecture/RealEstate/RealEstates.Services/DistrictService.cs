namespace RealEstates.Services
{
    using System.Linq;
    using System.Collections.Generic;

    using RealEstates.Data;
    using RealEstates.Services.Dtos;

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

        public IEnumerable<DistrictWithAveragePricePerSquareMeterDto> DistrictWithAveragePricePerSquareMeter()
        {
            var districts = context.Districts
                .Select(x => new DistrictWithAveragePricePerSquareMeterDto
                {
                    DistrictId = x.Id,
                    District = x.Name,
                    AveragePricePerSquareMeter = x.Properties
                        .Where(p => p.Price != 0)
                        .Average(p => (decimal)p.Price / p.Size)
                })
                .ToList();

            return districts;
        }
    }
}