using GameBoost.Core;
using NUnit.Framework;

namespace GameBoost.Core.Tests
{
    [TestFixture]
    public class Vector2DTests
    {

        [Test]
        public void Addition_ReturnsCorrectSum()
        {
            var v1 = new Vector2D(1f, 2f, new MathUtils());
            var v2 = new Vector2D(3f, 4f, new MathUtils());
            var result = v1.Add( v2);

            Assert.That(result.X, Is.EqualTo(4f));
            Assert.That(result.Y, Is.EqualTo(6f));
        }

        [Test]
        public void Magnitude_CalculatesCorrectLength()
        {
            var v = new Vector2D(3f, 4f, new MathUtils()); // 3-4-5 triangle
            var magnitude = v.Magnitude();

            Assert.That(magnitude, Is.EqualTo(5f).Within(0.000001));
        }

        [Test]
        public void Dot_SameDirection_ReturnsPositive()
        {
            // Arrange
            var vector1 = new Vector2D(1, 0, new MathUtils()); // Points right
            var vector2 = new Vector2D(1, 0, new MathUtils()); // Also points right

            // Act
            double result = vector1.Dot(vector2);

            // Assert
            Assert.That(result, Is.EqualTo(1)); // Dot product of (1,0) and (1,0) = 1 * 1 + 0 * 0 = 1
        }

        [Test]
        public void Dot_OppositeDirection_ReturnsNegative()
        {
            // Arrange
            var vector1 = new Vector2D(1, 0, new MathUtils());  // Points right
            var vector2 = new Vector2D(-1, 0, new MathUtils()); // Points left

            // Act
            double result = vector1.Dot( vector2);

            // Assert
            Assert.That(result, Is.EqualTo(-1)); // Dot product of (1,0) and (-1,0) = 1 * -1 + 0 * 0 = -1
        }

        [Test]
        public void Dot_Perpendicular_ReturnsZero()
        {
            // Arrange
            var vector1 = new Vector2D(1, 0, new MathUtils());  // Points right
            var vector2 = new Vector2D(0, 1, new MathUtils());  // Points up

            // Act
            double result = vector1.Dot( vector2);

            // Assert
            Assert.That(result, Is.EqualTo(0)); // Dot product of (1,0) and (0,1) = 1 * 0 + 0 * 1 = 0
        }

        [Test]
        public void Dot_DifferentMagnitudes_SameDirection_ReturnsProductOfMagnitudes()
        {
            // Arrange
            var vector1 = new Vector2D(2, 0, new MathUtils()); // Points right, magnitude 2
            var vector2 = new Vector2D(3, 0, new MathUtils()); // Points right, magnitude 3

            // Act
            double result = vector1.Dot(vector2);

            // Assert
            Assert.That(result, Is.EqualTo(6)); // Dot product of (2,0) and (3,0) = 2 * 3 + 0 * 0 = 6
        }

        [Test]
        public void Dot_AngleBetween_ReturnsCosineRelatedValue()
        {
            // Arrange
            var vector1 = new Vector2D(1, 0, new MathUtils());  // Points right
            var vector2 = new Vector2D(1, 1, new MathUtils());  // Points at 45 degrees
            float expected = 1 * 1 + 0 * 1;    // Dot product of (1,0) and (1,1) = 1 * 1 + 0 * 1 = 1

            // Act
            double result = vector1.Dot( vector2);

            // Assert
            Assert.That(result, Is.EqualTo(expected)); // Exact dot product matches
        }
    }
}
