namespace GameBoost.Core
{
    public interface IVector2D
    {
        double X { get; set; }
        double Y { get; set; }

        // Basic operations
        //IVector2D operator +(IVector2D a, IVector2D b);

        IVector2D Add(IVector2D other);
        IVector2D Subtract(IVector2D other);
        IVector2D Multiply(double scalar);
        IVector2D Divide(double scalar);
        IVector2D Zero();

        // Magnitude and normalization
        double Magnitude();
        IVector2D Normalize();

        // Dot product
        double Dot(IVector2D other);

        // Equality check
        bool Equals(IVector2D other);
    }
}
