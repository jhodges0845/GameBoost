namespace GameBoost.Rendering
{
    /// <summary>
    /// Represents a texture that can be drawn by a render context.
    /// </summary>
    public interface ITexture
    {
        /// <summary>
        /// Width of the texture in pixels.
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Height of the texture in pixels.
        /// </summary>
        int Height { get; }
    }
}
