using System;
using System.Collections.Generic;
using NUnit.Framework;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        private UnitDriver driver = new UnitDriver("Driver Ivo", new UnitCar("e60", 350, 3000));

        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
        }

        [Test]
        public void CounterWorks()
        {
            int count = 5;

            for (int i = 0; i < count; i++)
            {
                raceEntry.AddDriver(new UnitDriver($"{i}", new UnitCar($"{i}", i + 100, i + 100)));
            }

            Assert.AreEqual(count, raceEntry.Counter);
        }

        [Test]
        public void AddDriverMethodThrowsAnExceptionWhenDriverIsNull()
        {
            UnitDriver nullDriver = null;

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(nullDriver));
        }

        [Test]
        public void AddDriverMethodThrowAnExceptionWhenDriverIsPresentInTheCollection()
        {
            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(driver));
        }

        [Test]
        public void AddMethodReturnsProperMessage()
        {
            string expected = $"Driver {driver.Name} added in race.";

            string actual = raceEntry.AddDriver(driver);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateAverageHorsePowerThrowAnExceptionWhenNotEnoughParticipants()
        {
            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePowerReturnsAverageHorsePower()
        {
            int totalHorsePower = 0;

            for (int i = 0; i < 100; i++)
            {
                raceEntry.AddDriver(new UnitDriver($"{i}", new UnitCar($"{i}", i + 100, i + 100)));
                totalHorsePower += i + 100;
            }

            double expected = totalHorsePower * 1.0 / raceEntry.Counter;

            double actual = raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(expected, actual);
        }
    }
}
