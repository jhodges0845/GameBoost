using GameBoost.Core;

namespace GameBoost.Rendering
{
    /// <summary>
    /// Provides utility methods for 2D rendering calculations.
    /// </summary>
    public static class RenderingUtils
    {
        /// <summary>
        /// Converts screen coordinates to world coordinates given a camera position and scale.
        /// </summary>
        public static Vector2D ScreenToWorld(Vector2D screenPos, Vector2D cameraPos, float cameraScale)
        {
            return (screenPos - cameraPos) * (1f / cameraScale);
        }

        /// <summary>
        /// Converts world coordinates to screen coordinates given a camera position and scale.
        /// </summary>
        public static Vector2D WorldToScreen(Vector2D worldPos, Vector2D cameraPos, float cameraScale)
        {
            return (worldPos * cameraScale) + cameraPos;
        }

        /// <summary>
        /// Calculates the bounding box center of a sprite.
        /// </summary>
        public static Vector2D GetSpriteCenter(Sprite sprite)
        {
            return new Vector2D(sprite.Position.X + sprite.Width / 2f, sprite.Position.Y + sprite.Height / 2f);
        }
    }
}
