using GameBoost.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBoost.Rendering
{
    /// <summary>
    /// Represents a 2D camera for managing the viewable area in a game.
    /// </summary>
    public struct Camera2D
    {
        public Vector2D Position { get; set; } // Center of the camera in world coordinates
        public float Scale { get; set; }       // Zoom level (1.0 = normal, >1 = zoom in, <1 = zoom out)
        public float Width { get; set; }       // Viewport width in screen units
        public float Height { get; set; }      // Viewport height in screen units

        /// <summary>
        /// Initializes a new Camera2D with position, scale, and viewport size.
        /// </summary>
        public Camera2D(Vector2D position, float scale, float width, float height)
        {
            Position = position;
            Scale = scale > 0 ? scale : 1f; // Prevent invalid scale
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Moves the camera by an offset in world coordinates.
        /// </summary>
        public Camera2D Move(Vector2D offset)
        {
            Camera2D result = this;
            result.Position += offset;
            return result;
        }

        /// <summary>
        /// Adjusts the camera zoom by a factor.
        /// </summary>
        public Camera2D Zoom(float factor)
        {
            Camera2D result = this;
            result.Scale = MathUtils.Clamp(result.Scale * factor, 0.1f, 10f); // Limit zoom range
            return result;
        }

        /// <summary>
        /// Checks if a sprite is within the camera's viewable area.
        /// </summary>
        public bool IsInView(Sprite sprite)
        {
            Vector2D screenPos = RenderingUtils.WorldToScreen(sprite.Position, Position, Scale);
            float halfWidth = Width / 2f;
            float halfHeight = Height / 2f;
            return screenPos.X + sprite.Width >= -halfWidth &&
                   screenPos.X - sprite.Width <= halfWidth &&
                   screenPos.Y + sprite.Height >= -halfHeight &&
                   screenPos.Y - sprite.Height <= halfHeight;
        }
    }
}
