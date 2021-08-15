using NUnit.Framework;

namespace Robots.Tests
{
    using System;

    [TestFixture]
    public class RobotsTests
    {
        private RobotManager robotManager;
        private int capacity = 10;

        [SetUp]
        public void SetUp()
        {
            robotManager = new RobotManager(capacity);
        }

        [Test]
        public void CapacitySetsValue()
        {
            Assert.AreEqual(capacity, robotManager.Capacity);
        }

        [Test]
        public void CapacityThrowsExceptionWhenNegative()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-1));
        }

        [Test]
        public void AddThrowsAnExceptionWhenRobotAlreadyExists()
        {
            Robot robot = new Robot("Gosho", 100);
            Robot sameRobot = new Robot("Gosho", 75);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(sameRobot));
        }

        [Test]
        public void AddThrowsAnExceptionWhenCapacityIsExceeded()
        {
            RobotManager robotManager = new RobotManager(3);

            Robot robot = new Robot("Gosho", 100);
            Robot android = new Robot("Ivo", 75);
            Robot cyborg = new Robot("Razvigor", 16);

            robotManager.Add(robot);
            robotManager.Add(android);
            robotManager.Add(cyborg);

            Robot eRobot = new Robot("Simo", 99);

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(eRobot));
        }

        [Test]
        public void AddAddsRobots()
        {
            int count = 8;

            for (int i = 0; i < count; i++)
            {
                robotManager.Add(new Robot($"{i}", 100));
            }

            Assert.AreEqual(count, robotManager.Count);
        }

        [Test]
        public void RemoveThrowsExceptionWhenRobotDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => robotManager.Remove("non existing robot"));
        }

        [Test]
        public void RemoveMethodRemovesRobots()
        {
            int count = 8;

            for (int i = 0; i < count; i++)
            {
                robotManager.Add(new Robot($"{i}", 100));
            }

            robotManager.Remove("0");

            Assert.AreEqual(7, robotManager.Count);
        }

        [Test]
        public void WorkThrowsExceptionWhenRobotIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => robotManager.Work("Stefan", "teacher", 50));
        }

        [Test]
        public void WorkThrowsAnExceptionWhenNotEnoughBattery()
        {
            Robot robot = new Robot("Ivo", 50);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Work(robot.Name, "teacher", robot.Battery + 1));
        }

        [Test]
        public void WorkDecreasesRobotsBattery()
        {
            Robot robot = new Robot("Ivo", 50);

            robotManager.Add(robot);

            int batteryUsage = 10;

            int battery = robot.Battery - batteryUsage;

            robotManager.Work(robot.Name, "Teacher", batteryUsage);

            Assert.AreEqual(battery, robot.Battery);
        }

        [Test]
        public void ChargeThrowsAnExceptionWhenRobotDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => robotManager.Charge("Stefan"));
        }

        [Test]
        public void ChargeMethodChargesRobot()
        {
            int initialBattery = 100;

            Robot robot = new Robot("Ivo", initialBattery);

            robotManager.Add(robot);

            robotManager.Work(robot.Name, "cleaner", 80);

            robotManager.Charge(robot.Name);

            Assert.AreEqual(initialBattery, robot.Battery);
        }
    }
}
