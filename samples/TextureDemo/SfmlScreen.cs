using GameBoost.Core;
using GameBoost.Rendering;

namespace TextureDemo
{
    public class SfmlScreen : IScreen
    {
        private readonly float _width;
        private readonly float _height;

        public SfmlScreen(float width, float height)
        {
            _width = width;
            _height = height;
        }

        public float Width => _width;
        public float Height => _height;

        public Vector2D ConvertWorldToScreen(Vector2D worldPosition)
        {
            // Scale factors for world grid (40x20) to screen (e.g., 800x600)
            float worldToScreenX = Width / 40f;  // 800 / 40 = 20
            float worldToScreenY = Height / 20f; // 600 / 20 = 30

            // Map X as before
            float screenX = worldPosition.X * worldToScreenX;

            // Invert Y: World Y=0 (bottom) maps to screen Y=Height (bottom), Y=20 (top) maps to screen Y=0 (top)
            float screenY = (20f - worldPosition.Y) * worldToScreenY;

            return new Vector2D(screenX, screenY);
        }
    }
}
