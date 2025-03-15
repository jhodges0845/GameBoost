namespace GameBoost.Rendering
{
    /// <summary>
    /// Defines a rendering context for drawing textures and managing the display.
    /// </summary>
    public interface IRenderContext
    {
        /// <summary>
        /// Clears the screen with a specified color (R, G, B, A).
        /// </summary>
        void Clear(double r, double g, double b, double a);

        /// <summary>
        /// Draws a texture at a given position.
        /// </summary>
        void DrawTexture(ITexture texture, double x, double y);

        /// <summary>
        /// Draws text at a given postion).
        /// </summary>
        void DrawText(object text); // Use object to keep it generic for now

        /// <summary>
        /// Updates the display (e.g., swaps buffers).
        /// </summary>
        void Display();

        /// <summary>
        /// Checks if the rendering context is still active (e.g., window open).
        /// </summary>
        bool IsActive();
    }
}
