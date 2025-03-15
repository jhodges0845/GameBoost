using GameBoost.Core;

namespace GameBoost.Rendering
{
    /// <summary>
    /// Provides utility methods for 2D rendering calculations.
    /// </summary>
    public static class RenderingUtils
    {
        private static IMathUtils _mathUtils;
        /// <summary>
        /// Converts screen coordinates to world coordinates given a camera position and scale.
        /// </summary>
        public static IVector2D ScreenToWorld(IVector2D screenPos, IVector2D cameraPos, float cameraScale, IMathUtils mathUtils)
        {
            _mathUtils = mathUtils;
            return (screenPos.Subtract( cameraPos)).Multiply((1f / cameraScale));
        }

        /// <summary>
        /// Converts world coordinates to screen coordinates using a Camera2D.
        /// </summary>
        public static IVector2D WorldToScreen(IVector2D worldPos, Camera2D camera)
        {
            // Offset by camera position and center the viewport
            return worldPos.Subtract(camera.Position);
        }

        /// <summary>
        /// Converts world coordinates to screen coordinates given a camera position and scale.
        /// </summary>
        public static IVector2D WorldToScreen(IVector2D worldPos, IVector2D cameraPos, double cameraScale)
        {
            return (worldPos.Multiply( cameraScale)).Add( cameraPos);
        }

        /// <summary>
        /// Converts screen coordinates to world coordinates using a Camera2D.
        /// </summary>
        public static IVector2D ScreenToWorld(IVector2D screenPos, Camera2D camera)
        {
            return screenPos.Add(camera.Position);
        }

        /// <summary>
        /// Calculates the bounding box center of a sprite.
        /// </summary>
        public static IVector2D GetSpriteCenter(Sprite sprite)
        {
            return sprite.Center();
        }
    }
}
