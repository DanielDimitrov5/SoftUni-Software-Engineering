using System;
using System.Linq;
using System.Text;

using System.Collections.Generic;
using AquaShop.Utilities.Messages;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;

        public Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;

            Decorations = new List<IDecoration>();
            Fish = new List<IFish>();
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                name = value;
            }
        }

        public int Capacity { get; }

        public int Comfort => Decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations { get; }

        public ICollection<IFish> Fish { get; private set; }

        public void AddDecoration(IDecoration decoration)
        {
            Decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (Capacity == Fish.Count)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            Fish.Add(fish);
        }

        public void Feed()
        {
            foreach (IFish fish in Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name} ({GetType().Name}):");

            sb.AppendLine($"Fish: {(Fish.Any() ? string.Join(", ", GetFishNames()) : "none")}");

            sb.AppendLine($"Decorations: {Decorations.Count}");
            sb.AppendLine($"Comfort: {Comfort}");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            return Fish.Remove(fish);
        }

        private List<string> GetFishNames()
        {
            List<string> list = new List<string>();

            foreach (var fish in Fish)
            {
                list.Add(fish.Name);
            }

            return list;
        }
    }
}