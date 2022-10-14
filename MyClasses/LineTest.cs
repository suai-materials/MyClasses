using System;
using NUnit.Framework;

namespace MyClasses;

public class LineTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void FieldsTest()
    {
        var line = new Line(10, 10, 20, -10);
        Assert.AreEqual(line.StartX, 10);
        Assert.AreEqual(line.EndX, 20);
        Assert.AreEqual(line.StartY, 10);
        Assert.AreEqual(line.EndY, -10);
        Assert.AreEqual(Math.Floor(line.Length), 22f);
        line.StartX *= 2;
        line.EndX *= 2;
        line.StartY *= 2;
        line.EndY *= 2;
        Assert.AreEqual(line.StartX, 20);
        Assert.AreEqual(line.EndX, 40);
        Assert.AreEqual(line.StartY, 20);
        Assert.AreEqual(line.EndY, -20);
        Assert.AreEqual(Math.Floor(line.Length), 44f);
    }

    [Test]
    public void PairsTest()
    {
        var line = new Line(0, 0, 0, 10);
        Assert.AreEqual(line.Start.X, 0);
        Assert.AreEqual(line.End.Y, 10);
        (int X, int Y) pair = (0, 0);
        Assert.AreEqual(line.Start, pair);
        pair.Y = 10;
        Assert.AreEqual(line.End, pair);
    }

    [Test]
    public void LengthTest()
    {
        Assert.AreEqual(new Line(0, 0, 0, 1).Length, 1f);
        Assert.AreEqual(new Line(10, 2, 10, 10).Length, 8f);
    }

    [Test]
    public void StringTest()
    {
        var line = new Line(10, 2, 10, 10);
        Assert.AreEqual(line.ToString(), $"({10}, {2}) -> ({10}, {10}) Length: {8f}");
    }
}