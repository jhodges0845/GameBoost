using GameBoost.Core;

namespace GameBoost.Rendering
{
    public interface IScreen
    {
        float Width { get; }
        float Height { get; }
        IVector2D ConvertWorldToScreen(IVector2D worldPosition); // Optional: For coordinate mapping
    }
}
