using GameBoost.Core;

namespace GameBoost.Rendering
{
    /// <summary>
    /// Manages a collection of sprites for efficient batch rendering.
    /// </summary>
    public class SpriteBatch
    {
        private readonly List<Sprite> _sprites;

        public SpriteBatch()
        {
            _sprites = new List<Sprite>();
        }

        /// <summary>
        /// Adds a sprite to the batch.
        /// </summary>
        public void Add(Sprite sprite)
        {
            _sprites.Add(sprite);
        }

        /// <summary>
        /// Clears all sprites from the batch.
        /// </summary>
        public void Clear()
        {
            _sprites.Clear();
        }

        /// <summary>
        /// Gets the list of sprites in the batch, optionally filtered by a camera's view.
        /// </summary>
        public IReadOnlyList<Sprite> GetSprites(Camera2D? camera = null)
        {
            if (camera.HasValue)
            {
                return _sprites.FindAll(sprite => camera.Value.IsInView(sprite)).AsReadOnly();
            }
            return _sprites.AsReadOnly();
        }

        /// <summary>
        /// Applies a transformation to all sprites in the batch.
        /// </summary>
        public void TransformAll(Vector2D translation, float rotationDegrees = 0f, float scaleFactor = 1f)
        {
            for (int i = 0; i < _sprites.Count; i++)
            {
                Sprite sprite = _sprites[i];
                sprite = sprite.Translate(translation);
                if (rotationDegrees != 0f) sprite = sprite.Rotate(rotationDegrees);
                if (scaleFactor != 1f) sprite = sprite.Scale(scaleFactor);
                _sprites[i] = sprite;
            }
        }

    }
}
