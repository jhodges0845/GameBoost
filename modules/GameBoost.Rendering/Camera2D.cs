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
        public IVector2D Position { get; set; } // Center of the camera in world coordinates
        public double Scale { get; set; }       // Zoom level (1.0 = normal, >1 = zoom in, <1 = zoom out)
        public double Width { get; set; }       // Viewport width in screen units
        public double Height { get; set; }      // Viewport height in screen units

        /// <summary>
        /// Initializes a new Camera2D with position, scale, and viewport size.
        /// </summary>
        public Camera2D(IVector2D position, double scale, double width, double height)
        {
            Position = position;
            Scale = scale > 0 ? scale : 1f; // Prevent invalid scale
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Moves the camera by an offset in world coordinates.
        /// </summary>
        public Camera2D Move(IVector2D offset)
        {
            Camera2D result = this;
            result.Position = result.Position.Add( offset);
            return result;
        }

        /// <summary>
        /// Adjusts the camera zoom by a factor.
        /// </summary>
        public Camera2D Zoom(double factor)
        {
            Camera2D result = this;
            result.Scale = new MathUtils().Clamp(result.Scale * factor, 0.1f, 10f); // Limit zoom range
            return result;
        }

        /// <summary>
        /// Checks if a sprite is within the camera's viewable area.
        /// </summary>
        public bool IsInView(Sprite sprite)
        {
            IVector2D screenPos = RenderingUtils.WorldToScreen(sprite.Position, Position, Scale);
            double halfWidth = Width / 2f;
            double halfHeight = Height / 2f;
            return screenPos.X + sprite.Width >= -halfWidth &&
                   screenPos.X - sprite.Width <= halfWidth &&
                   screenPos.Y + sprite.Height >= -halfHeight &&
                   screenPos.Y - sprite.Height <= halfHeight;
        }
    }
}
