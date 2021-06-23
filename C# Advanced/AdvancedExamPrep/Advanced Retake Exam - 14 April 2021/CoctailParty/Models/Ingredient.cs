using System.Text;

namespace CocktailParty.Models
{
    public class Ingredient
    {
        public Ingredient(string name, int alcohol, int quantity)
        {
            Name = name;
            Alcohol = alcohol;
            Quantity = quantity;
        }

        public string Name { get; set; }
        public int Alcohol { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return new StringBuilder().AppendLine($"Ingredient: {Name}")
                .AppendLine($"Quantity: {Quantity}")
                .Append($"Alcohol: {Alcohol}").ToString().TrimEnd();
        }
    }
}
