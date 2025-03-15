using GameBoost.Core;
using GameBoost.Rendering;

namespace PongClone
{
    public class SfmlScreen : IScreen
    {
        private readonly float _width;
        private readonly float _height;
        private readonly IMathUtils _mathUtils;

        public SfmlScreen(float width, float height, IMathUtils mathUtils)
        {
            _width = width;
            _height = height;
            _mathUtils = mathUtils;
        }

        public float Width => _width;
        public float Height => _height;

        public IVector2D ConvertWorldToScreen(IVector2D worldPosition)
        {
            // Scale factors for world grid (40x20) to screen (e.g., 800x600)
            double worldToScreenX = Width / 40f;  // 800 / 40 = 20
            double worldToScreenY = Height / 20f; // 600 / 20 = 30

            // Map X as before
            double screenX = worldPosition.X * worldToScreenX;

            // Invert Y: World Y=0 (bottom) maps to screen Y=Height (bottom), Y=20 (top) maps to screen Y=0 (top)
            double screenY = (20f - worldPosition.Y) * worldToScreenY;

            return new Vector2D(screenX, screenY, _mathUtils);
        }
    }
}
