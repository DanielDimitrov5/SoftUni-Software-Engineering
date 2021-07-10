using NUnit.Framework;
using System;
using FightingArena;

namespace Tests
{
    public class WarriorTests
    {
        private const int MIN_ATTACK_HP = 30;

        private string name = "Ivo";
        private int damage = 70;
        private int hp = 100;

        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            warrior = new Warrior(name, damage, hp);
        }

        [Test]
        public void CtorSetsPropertiesProperly()
        {
            bool condition = warrior.Name == name && warrior.Damage == damage && warrior.HP == hp;

            Assert.IsTrue(condition);
        }

        [Test]
        public void NameSetterThrowsAnExceptionWhenNameIsNullOrWhiteSpace()
        {
            string emptyName = " ";

            Assert.Throws<ArgumentException>(() => new Warrior(emptyName, damage, hp));
        }

        [Test]
        public void DamageSetterThrowsAnExceptionWhenValueIsZeroOrLess()
        {
            int invalidDamage = 0;

            Assert.Throws<ArgumentException>(() => new Warrior(name, invalidDamage, hp));
        }

        [Test]
        public void HpSetterThrowsAnExceptionWhenValueIsLessThanZero()
        {
            int invalidHP = -1;

            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, invalidHP));
        }

        [Test]
        public void AttackMethodThrowsAnExceptionWhenAttackersHpIsLessThan_MIN_ATTACK_HP()
        {
            Warrior warrior = new Warrior(name, damage, MIN_ATTACK_HP - 1);
            Warrior defender = new Warrior(name, damage, 70);

            Assert.That(() => warrior.Attack(defender),
                Throws.InvalidOperationException.With.Message.EqualTo("Your HP is too low in order to attack other warriors!"));
        }

        [Test]
        public void AttackMethodThrowsAnExceptionWhenDefendersHpIsLessThan_MIN_ATTACK_HP()
        {
            Warrior warrior = new Warrior(name, damage, 70);
            Warrior defender = new Warrior(name, damage, MIN_ATTACK_HP - 1);

            Assert.That(() => warrior.Attack(defender),
                Throws.InvalidOperationException.With.Message.EqualTo($"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!"));
        }

        [Test]
        public void AttackMethodThrowsAnExceptionsWhenAttackerHpIsLessThanTheDefenders()
        {
            Warrior warrior = new Warrior(name, damage, hp);
            Warrior defender = new Warrior(name, hp + 1, hp);

            Assert.That(() => warrior.Attack(defender),
                Throws.InvalidOperationException.With.Message.EqualTo("You are trying to attack too strong enemy"));
        }

        [Test]
        public void AttackMethodReducesAttackerHp()
        {
            Warrior warrior = new Warrior(name, 100, 100);
            Warrior defender = new Warrior(name, 50, 50);

            int expected = 100 - 50;

            warrior.Attack(defender);

            int actual = warrior.HP;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AttackMethodSetsDefendersHpToZeroWhen_AttackersDamageIsGreaterThanDefendersHp()
        {
            Warrior warrior = new Warrior(name, damage, hp);
            Warrior defender = new Warrior(name, damage, damage - 1);

            int expected = 0;

            warrior.Attack(defender);

            int actual = defender.HP;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AttackMethodReducesDefendersHp()
        {
            Warrior warrior = new Warrior(name, damage, hp);
            Warrior defender = new Warrior(name, damage, hp);

            int expected = defender.HP - warrior.Damage;

            warrior.Attack(defender);

            int actual = defender.HP;

            Assert.AreEqual(expected, actual);
        }
    }
}