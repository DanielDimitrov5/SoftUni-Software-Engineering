using System;
using System.Collections.Generic;

namespace Presents.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class PresentsTests
    {
        private Bag bag;

        [SetUp]
        public void SetUp()
        {
            bag = new Bag();
        }

        [Test]
        public void CtorInitializesCollectionOfPresents()
        {
            Assert.That(bag, Is.Not.Null);
        }

        [Test]
        public void CreateThrowsAnExceptionWhenPresetIsNull()
        {
            Present nullPresent = null;

            Assert.Throws<ArgumentNullException>(() => bag.Create(nullPresent));
        }

        [Test]
        public void CreateThrowsAnExceptionWhenPresentIsAlreadyInTheBag()
        {
            Present present = new Present("Truck", 69);

            bag.Create(present);

            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }

        [Test]
        public void CreateAddsPresentsInTheBag()
        {
            Present present = new Present("Truck", 69);

            bag.Create(present);

            Assert.That(present, Is.EqualTo(bag.GetPresent(present.Name)));
        }

        [Test]
        public void CreateReturnsProperMessage()
        {
            Present present = new Present("Truck", 69);

            string expectedMsg = $"Successfully added present {present.Name}.";

            string actual = bag.Create(present);

            Assert.That(expectedMsg, Is.EqualTo(actual));
        }

        [Test]
        public void RemoveMethodRemovesPresentsFromTheBag()
        {
            Present present = new Present("Truck", 69);

            bag.Create(present);

            bag.Remove(present);

            Assert.That(bag.GetPresent(present.Name), Is.Null);
        }

        [Test]
        public void RemoveReturnsBoolean()
        {
            Present present = new Present("Truck", 69);

            Assert.IsFalse(bag.Remove(present));

            bag.Create(present);

            Assert.IsTrue(bag.Remove(present));
        }

        [Test]
        public void GetPresentWithLeastMagicWorks()
        {
            Present truck = new Present("Truck", 69);
            Present bus = new Present("Bus", 100);
            Present leastMagic = new Present("No Magic", 1);

            bag.Create(truck);
            bag.Create(bus);
            bag.Create(leastMagic);

            Assert.That(leastMagic, Is.EqualTo(bag.GetPresentWithLeastMagic()));
        }

        [Test]
        public void GetPresentReturnPresent()
        {
            Present truck = new Present("Truck", 69);
            Present bus = new Present("Bus", 100);

            bag.Create(truck);
            bag.Create(bus);

            Present expectedPresent = bus; 
            Present actualPresent = bag.GetPresent(bus.Name);

            Assert.AreEqual(expectedPresent, actualPresent);
        }

        [Test]
        public void GetPresentsReturnsBagAsReadOnlyCollection()
        {
            Assert.That(bag.GetPresents(), Is.InstanceOf<IReadOnlyCollection<Present>>());
        }
    }
}
