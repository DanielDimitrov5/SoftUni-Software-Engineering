using System;
using System.Collections.Generic;
using System.Linq;
using FightingArena;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
        }

        [Test]
        public void CtorWorks()
        {
            Arena arena = new Arena();

            Assert.That(arena.Warriors is List<Warrior>);
        }

        [Test]
        public void CtorInitializesCollectionOfWarriors()
        {
            Assert.That(arena.Warriors, Is.Not.Null);
        }

        [Test]
        public void CountMethodReturnsWarriorsCount()
        {
            Assert.AreEqual(0, arena.Warriors.Count);
            Assert.AreEqual(0, arena.Count);

            int count = 3;

            for (int i = 0; i < count; i++)
            {
                arena.Enroll(new Warrior($"{i}", i + 1, i + 1));
            }

            Assert.AreEqual(count, arena.Count);
            Assert.AreEqual(arena.Warriors.Count, arena.Count);
        }

        [Test]
        public void EnrollMethodThrowsAnExceptionWhenWarriorsNameIsPresentInTheArena()
        {
            string name = "Ivo";

            Warrior warrior = new Warrior(name, 100, 100);
            arena.Enroll(warrior);

            Warrior sameNameWarrior = new Warrior(name, 50, 50);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(sameNameWarrior));
        }

        [Test]
        public void EnrollMethodAddsWarriorsToTheArena()
        {
            Warrior warrior = new Warrior("Ivo", 100, 100);
            arena.Enroll(warrior);

            Assert.IsTrue(arena.Warriors.Any(x => x.Name == "Ivo"));
        }

        [Test]
        public void FightMethodThrowsAnExceptionWhenAttackerIsNull()
        {
            string attackerName = "Ivo";
            string defenderName = "Gosho";

            Warrior defender = new Warrior(defenderName, 100, 100);
            arena.Enroll(defender);

            Assert.That(() => arena.Fight(attackerName, defenderName),
                Throws.InvalidOperationException.With.Message.EqualTo($"There is no fighter with name {attackerName} enrolled for the fights!"));
        }

        [Test]
        public void FightMethodThrowsAnExceptionWhenDefenderIsNull()
        {
            string attackerName = "Ivo";
            string defenderName = "Gosho";

            Warrior attacker = new Warrior(attackerName, 100, 100);
            arena.Enroll(attacker);

            Assert.That(() => arena.Fight(attackerName, defenderName),
                Throws.InvalidOperationException.With.Message.EqualTo($"There is no fighter with name {defenderName} enrolled for the fights!"));
        }

        [Test]
        public void FightMethodThrowsAnExceptionWhenBothAreNull()
        {
            string attackerName = "Ivo";
            string defenderName = "Gosho";

            Assert.That(() => arena.Fight(attackerName, defenderName),
                Throws.InvalidOperationException.With.Message.EqualTo($"There is no fighter with name {defenderName} enrolled for the fights!"));
        }


        [Test]
        public void FightMethodWorksProperly()
        {
            Warrior attacker = new Warrior("Ivo", 50, 100);
            Warrior defender = new Warrior("Gosho", 50, 100);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            var attackerExpectedHp = attacker.HP - defender.Damage;
            var defenderExpectedHp = defender.HP - attacker.Damage;
            
            arena.Fight("Ivo", "Gosho");

            Assert.AreEqual(attackerExpectedHp, attacker.HP);
            Assert.AreEqual(defenderExpectedHp, defender.HP);
        }
    }
}
