using GameBoost.Core;


namespace GameBoost.Physics;

/// <summary>
/// Provides utility methods for common physics operations in 2D game development.
/// </summary>
public static class PhysicsUtils
{
    /// <summary>
    /// Resolves a simple elastic collision between two bodies along the X-axis.
    /// Assumes equal mass for simplicity; use with caution in complex scenarios.
    /// </summary>
    public static (PhysicsBody, PhysicsBody) ResolveCollision(PhysicsBody a, PhysicsBody b)
    {
        if (!a.CollidesWith(b)) return (a, b);

        // Swap velocities (elastic collision approximation)
        PhysicsBody resultA = a;
        PhysicsBody resultB = b;
        resultA.Velocity = new Vector2D(b.Velocity.X, a.Velocity.Y);
        resultB.Velocity = new Vector2D(a.Velocity.X, b.Velocity.Y);

        return (resultA, resultB);
    }
}
