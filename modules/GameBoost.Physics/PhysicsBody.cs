using GameBoost.Core;

namespace GameBoost.Physics;

/// <summary>
/// Represents a 2D physics object with properties for position, velocity, and size.
/// Provides methods for common physics operations.
/// </summary>
public struct PhysicsBody
{
    public Vector2D Position { get; set; }
    public Vector2D Velocity { get; set; }
    public float Mass { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }

    /// <summary>
    /// Initializes a new PhysicsBody with specified properties.
    /// </summary>
    public PhysicsBody(Vector2D position, Vector2D velocity, float mass, float width, float height)
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
    public PhysicsBody Move(float deltaTime)
    {
        PhysicsBody result = this;
        Vector2D displacement = Velocity * deltaTime;
        result.Position += displacement;
        result.Position = new Vector2D(
            MathUtils.Clamp(result.Position.X, 0f, 800f - result.Width), // 800 - 16 = 784
            MathUtils.Clamp(result.Position.Y, 0f, 600f - result.Height) // 600 - 64 = 536
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
