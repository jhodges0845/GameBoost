using GameBoost.Core;

namespace GameBoost.Rendering.Tests
{
    [TestFixture]
    internal class Camera2DTests
    {
        [Test]
        public void Move_UpdatesPosition()
        {
            var camera = new Camera2D(new Vector2D().Zero(), 1f, 800f, 600f);
            var moved = camera.Move(new Vector2D(10f, 20f, new MathUtils()));
            Assert.That(moved.Position.X, Is.EqualTo(10f).Within(0.0001));
            Assert.That(moved.Position.Y, Is.EqualTo(20f).Within(0.0001));
        }

        [Test]
        public void Zoom_ClampsScale()
        {
            var camera = new Camera2D(new Vector2D().Zero(), 1f, 800f, 600f);
            var zoomedIn = camera.Zoom(15f); // Should clamp to 10
            var zoomedOut = camera.Zoom(0.01f); // Should clamp to 0.1
            Assert.That(zoomedIn.Scale, Is.EqualTo(10f).Within(0.0001));
            Assert.That(zoomedOut.Scale, Is.EqualTo(0.1f).Within(0.0001));
        }

        [Test]
        public void IsInView_DetectsVisibility()
        {
            var camera = new Camera2D(new Vector2D().Zero(), 1f, 800f, 600f);
            var sprite = new Sprite(new MathUtils(), new Vector2D(0f, 0f, new MathUtils()), 10f, 10f);
            var farSprite = new Sprite(new MathUtils(), new Vector2D(500f, 500f, new MathUtils()), 10f, 10f);
            Assert.That(camera.IsInView(sprite), Is.True);
            Assert.That(camera.IsInView(farSprite), Is.False);
        }
    }
}
