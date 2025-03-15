using GameBoost.Core;

namespace GameBoost.Physics;

/// <summary>
/// Represents a 2D physics object with properties for position, velocity, and size.
/// Provides methods for common physics operations.
/// </summary>
public struct PhysicsBody
{
    public IVector2D Position { get; set; }
    public IVector2D Velocity { get; set; }
    public float Mass { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }

    /// <summary>
    /// Initializes a new PhysicsBody with specified properties.
    /// </summary>
    public PhysicsBody(IVector2D position, IVector2D velocity, float mass, float width, float height)
    {
        Position = position;
        Velocity = velocity;
        Mass = mass > 0 ? mass : 1f;
        Width = width;
        Height = height;
    }

    /// <summary>
    /// Applies a velocity update based on time elapsed, including gravity.
    /// </summary>
    public PhysicsBody Move(double deltaTime, double minX, double maxX, double minY, double maxY)
    {
        PhysicsBody result = this;
        var utils = new MathUtils();
        IVector2D displacement = Velocity.Multiply( deltaTime);
        result.Position = result.Position.Add(displacement);
        result.Position = new Vector2D(
            utils.Clamp(result.Position.X, minX, maxX - result.Width), // 800 - 16 = 784
            utils.Clamp(result.Position.Y, minY, maxY - result.Height) // 600 - 64 = 536
            , utils
        );
        return result;
    }

    /// <summary>
    /// Checks for collision with another PhysicsBody using AABB.
    /// </summary>
    public bool CollidesWith(PhysicsBody other)
    {
        return Position.X < other.Position.X + other.Width &&
               Position.X + Width > other.Position.X &&
               Position.Y < other.Position.Y + other.Height &&
               Position.Y + Height > other.Position.Y;
    }
}
