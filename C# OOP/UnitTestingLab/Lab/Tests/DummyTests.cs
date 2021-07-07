using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    [Test]
    public void DummyLosesHealthAfterAttack()
    {
        // Arrange
        Dummy dummy = new Dummy(20, 10);

        // Act
        dummy.TakeAttack(5);

        // Assert
        Assert.IsTrue(dummy.Health == 15);
    }
}

