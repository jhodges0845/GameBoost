using GameBoost.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBoost.Rendering
{
    public class RenderContext :IDisposable
    {
        private readonly Bitmap _bitmap;
        private readonly Graphics _graphics;

        public RenderContext(int width, int height)
        {
            _bitmap = new Bitmap(width, height);
            _graphics = Graphics.FromImage(_bitmap);
        }

        public void Clear(Color color)
        {
            _graphics.Clear(color);
        }

        public void DrawSprite(Sprite sprite, Color fillColor)
        {
            var brush = new SolidBrush(fillColor);
            _graphics.FillRectangle(brush, sprite.Position.X, sprite.Position.Y, sprite.Width, sprite.Height);
        }

        public void DrawBatch(SpriteBatch batch, Camera2D camera)
        {
            var sprites = batch.GetSprites(camera);
            foreach (var sprite in sprites)
            {
                Vector2D screenPos = RenderingUtils.WorldToScreen(sprite.Position, camera);
                var brush = new SolidBrush(sprite.TextureId == "box" ? Color.Red : Color.Green);
                _graphics.FillRectangle(brush, screenPos.X, screenPos.Y, sprite.Width, sprite.Height);
            }
        }

        public void Save(string filePath)
        {
            _bitmap.Save(filePath);
        }

        public void Dispose()
        {
            _graphics.Dispose();
            _bitmap.Dispose();
        }
    }
}
