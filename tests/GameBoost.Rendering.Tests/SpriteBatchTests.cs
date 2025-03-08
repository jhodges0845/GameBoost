using GameBoost.Core;

namespace GameBoost.Rendering.Tests
{
    [TestFixture]
    public class SpriteBatchTests
    {
        [Test]
        public void Add_IncreasesCount()
        {
            var batch = new SpriteBatch();
            batch.Add(new Sprite(Vector2D.Zero, 1f, 1f));
            Assert.That(batch.GetSprites().Count, Is.EqualTo(1));
        }

        [Test]
        public void GetSprites_FiltersByCamera()
        {
            var batch = new SpriteBatch();
            var camera = new Camera2D(Vector2D.Zero, 1f, 100f, 100f);
            batch.Add(new Sprite(new Vector2D(0f, 0f), 10f, 10f)); // In view
            batch.Add(new Sprite(new Vector2D(100f, 100f), 10f, 10f)); // Out of view
            var visible = batch.GetSprites(camera);
            Assert.That(visible.Count, Is.EqualTo(1));
            Assert.That(visible[0].Position.X, Is.EqualTo(0f).Within(0.0001));
        }

        [Test]
        public void TransformAll_AppliesToAllSprites()
        {
            var batch = new SpriteBatch();
            batch.Add(new Sprite(Vector2D.Zero, 2f, 2f));
            batch.Add(new Sprite(new Vector2D(1f, 1f), 2f, 2f));
            batch.TransformAll(new Vector2D(5f, 0f), 90f, 0.5f);
            var sprites = batch.GetSprites();
            Assert.That(sprites[0].Position.X, Is.EqualTo(5f).Within(0.0001));
            Assert.That(sprites[0].Rotation, Is.EqualTo(90f).Within(0.0001));
            Assert.That(sprites[0].Width, Is.EqualTo(1f).Within(0.0001));
        }
    }
}
