namespace GameBoost.Core;

/// <summary>
/// Represents a 2D vector with X and Y components.
/// Useful for positions, velocities, and directions in game development.
/// </summary>
public struct Vector2D : IVector2D
{
    private readonly IMathUtils _math;
    public double X { get; set; }
    public double Y { get; set; }

    public Vector2D(double x, double y, IMathUtils math)
    {
        X = x;
        Y = y;
        _math = math;
    }

    public IVector2D Add(IVector2D other)
    {
        return new Vector2D(X + other.X, Y + other.Y, _math);
    }

    public IVector2D Subtract(IVector2D other)
    {
        return new Vector2D(X - other.X, Y - other.Y, _math);
    }

    public IVector2D Multiply(double scalar)
    {
        return new Vector2D(X * scalar, Y * scalar, _math);
    }

    public IVector2D Divide(double scalar)
    {
        if (scalar == 0) throw new System.DivideByZeroException();
        return new Vector2D(X / scalar, Y / scalar, _math);
    }
    public IVector2D Zero()
    {
        return new Vector2D(0, 0, _math);
    }

    public double Magnitude()
    {
        return _math.Sqrt(X * X + Y * Y);
    }

    public IVector2D Normalize()
    {
        double mag = Magnitude();
        if (mag == 0) return new Vector2D(0, 0, _math);
        return Divide(mag);
    }

    public double Dot(IVector2D other)
    {
        return X * other.X + Y * other.Y;
    }

    public bool Equals(IVector2D other)
    {
        if (other == null) return false;
        return X == other.X && Y == other.Y;
    }


}
