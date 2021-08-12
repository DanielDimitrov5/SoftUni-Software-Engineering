using System;
using System.Linq;
using System.Collections.Generic;

using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private List<Item> items;

        public Bag()
        {
            
        }
        public Bag(int capacity)
        {
            Capacity = capacity;
            items = new List<Item>();
            Items = new List<Item>();
        }

        public int Capacity { get; set; } = 100;

        public int Load => Items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items { get; private set; }


        public void AddItem(Item item)
        {
            if (Capacity < Load + item.Weight)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            items.Add(item);
            Items = items;
        }

        public Item GetItem(string name)
        {
            if (!Items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            if (Items.Any(x => x.GetType().Name == name) == false)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            Item item = Items.FirstOrDefault(x => x.GetType().Name == name);

            items.Remove(item);
            Items = items;

            return item;
        }
    }
}