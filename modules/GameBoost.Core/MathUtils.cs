namespace GameBoost.Core;

/// <summary>
/// Provides utility methods for common mathematical operations in game development.
/// </summary>
public static class MathUtils
{
    /// <summary>
    /// Clamps a value between a minimum and maximum range.
    /// </summary>
    public static float Clamp(float value, float min, float max)
    {
        return Math.Max(min, Math.Min(max, value));
    }

    /// <summary>
    /// Linearly interpolates between two values.
    /// </summary>
    public static float Lerp(float a, float b, float t)
    {
        return a + (b - a) * Clamp(t, 0f, 1f);
    }
}
