﻿namespace GameBoost.Core;

/// <summary>
/// Represents a 2D vector with X and Y components.
/// Useful for positions, velocities, and directions in game development.
/// </summary>
public struct Vector2D
{
    public float X { get; set; }
    public float Y { get; set; }
    public static Vector2D Zero => new Vector2D(0f, 0f);
    public Vector2D(float x, float y)
    {
        X = x;
        Y = y;
    }

    public static Vector2D operator +(Vector2D a, Vector2D b) => new(a.X + b.X, a.Y + b.Y);
    public static Vector2D operator -(Vector2D a, Vector2D b) => new(a.X - b.X, a.Y - b.Y);
    public static Vector2D operator *(Vector2D a, float scalar) => new(a.X * scalar, a.Y * scalar);
    public static Vector2D operator *(float scalar ,Vector2D a) => new(a.X * scalar, a.Y * scalar);

    public static Vector2D operator /(Vector2D a, float scalar)
    {
        if (scalar == 0f) throw new DivideByZeroException("Cannot divide Vector2D by zero.");
        return new Vector2D(a.X / scalar, a.Y / scalar);
    }

    public float Magnitude() => (float)Math.Sqrt(X * X + Y * Y);
    public Vector2D Normalized()
    {
        float mag = Magnitude();
        return mag > 0 ? new Vector2D(X / mag, Y / mag) : this;
    }
    public static float Dot(Vector2D a, Vector2D b)
    {
        return a.X * b.X + a.Y * b.Y;
    }
}
