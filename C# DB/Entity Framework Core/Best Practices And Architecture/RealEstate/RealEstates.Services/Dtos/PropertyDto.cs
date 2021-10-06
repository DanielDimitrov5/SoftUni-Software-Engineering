namespace RealEstates.Services.Dtos
{
    public class PropertyDto
    {
        public string DistrictName { get; set; }

        public int Size { get; set; }

        public int Price { get; set; }

        public string PropertyType { get; set; }

        public string BuildingType { get; set; }

        public override string ToString()
        {
            return
                $"{DistrictName}: Price: {Price}€ -> Size: {Size}, Property type: {PropertyType}, Property building type: {BuildingType}";
        }
    }
}