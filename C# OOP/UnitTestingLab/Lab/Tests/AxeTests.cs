using System;
using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private const int AxeAttack = 2;
    private const int AxeDurability = 2;
    private const int DummyHealth = 20;
    private const int DummyXp = 20;

    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void TestInit()
    {
        this.axe = new Axe(AxeAttack, AxeDurability);
        this.dummy = new Dummy(DummyHealth, DummyXp);
    }

    [Test]
    public void AxeLosesDurabilyAfterAttack()
    {
        Axe axe = new Axe(10, 10);
        Dummy dummy = new Dummy(10, 10);
        
        axe.Attack(dummy);
        
        Assert.AreEqual(1, axe.DurabilityPoints, "Axe Durability doesn't change after attack");
    }

    [Test]
    public void BrokenAxeCantAttack()
    {
        // Act
        axe.Attack(dummy);
        axe.Attack(dummy);

        // Assert
        var ex = Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        Assert.That(ex.Message, Is.EqualTo("Axe is broken."));
    }
}