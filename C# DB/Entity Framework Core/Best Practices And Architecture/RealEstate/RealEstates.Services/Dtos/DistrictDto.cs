namespace RealEstates.Services.Dtos
{
    public class DistrictDto
    {
        public string District { get; set; }

        public int PropertyCount { get; set; }

        public decimal AveragePrice { get; set; }

        public override string ToString()
        {
            return $"{this.District} - Property count: {this.PropertyCount} Average price: {this.AveragePrice:F2}€";
        }
    }
}