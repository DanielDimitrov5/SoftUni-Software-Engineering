using CollectionHierarchy.Contracts;
using CollectionHierarchy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Core
{
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            AddCollections(addCollection, input);
            AddCollections(addRemoveCollection, input);
            AddCollections(myList, input);

            int removeOperationsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < removeOperationsCount; i++)
            {
                Console.Write($"{addRemoveCollection.Remove()} ");
            }
            Console.WriteLine();

            for (int i = 0; i < removeOperationsCount; i++)
            {
                Console.Write($"{myList.Remove()} ");
            }
            Console.WriteLine();
        }

        private void AddCollections(ICollections collections, string[] input)
        {
            foreach (var item in input)
            {
                Console.Write($"{collections.Add(item)} ");
            }
            Console.WriteLine();
        }
    }
}
