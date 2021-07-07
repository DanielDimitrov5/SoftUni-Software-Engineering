using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private readonly int attack = 10;
        private readonly int durability = 10;
        private Axe axe;

        private readonly int health = 50;
        private readonly int experience = 50;
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            axe = new Axe(attack, durability);
            dummy = new Dummy(health, experience);
        }

        [Test]
        public void WeaponLoseDurabilityAfterEachAttack()
        {
            axe.Attack(dummy);

            Assert.AreEqual(axe.DurabilityPoints, durability - 1, "Axe durability doesn't change after attack!");
        }

        [Test]
        public void CannotAttackWithABrokenWeapon()
        {
            Axe broken = new Axe(1, -1);

            Assert.That(() =>
            {
                broken.Attack(dummy);
            }, Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."),
                "Broken weapon does not throw an exception when attack method is being attack!");
        }
    }
}
