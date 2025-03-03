using GameBoost.Core;
using NUnit.Framework;

namespace GameBoost.Core.Tests;

[TestFixture]
public class MathUtilsTests
{
    //[SetUp]
    //public void Setup()
    //{
    //}

    [Test]
    public void Clamp_WithinRange_ReturnsValue()
    {
        var result = MathUtils.Clamp(5f, 0f, 10f);
        Assert.That(result, Is.EqualTo(5f));
    }

    [Test]
    public void Clamp_BelowMin_ReturnsMin()
    {
        var result = MathUtils.Clamp(-1f, 0f, 10f);
        Assert.That(result, Is.EqualTo(0f));
    }

    [Test]
    public void Clamp_AboveMax_ReturnsMax()
    {
        var result = MathUtils.Clamp(15f, 0f, 10f);
        Assert.That(result, Is.EqualTo(10f));
    }

    [Test]
    public void Lerp_ReturnsInterpolatedValue()
    {
        var result = MathUtils.Lerp(0f, 10f, 0.5f);
        Assert.That(result, Is.EqualTo(5f));
    }

    [Test]
    public void Lerp_TBelowZero_ReturnsStartValue()
    {
        var result = MathUtils.Lerp(0f, 10f, -0.2f);
        Assert.That(result, Is.EqualTo(0f));
    }

    [Test]
    public void Lerp_TAboveOne_ReturnsEndValue()
    {
        var result = MathUtils.Lerp(0f, 10f, 1.5f);
        Assert.That(result, Is.EqualTo(10f));
    }
}
