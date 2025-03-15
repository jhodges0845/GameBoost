using GameBoost.Core;

namespace GameBoost.Rendering
{
    /// <summary>
    /// Represents a 2D sprite with position, size, and optional texture data.
    /// </summary>
    public struct Sprite
    {
        public IVector2D Position { get; set; }
        private readonly IMathUtils _mathUtils;
        public float Width { get; set; }
        public float Height { get; set; }
        public float Rotation { get; set; } // In degrees
        public string TextureId { get; set; } // Placeholder for texture reference

        /// <summary>
        /// Initializes a new Sprite with position, size, and texture.
        /// </summary>
        public Sprite( IMathUtils mathUtils, IVector2D position, float width, float height, string textureId = "", float rotation = 0f)
        {
            _mathUtils = mathUtils;
            Position = position;
            Width = width;
            Height = height;
            TextureId = textureId;
            Rotation = rotation;
        }

        /// <summary>
        /// Moves the sprite by a given offset.
        /// </summary>
        public Sprite Translate(Vector2D offset)
        {
            Sprite result = this;
            result.Position = result.Position.Add(offset);
            return result;
        }

        /// <summary>
        /// Rotates the sprite by a given angle in degrees.
        /// </summary>
        public Sprite Rotate(float angleDegrees)
        {
            Sprite result = this;
            result.Rotation = (result.Rotation + angleDegrees) % 360f;
            return result;
        }

        public Vector2D Center()
        {
            return new Vector2D(this.Position.X + this.Width / 2f, this.Position.Y + this.Height / 2f, _mathUtils);
        }

        /// <summary>
        /// Scales the sprite by a factor.
        /// </summary>
        public Sprite Scale(float factor)
        {
            Sprite result = this;
            result.Width *= factor;
            result.Height *= factor;
            return result;
        }
    }
}
