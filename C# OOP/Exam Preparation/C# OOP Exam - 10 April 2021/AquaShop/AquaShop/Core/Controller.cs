using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using AquaShop.Models.Fish;
using AquaShop.Repositories;
using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Decorations;
using AquaShop.Utilities.Messages;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private ICollection<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;

            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            aquariums.Add(aquarium);

            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;

            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            decorations.Add(decoration);

            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            bool successfullyAdded = false;

            IAquarium aquarium = aquariums.First(x => x.Name == aquariumName);

            IFish fish = null;

            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            if (fish.GetType().Name == "FreshwaterFish" && aquarium.GetType().Name == "FreshwaterAquarium")
            {
                successfullyAdded = true;
            }
            else if (fish.GetType().Name == "SaltwaterFish" && aquarium.GetType().Name == "SaltwaterAquarium")
            {
                successfullyAdded = true;
            }

            if (successfullyAdded)
            {
                aquarium.AddFish(fish);
            }

            return successfullyAdded
                ? string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName)
                : OutputMessages.UnsuitableWater;
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = aquariums.First(x => x.Name == aquariumName);

            decimal value = aquarium.Fish.Sum(x => x.Price) + aquarium.Decorations.Sum(x => x.Price);

            return $"The value of Aquarium {aquariumName} is {value:F2}.";
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = aquariums.First(x => x.Name == aquariumName);

            aquarium.Feed();

            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IAquarium aquarium = aquariums.First(x => x.Name == aquariumName);

            IDecoration decoration = decorations.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            aquarium.AddDecoration(decoration);

            decorations.Remove(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}