using SFML.Graphics;

namespace TextureDemo
{
    public class SfmlTexture : GameBoost.Rendering.ITexture
    {
        public Texture Texture { get; }

        public int Width => (int)Texture.Size.X;
        public int Height => (int)Texture.Size.Y;

        public SfmlTexture(string filePath)
        {
            Texture = new Texture(filePath);
        }
    }
}
