using GameBoost.Core;

namespace GameBoost.Rendering
{
    /// <summary>
    /// A basic object that can be rendered with a texture and position.
    /// </summary>
    public class RenderableObject
    {
        public IVector2D Position { get; set; }
        public ITexture Texture { get; }

        public RenderableObject(ITexture texture, IVector2D position)
        {
            Texture = texture;
            Position = position;
        }

        /// <summary>
        /// Renders the object using the provided context.
        /// </summary>
        public void Render(IRenderContext context)
        {
            context.DrawTexture(Texture, Position.X, Position.Y);
        }
    }
}
