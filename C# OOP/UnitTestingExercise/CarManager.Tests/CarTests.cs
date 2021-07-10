using System;
using CarManager;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class CarTests
    {
        private readonly string make = "Seat";
        private readonly string model = "Leon";
        private readonly double fuelConsumption = 7;
        private readonly double fuelCapacity = 64;

        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
        }

        [Test]
        public void CtorSetsPropertiesProperly()
        {
            bool condition = car.FuelAmount == 0 && make == car.Make && model == car.Model &&
                             car.FuelConsumption == fuelConsumption && car.FuelCapacity == fuelCapacity;

            Assert.IsTrue(condition);
        }

        [Test]
        public void MakeSetterThrowsAnExceptionWhenValueIsNullOrEmpty()
        {
            string value = string.Empty;

            Assert.Throws<ArgumentException>(() => new Car(value, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void MakeGetterReturnsMakeValue()
        {
            string makeValue = car.Make;

            Assert.IsTrue(make == makeValue);
        }

        [Test]
        public void ModelSetterThrowsAnExceptionWhenValueIsNullOrEmpty()
        {
            string value = string.Empty;

            Assert.Throws<ArgumentException>(() => new Car(make, value, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void ModelGetterReturnsModelValue()
        {
            string modelValue = car.Model;

            Assert.IsTrue(model == modelValue);
        }

        [Test]
        public void FuelConsumptionSetterThrowsAnExceptionWhenValueIsZeroOrLess()
        {
            double value = 0;

            Assert.Throws<ArgumentException>(() => new Car(make, model, value, fuelCapacity));
        }

        [Test]
        public void FuelConsumptionGetterReturnsFuelConsumptionValue()
        {
            double fuelConsumptionValue = car.FuelConsumption;

            Assert.IsTrue(fuelConsumption == fuelConsumptionValue);
        }

        [Test]
        public void FuelCapacitySetterThrowsAnExceptionWhenValueIsLessThanZero()
        {
            double value = -1;

            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, value));
        }

        [Test]
        public void FuelCapacityGetterReturnsFuelCapacityValue()
        {
            double fuelCapacityValue = car.FuelCapacity;

            Assert.IsTrue(fuelCapacity == fuelCapacityValue);
        }

        [Test]
        public void RefuelMethodThrowsAnExceptionWhenTryingToRefuelWithZeroOrNegativeAmount()
        {
            double fuelToRefuel = 0;

            Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel));
        }

        [Test]
        public void RefuelMethodIncreasesFuelAmount()
        {
            double fuelToRefuel = 50;

            car.Refuel(fuelToRefuel);

            Assert.AreEqual(fuelToRefuel, car.FuelAmount);
        }

        [Test]
        public void RefuelMethodDoNotExceedMaxFuelCapacity()
        {
            double fuelToRefuel = 70;

            car.Refuel(fuelToRefuel);

            Assert.AreEqual(fuelCapacity, car.FuelAmount);
        }

        [Test]
        public void DriveMethodThrowsAnExceptionWhenNotEnoughFuel()
        {
            Assert.Throws<InvalidOperationException>(() => car.Drive(100));
        }

        [Test]
        public void DriveMethodDecreasesFuelAmountWhenInvoked()
        {
            Car car = new Car(make, model, 5, 100);

            car.Refuel(100);

            double distance = 20;

            double expectedFuelAmount = car.FuelAmount - ((distance / 100) * car.FuelConsumption);

            car.Drive(distance);

            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }
    }
}
