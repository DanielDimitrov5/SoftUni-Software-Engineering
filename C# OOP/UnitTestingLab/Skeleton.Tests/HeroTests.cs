using NUnit.Framework;
using Skeleton.Interfaces;

namespace Skeleton.Tests
{
    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void HeroGainsXPWhenTargetDies()
        {
            IWeapon fakeWeapon = new FakeWeapon();

            Hero hero = new Hero("Ivo", fakeWeapon);
            
            ITarget target = new FakeTarget();

            hero.Attack(target);

            Assert.That(hero.Experience, Is.EqualTo(target.GiveExperience()));
        }
    }
}