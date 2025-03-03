using GameBoost.Core;

namespace GameBoost.Physics.Tests;

[TestFixture]
public class PhysicsUtilsTests
{
    //[SetUp]
    //public void Setup()
    //{
    //}

    [Test]
    public void ResolveCollision_NonColliding_ReturnsUnchanged()
    {
        var body1 = new PhysicsBody(new Vector2D(0f, 0f), new Vector2D(1f, 0f), 1f, 1f, 1f);
        var body2 = new PhysicsBody(new Vector2D(3f, 0f), new Vector2D(-1f, 0f), 1f, 1f, 1f);

        var (result1, result2) = PhysicsUtils.ResolveCollision(body1, body2);

        Assert.That(result1.Velocity.X, Is.EqualTo(1f));
        Assert.That(result2.Velocity.X, Is.EqualTo(-1f));
        Assert.That(result1.Position.X, Is.EqualTo(body1.Position.X));
    }

    [Test]
    public void ResolveCollision_Colliding_SwapsXVelocities()
    {
        var body1 = new PhysicsBody(new Vector2D(0f, 0f), new Vector2D(1f, 2f), 1f, 2f, 2f);
        var body2 = new PhysicsBody(new Vector2D(1f, 0f), new Vector2D(-1f, -2f), 1f, 2f, 2f);

        var (result1, result2) = PhysicsUtils.ResolveCollision(body1, body2);

        Assert.That(result1.Velocity.X, Is.EqualTo(-1f).Within(0.000001));
        Assert.That(result1.Velocity.Y, Is.EqualTo(2f).Within(0.000001));
        Assert.That(result2.Velocity.X, Is.EqualTo(1f).Within(0.000001));
        Assert.That(result2.Velocity.Y, Is.EqualTo(-2f).Within(0.000001));
    }

    [Test]
    public void ResolveCollision_Colliding_PreservesPosition()
    {
        var body1 = new PhysicsBody(new Vector2D(0f, 0f), new Vector2D(1f, 0f), 1f, 2f, 2f);
        var body2 = new PhysicsBody(new Vector2D(1f, 0f), new Vector2D(-1f, 0f), 1f, 2f, 2f);

        var (result1, result2) = PhysicsUtils.ResolveCollision(body1, body2);

        Assert.That(result1.Position.X, Is.EqualTo(0f));
        Assert.That(result2.Position.X, Is.EqualTo(1f));
    }
}
