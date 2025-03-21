﻿using SFML.Graphics;
using SFML.Window;

namespace PhysicsDemo
{
    public class SfmlRenderContext : GameBoost.Rendering.IRenderContext
    {
        private readonly RenderWindow _window;

        public SfmlRenderContext(uint width, uint height, string title)
        {
            _window = new RenderWindow(new VideoMode(width, height), title);
            _window.Closed += (sender, e) => _window.Close();
        }

        public void Clear(double r, double g, double b, double a)
        {
            _window.Clear(new Color((byte)(r * 255), (byte)(g * 255), (byte)(b * 255), (byte)(a * 255)));
        }

        public void DrawTexture(GameBoost.Rendering.ITexture texture, double x, double y)
        {
            if (texture is SfmlTexture sfmlTexture)
            {
                var sprite = new Sprite(sfmlTexture.Texture) { Position = new SFML.System.Vector2f((float)x, (float)y) };
                _window.Draw(sprite);
            }
        }

        public void DrawText(object text)
        {
            if (text is Text sfmlText)
            {
                _window.Draw(sfmlText);
            }
        }

        public void Display()
        {
            _window.DispatchEvents();
            _window.Display();
        }

        public bool IsActive()
        {
            return _window.IsOpen;
        }
    }
}
