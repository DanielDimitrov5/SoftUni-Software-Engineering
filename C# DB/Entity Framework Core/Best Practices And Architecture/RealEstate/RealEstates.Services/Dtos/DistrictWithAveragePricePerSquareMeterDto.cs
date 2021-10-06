namespace RealEstates.Services.Dtos
{
    public class DistrictWithAveragePricePerSquareMeterDto
    {
        public int DistrictId { get; set; }

        public string District { get; set; }

        public decimal AveragePricePerSquareMeter { get; set; }

        public override string ToString()
        {
            return $"Id: {DistrictId}; District: {District}; Price per square m²: €{AveragePricePerSquareMeter:F2}";
        }
    }
}