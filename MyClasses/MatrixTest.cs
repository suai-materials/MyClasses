using System;
using NUnit.Framework;

namespace MyClasses;

public class MatrixTest
{
    [Test]
    public void InitTest()
    {
        
    }

    [Test]
    public void StringTest()
    {
        Assert.AreEqual(new Matrix(1).ToString(), "[\n\t0\n]");
        Console.WriteLine(new Matrix(10).ToString());
    }
}