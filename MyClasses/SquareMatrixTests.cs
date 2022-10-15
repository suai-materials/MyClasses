using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MyClasses;

public class SquareMatrixTests
{
    [Test]
    public void InitTest()
    {
        var matrix = new SquareMatrix(2);
        List<List<int>> myMatrixList = new List<List<int>>();
        myMatrixList.Add(new List<int>() {0, 0});
        myMatrixList.Add(new List<int>() {0, 0});
        Assert.AreEqual(matrix.MatrixList, myMatrixList);
        myMatrixList[0][0] = 1;
        var matrix2 = new SquareMatrix(2, myMatrixList);
        Assert.AreEqual(matrix2.MatrixList, myMatrixList);
    }

    [Test]
    public void StringTest()
    {
        Assert.AreEqual(new SquareMatrix(1).ToString(), "[\n\t0\n]");
        Console.WriteLine(new SquareMatrix(10).ToString());
    }

    [Test]
    public void TriangularTest()
    {
        List<List<int>> myMatrixList = new List<List<int>>();
        myMatrixList.Add(new List<int>() {1, 0});
        myMatrixList.Add(new List<int>() {1, 1});
        var matrix = new SquareMatrix(2, myMatrixList);
        Assert.IsFalse(matrix.IsUpperTriangular());
        Assert.IsTrue(matrix.IsBottomTriangular());
        myMatrixList = new List<List<int>>();
        myMatrixList.Add(new List<int>() {1, 0, 1});
        myMatrixList.Add(new List<int>() {0, 1, 0});
        myMatrixList.Add(new List<int>() {0, 0, 1});
        matrix = new SquareMatrix(3, myMatrixList);
        Assert.IsTrue(matrix.IsUpperTriangular());
        Assert.IsFalse(matrix.IsBottomTriangular());
    }

    class MathTests
    {
        [Test]
        public void MatrixAdditionTest()
        {
            List<List<int>> myMatrixList = new List<List<int>>();
            myMatrixList.Add(new List<int>() {1, 0});
            myMatrixList.Add(new List<int>() {1, 1});
            var matrix = new SquareMatrix(2, myMatrixList);
        
            Assert.AreEqual((matrix + matrix)[0], new List<int>() {2, 0});
            Assert.AreEqual((matrix + matrix)[1], new List<int>() {2, 2});
            Assert.AreEqual((matrix - matrix - matrix)[0], new List<int>() {-1, 0});
            Assert.AreEqual((matrix - matrix - matrix)[1], new List<int>() {-1, -1});
        }

        [Test]
        public void ScalarMultiplication()
        {
            List<List<int>> myMatrixList = new List<List<int>>();
            myMatrixList.Add(new List<int>() {1, 2});
            myMatrixList.Add(new List<int>() {3, 4});
            var matrix = new SquareMatrix(2, myMatrixList);
            Assert.AreEqual((matrix * 5)[0], new List<int>() {5, 10});
            Assert.AreEqual((matrix * 5)[1], new List<int>() {15, 20});
        }

        [Test]
        public void Multiplication()
        {
            List<List<int>> myMatrixList = new List<List<int>>();
            myMatrixList.Add(new List<int>() {1, 2});
            myMatrixList.Add(new List<int>() {3, 4});
            var matrix = new SquareMatrix(2, myMatrixList);
            Assert.AreEqual((matrix * matrix)[0], new List<int>() {7, 10});
            Assert.AreEqual((matrix * matrix)[1], new List<int>() {15, 22});
            myMatrixList = new List<List<int>>();
            myMatrixList.Add(new List<int>() {1, 2, 3});
            myMatrixList.Add(new List<int>() {1, 2, 3});
            myMatrixList.Add(new List<int>() {1, 2, 3});
            matrix = new SquareMatrix(3, myMatrixList);
            Assert.AreEqual((matrix * matrix)[0], new List<int>() {6, 12, 18});
            Assert.AreEqual((matrix * matrix)[1], new List<int>() {6, 12, 18});
            Assert.AreEqual((matrix * matrix)[2], new List<int>() {6, 12, 18});
        }

        [Test]
        public void ExtraTest()
        {
            List<List<int>> myMatrixList = new List<List<int>>();
            myMatrixList.Add(new List<int>() {1, 2});
            myMatrixList.Add(new List<int>() {3, 4});
            var matrix = new SquareMatrix(2, myMatrixList);
            matrix = ((matrix + matrix) * 2 - matrix) * matrix;
            Assert.AreEqual(matrix[0], new List<int>() {21, 30});
            Assert.AreEqual(matrix[0], new List<int>() {45, 60});
        }

    }
}