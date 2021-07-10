using System;
using ExtendedDatabase;
using NUnit.Framework;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase data;

        [SetUp]
        public void Setup()
        {
            data = new ExtendedDatabase.ExtendedDatabase();
        }

        [Test]
        public void AddMethodThrowsAnExceptionWhenCapacityIsExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                data.Add(new Person(i, $"{i}"));
            }

            Assert.Throws<InvalidOperationException>(() => data.Add(new Person(100, "Ivo")));
        }

        [Test]
        public void AddMethodThrowAnExceptionWhenUserNameExists()
        {
            string name = "Ivo";

            data.Add(new Person(1, name));

            Assert.Throws<InvalidOperationException>(() => data.Add(new Person(2, name)));
        }

        [Test]
        public void AddMethodThrowAnExceptionWhenIdExists()
        {
            long id = 666999;

            data.Add(new Person(id, "Ivo"));

            Assert.Throws<InvalidOperationException>(() => data.Add(new Person(id, "Stefan")));
        }

        [Test]
        public void AddMethodIncreasesTheCount()
        {
            var expectedCount = 5;

            for (int i = 0; i < expectedCount; i++)
            {
                data.Add(new Person(i, $"{i}"));
            }
            
            Assert.AreEqual(expectedCount, data.Count);
        }

        [Test]
        public void CtorMethodThrowsAnExceptionWhenCapacityIsExceeded()
        {
            var people = new Person[17];

            Assert.Throws<ArgumentException>(() =>
            {
                var extendedDatabase = new ExtendedDatabase.ExtendedDatabase(people);
            });
        }

        [Test]
        public void CtorSetsCount()
        {
            var people = new Person[10];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"{i}");
            }

            var database = new ExtendedDatabase.ExtendedDatabase(people);

            Assert.IsTrue(people.Length == database.Count);
        }

        [Test]
        public void RemoveMethodThrowAnExceptionWhenCollectionIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => data.Remove());
        }

        [Test]
        public void RemoveMethodDecreasesTheCount()
        {
            var expectedCount = 5;

            for (int i = 0; i < expectedCount; i++)
            {
                data.Add(new Person(i, $"{i}"));
            }

            expectedCount--;
            data.Remove();

            Assert.AreEqual(expectedCount, data.Count);
        }

        [Test]
        public void FindByUsernameMethodThrowsAnExceptionWhenUsernameIsNullOrEmpty()
        {
            string emptyName = string.Empty;

            Assert.Throws<ArgumentNullException>(() => data.FindByUsername(emptyName));
        }

        [Test]
        public void FindUserByUsernameThrowAnExceptionWhenUserIsNotPresentInTheCollection()
        {
            string name = "Stefan";

            Assert.Throws<InvalidOperationException>(() => data.FindByUsername(name));
        }

        [Test]
        public void FindUserByUsernameReturnsUser()
        {
            string name = "Ivo";

            Person person = new Person(0, name);
            data.Add(person);

            Person reference = data.FindByUsername(name);

            Assert.AreSame(person, reference);
        }

        [Test]
        public void FindByIdMethodThrowsAnExceptionWhenUsernameIsNullOrEmpty()
        {
            int invalidId = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() => data.FindById(invalidId));
        }

        [Test]
        public void FindUserByIdThrowAnExceptionWhenUserIsNotPresentInTheCollection()
        {
            int id = 0;

            Assert.Throws<InvalidOperationException>(() => data.FindById(id));
        }

        [Test]
        public void FindUserByIdReturnsUser()
        {
            int id = 0;

            Person person = new Person(id, "Ivo");

            data.Add(person);

            Person reference = data.FindById(id);

            Assert.AreSame(person, reference);
        }
    }
}