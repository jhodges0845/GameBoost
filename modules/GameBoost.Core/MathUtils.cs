namespace GameBoost.Core;

/// <summary>
/// Provides utility methods for common mathematical operations in game development.
/// </summary>
public class MathUtils : IMathUtils
{

    public double Sin(double angle) => System.Math.Sin(angle);
    public double Cos(double angle) => System.Math.Cos(angle);
    public double Tan(double angle) => System.Math.Tan(angle);
    public double Sqrt(double value) => System.Math.Sqrt(value);
    public double Abs(double value) => System.Math.Abs(value);
    public double Min(double a, double b) => System.Math.Min(a, b);
    public double Max(double a, double b) => System.Math.Max(a, b);
    /// <summary>
    /// Clamps a value between a minimum and maximum range.
    /// </summary>
    public double Clamp(double value, double min, double max) => System.Math.Clamp(value, min, max);
    /// <summary>
    /// Linearly interpolates between two values.
    /// </summary>
    public double Lerp(double a, double b, double t) => a + (b - a) * Clamp(t, 0f, 1f);
    public double Round(double value) => System.Math.Round(value);

}
