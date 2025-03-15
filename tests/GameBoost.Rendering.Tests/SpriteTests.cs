using GameBoost.Core;

namespace GameBoost.Rendering.Tests
{
    [TestFixture]
    public class SpriteTests
    {
        [Test]
        public void Translate_MovesPositionCorrectly()
        {
            var sprite = new Sprite(new MathUtils(), new Vector2D(0f, 0f, new MathUtils()), 1f, 1f);
            var moved = sprite.Translate(new Vector2D(5f, 3f, new MathUtils()));
            Assert.That(moved.Position.X, Is.EqualTo(5f).Within(0.0001));
            Assert.That(moved.Position.Y, Is.EqualTo(3f).Within(0.0001));
        }

        [Test]
        public void Rotate_UpdatesRotation()
        {
            var sprite = new Sprite(new MathUtils(), new Vector2D().Zero(), 1f, 1f, rotation: 90f);
            var rotated = sprite.Rotate(45f);
            Assert.That(rotated.Rotation, Is.EqualTo(135f).Within(0.0001));
        }

        [Test]
        public void Scale_AdjustsSize()
        {
            var sprite = new Sprite(new MathUtils(), new Vector2D().Zero(), 2f, 4f);
            var scaled = sprite.Scale(0.5f);
            Assert.That(scaled.Width, Is.EqualTo(1f).Within(0.0001));
            Assert.That(scaled.Height, Is.EqualTo(2f).Within(0.0001));
        }
    }
}
