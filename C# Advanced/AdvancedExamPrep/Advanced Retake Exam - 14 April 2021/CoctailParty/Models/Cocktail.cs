using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty.Models
{
    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new HashSet<Ingredient>();
        }

        public int CurrentAlcoholLevel
        {
            get
            {
                return Ingredients.Sum(x => x.Alcohol);
            }
        }

        public HashSet<Ingredient> Ingredients { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }

        public void Add(Ingredient ingredient)
        {
            if (Capacity > 0 && MaxAlcoholLevel >= ingredient.Alcohol && !Ingredients.Any(x => x.Name == Name))
            {
                Capacity--;
                MaxAlcoholLevel -= ingredient.Alcohol;

                Ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            if (Ingredients.Any(x => x.Name == name))
            {
                Capacity++;
                MaxAlcoholLevel += Ingredients.First(x => x.Name == name).Alcohol;

                Ingredients.RemoveWhere(x => x.Name == name);

                return true;
            }

            return false;
        }

        public Ingredient FindIngredient(string name)
        {
            return Ingredients.FirstOrDefault(x => x.Name == name);
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return Ingredients.OrderByDescending(x => x.Alcohol).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var ingredient in Ingredients)
            {
                sb.AppendLine(ingredient.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
