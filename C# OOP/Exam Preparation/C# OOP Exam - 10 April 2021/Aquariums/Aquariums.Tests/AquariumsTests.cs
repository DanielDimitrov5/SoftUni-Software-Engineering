using NUnit.Framework;

namespace Aquariums.Tests
{
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class AquariumsTests
    {
        private string name = "Aquarium";
        private int capacity = 10;
        private Aquarium aquarium;

        [SetUp]
        public void SetUp()
        {
            aquarium = new Aquarium(name, capacity);
        }

        [Test]
        public void NameGetterReturnsName()
        {
            Assert.AreEqual(name, aquarium.Name);
        }

        [Test]
        public void CapacityGetterReturnsCapacity()
        {
            Assert.AreEqual(capacity, aquarium.Capacity);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void NamePropertyThrowsAnExceptionWhenValueIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(name, 10));
        }

        [Test]
        public void CapacityThrowsAnExceptionWhenValueIsNegative()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium(name, -1));
        }

        [Test]
        public void CountIncreasesWhenAddFish()
        {
            int count = 5;

            for (int i = 0; i < count; i++)
            {
                aquarium.Add(new Fish($"{i}"));
            }

            Assert.AreEqual(count, aquarium.Count);
        }

        [Test]
        public void AddMethodThrowsAnExceptionWhenCapacityIsExceeded()
        {
            for (int i = 0; i < 10; i++)
            {
                aquarium.Add(new Fish($"{i}"));
            }

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("Nemo")));
        }

        [Test]
        public void RemoveFishMethodThrowAnExceptionWhenFishDoesNotExist()
        {
            for (int i = 0; i < 10; i++)
            {
                aquarium.Add(new Fish($"{i}"));
            }

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Ribka"));
        }

        [Test]
        public void RemoveMethodRemovesFishFromAquarium()
        {
            string name = "Ivo";

            aquarium.Add(new Fish(name));

            Assert.That(1, Is.EqualTo(aquarium.Count));

            aquarium.RemoveFish(name);

            Assert.That(0, Is.EqualTo(aquarium.Count));
        }

        [Test]
        public void SellFishMethodThrowsAnExceptionWhenFishDoesNotExist()
        {
            for (int i = 0; i < 10; i++)
            {
                aquarium.Add(new Fish($"{i}"));
            }

            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Petko"));
        }

        [Test]
        public void SellFishSetsFishPropertyAvailableToFalse()
        {
            Fish fish = new Fish("Petko");

            aquarium.Add(fish);

            Assert.IsTrue(fish.Available);

            aquarium.SellFish(fish.Name);

            Assert.IsFalse(fish.Available);
        }

        [Test]
        public void SellFishReturnsFish()
        {
            Fish fish = new Fish("Petko");

            aquarium.Add(fish);

            Fish returnedFish = aquarium.SellFish(fish.Name);

            Assert.AreEqual(returnedFish, fish);
        }

        [Test]
        public void ReportMethodWorks()
        {
            List<string> fishList = new List<string>() {"Ivo", "Petko", "Stefcho"};

            foreach (string fish in fishList)
            {
                aquarium.Add(new Fish(fish));
            }

            string expected = $"Fish available at {aquarium.Name}: {string.Join(", ", fishList)}";

            string actual = aquarium.Report();

            Assert.AreEqual(expected, actual);
        }
    }
}
