using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name, List<Pokemon> pokemons)
        {
            Name = name;
            Pokemons = pokemons;
            Badges = 0;
        }

        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public override string ToString()
        {
            return $"{Name} {Badges} {Pokemons.Where(x => x.Health > 0).Count()}";
        }
    }
}
