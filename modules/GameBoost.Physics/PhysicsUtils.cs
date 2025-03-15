using GameBoost.Core;


namespace GameBoost.Physics;

/// <summary>
/// Provides utility methods for common physics operations in 2D game development.
/// </summary>
public class PhysicsUtils
{
    private static IMathUtils _utils = new MathUtils();
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
        resultA.Velocity = new Vector2D(b.Velocity.X, a.Velocity.Y, _utils);
        resultB.Velocity = new Vector2D(a.Velocity.X, b.Velocity.Y, _utils);

        return (resultA, resultB);
    }
}
