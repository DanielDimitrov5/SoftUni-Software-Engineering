using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private const int health = 10;
        private const int experience = 10;

        private Dummy dummy;
        private Dummy deadDummy;

        [SetUp]
        public void SetUp()
        {
            dummy = new Dummy(health, experience);
            deadDummy = new Dummy(0, experience);
        }

        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            dummy.TakeAttack(1);

            Assert.AreEqual(dummy.Health, health - 1);
        }

        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            Assert.That(() => deadDummy.TakeAttack(1), 
                Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."),
                "Cannot attack dead dummies");
        }

        [Test]
        public void DeadDummyCanGiveExperience()
        {
            var expectedXp = experience;
            var actualXp = deadDummy.GiveExperience();

            Assert.AreEqual(expectedXp, actualXp,
                "Alive dummy cannot give experience");
        }

        [Test]
        public void AliveDummyCannotGiveExperience()
        {
            Assert.That(() => dummy.GiveExperience(), 
                Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."),
                "Alive dummy cannot give experience");
        }
    }
}