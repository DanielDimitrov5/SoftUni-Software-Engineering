using System;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database data;

        [SetUp]
        public void Setup()
        {
            data = new Database.Database();
        }

        [Test]
        public void AddMethodThrowExceptionWhenCapacityExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                data.Add(i);
            }

            Assert.That(() => data.Add(17),
                Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void AddMethodIncreasesTheCount()
        {
            int expectedCount = 5;

            for (int i = 0; i < expectedCount; i++)
            {
                data.Add(i);
            }

            Assert.AreEqual(expectedCount, data.Count);
        }

        [Test]
        public void RemoveMethodThrowsExceptionWhenCollectionIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => data.Remove());
        }

        [Test]
        public void RemoveMethodRemovesTheLastElementFromTheCollection()
        {
            int elementCount = 10;

            for (int i = 0; i < elementCount - 1; i++)
            {
                data.Add(1);
            }

            int lastElement = 10;

            data.Add(lastElement);

            data.Remove();

            var copy = data.Fetch();

            Assert.IsFalse(copy.Contains(lastElement));
        }

        [Test]
        public void RemoveMethodDecreasesTheCount()
        {
            int elementCount = 10;

            for (int i = 0; i < elementCount; i++)
            {
                data.Add(1);
            }

            var firstCopy = data.Fetch();

            int elementsToRemove = 3;

            for (int i = 0; i < elementsToRemove; i++)
            {
                data.Remove();
            }

            var secondCopy = data.Fetch();

            Assert.AreNotEqual(firstCopy.Length, secondCopy.Length);
        }

        [Test]
        public void FetchReturnsCopyNotReference()
        {
            var copy = data.Fetch();

            data.Add(1);

            Assert.AreNotSame(copy, data.Fetch());
        }
    }
}