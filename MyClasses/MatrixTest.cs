using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MyClasses;

public class MatrixTest
{
    [Test]
    public void InitTest()
    {
        var matrix = new Matrix(2);
        List<List<int>> myMatrixList = new List<List<int>>();
        myMatrixList.Add(new List<int>() {0, 0});
        myMatrixList.Add(new List<int>() {0, 0});
        Assert.AreEqual(matrix.MatrixList, myMatrixList);
        myMatrixList[0][0] = 1;
        var matrix2 = new Matrix(2, myMatrixList);
        Assert.AreEqual(matrix2.MatrixList, myMatrixList);
    }

    [Test]
    public void StringTest()
    {
        Assert.AreEqual(new Matrix(1).ToString(), "[\n\t0\n]");
        Console.WriteLine(new Matrix(10).ToString());
    }

    [Test]
    public void TriangularTest()
    {
        List<List<int>> myMatrixList = new List<List<int>>();
        myMatrixList.Add(new List<int>() {1, 0});
        myMatrixList.Add(new List<int>() {1, 1});
        var matrix = new Matrix(2, myMatrixList);
        Assert.IsFalse(matrix.IsUpperTriangular());
        Assert.IsTrue(matrix.IsBottomTriangular());
        myMatrixList = new List<List<int>>();
        myMatrixList.Add(new List<int>() {1, 0, 1});
        myMatrixList.Add(new List<int>() {0, 1, 0});
        myMatrixList.Add(new List<int>() {0, 0, 1});
        matrix = new Matrix(3, myMatrixList);
        Assert.IsTrue(matrix.IsUpperTriangular());
        Assert.IsFalse(matrix.IsBottomTriangular());
    }

    [Test]
    public void MatrixAdditionTest()
    {
        List<List<int>> myMatrixList = new List<List<int>>();
        myMatrixList.Add(new List<int>() {1, 0});
        myMatrixList.Add(new List<int>() {1, 1});
        var matrix = new Matrix(2, myMatrixList);
        
        Assert.AreEqual((matrix + matrix)[0], new List<int>() {2, 0});
        Assert.AreEqual((matrix + matrix)[1], new List<int>() {2, 2});
        Assert.AreEqual((matrix - matrix - matrix)[0], new List<int>() {-1, 0});
        Assert.AreEqual((matrix - matrix - matrix)[1], new List<int>() {-1, -1});
    }
}