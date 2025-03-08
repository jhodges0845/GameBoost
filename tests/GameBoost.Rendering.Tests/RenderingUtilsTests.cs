using GameBoost.Core;

namespace GameBoost.Rendering.Tests
{
    [TestFixture]
    public class RenderingUtilsTests
    {
        [Test]
        public void ScreenToWorld_ConvertsCorrectly()
        {
            var screenPos = new Vector2D(100f, 50f);
            var cameraPos = new Vector2D(50f, 25f);
            var result = RenderingUtils.ScreenToWorld(screenPos, cameraPos, 2f);
            Assert.That(result.X, Is.EqualTo(25f).Within(0.0001)); // (100-50)/2
            Assert.That(result.Y, Is.EqualTo(12.5f).Within(0.0001)); // (50-25)/2
        }

        [Test]
        public void WorldToScreen_ConvertsCorrectly()
        {
            var worldPos = new Vector2D(25f, 12.5f);
            var cameraPos = new Vector2D(50f, 25f);
            var result = RenderingUtils.WorldToScreen(worldPos, cameraPos, 2f);
            Assert.That(result.X, Is.EqualTo(100f).Within(0.0001)); // 25*2 + 50
            Assert.That(result.Y, Is.EqualTo(50f).Within(0.0001)); // 12.5*2 + 25
        }
    }
}
