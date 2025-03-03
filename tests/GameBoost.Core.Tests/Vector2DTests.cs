using GameBoost.Core;
using NUnit.Framework;

namespace GameBoost.Core.Tests
{
    [TestFixture]
    public class Vector2DTests
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        [Test]
        public void Addition_ReturnsCorrectSum()
        {
            var v1 = new Vector2D(1f, 2f);
            var v2 = new Vector2D(3f, 4f);
            var result = v1 + v2;

            Assert.That(result.X, Is.EqualTo(4f));
            Assert.That(result.Y, Is.EqualTo(6f));
        }

        [Test]
        public void Magnitude_CalculatesCorrectLength()
        {
            var v = new Vector2D(3f, 4f); // 3-4-5 triangle
            var magnitude = v.Magnitude();

            Assert.That(magnitude, Is.EqualTo(5f).Within(0.000001));
        }
    }
}
