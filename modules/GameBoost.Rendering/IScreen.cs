using GameBoost.Core;

namespace GameBoost.Rendering
{
    public interface IScreen
    {
        float Width { get; }
        float Height { get; }
        Vector2D ConvertWorldToScreen(Vector2D worldPosition); // Optional: For coordinate mapping
    }
}
