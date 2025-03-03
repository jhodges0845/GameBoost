using GameBoost.Core;

namespace GameBoost.Physics.Tests;

[TestFixture]
public class PhysicsBodyTests
{
    //[SetUp]
    //public void Setup()
    //{
    //}

    [Test]
    public void Move_UpdatesPositionCorrectly()
    {
        var body = new PhysicsBody(new Vector2D(0f, 0f), new Vector2D(2f, 3f), 1f, 1f, 1f);
        var moved = body.Move(0.5f);

        Assert.That(moved.Position.X, Is.EqualTo(1f).Within(0.000001));
        Assert.That(moved.Position.Y, Is.EqualTo(1.5f).Within(0.000001));
        Assert.That(moved.Velocity.X, Is.EqualTo(2f));
    }

    [Test]
    public void Move_ClampsPositionToBoundaries()
    {
        var body = new PhysicsBody(new Vector2D(0f, 0f), new Vector2D(200f, 300f), 1f, 1f, 1f);
        var moved = body.Move(1f);

        Assert.That(moved.Position.X, Is.EqualTo(100f).Within(0.000001));
        Assert.That(moved.Position.Y, Is.EqualTo(100f).Within(0.000001));
    }

    [Test]
    public void CollidesWith_OverlappingBodies_ReturnsTrue()
    {
        var body1 = new PhysicsBody(new Vector2D(0f, 0f), Vector2D.Zero, 1f, 2f, 2f);
        var body2 = new PhysicsBody(new Vector2D(1f, 1f), Vector2D.Zero, 1f, 2f, 2f);

        Assert.That(body1.CollidesWith(body2), Is.True);
        Assert.That(body2.CollidesWith(body1), Is.True);
    }

    [Test]
    public void CollidesWith_NonOverlappingBodies_ReturnsFalse()
    {
        var body1 = new PhysicsBody(new Vector2D(0f, 0f), Vector2D.Zero, 1f, 1f, 1f);
        var body2 = new PhysicsBody(new Vector2D(2f, 2f), Vector2D.Zero, 1f, 1f, 1f);

        Assert.That(body1.CollidesWith(body2), Is.False);
    }

    [Test]
    public void Constructor_EnsuresNonZeroMass()
    {
        var body = new PhysicsBody(new Vector2D(0f, 0f), Vector2D.Zero, 0f, 1f, 1f);
        Assert.That(body.Mass, Is.EqualTo(1f));
    }
}
