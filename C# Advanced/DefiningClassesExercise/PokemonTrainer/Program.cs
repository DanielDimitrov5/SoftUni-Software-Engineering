using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                if (!trainers.Any(x => x.Name == trainerName))
                {
                    List<Pokemon> newList = new List<Pokemon>();
                    Trainer newTrainer = new Trainer(trainerName, newList);
                    trainers.Add(newTrainer);
                }

                Trainer trainerToFind = trainers.Where(x => x.Name == trainerName).FirstOrDefault();
                int indexOfTrainer = trainers.IndexOf(trainerToFind);

                Pokemon newPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                trainers[indexOfTrainer].Pokemons.Add(newPokemon);
            }

            string element = string.Empty;

            while ((element = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(x => x.Element == element))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }
                    }
                }

                foreach (var item in trainers)
                {
                    foreach (var pokemon in item.Pokemons)
                    {
                        if (pokemon.Health <= 0)
                        {
                            pokemon.Element = "Dead";
                        }
                    }
                }
            }

            foreach (Trainer trainer in trainers.OrderByDescending(x => x.Badges))
            {
                Console.WriteLine(trainer.ToString());
            }
        }
    }
}
