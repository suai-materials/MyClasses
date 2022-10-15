using System;
using System.Collections.Generic;
using System.Linq;

namespace MyClasses;

/* Создать класс квадратная матрица, поля класса – размерность и элементы матрицы.
 Методы класса: проверка, является ли матрица верхнетреугольной или нижнетреугольной, вывод матрицы. 
 В классе предусмотреть методы: сложение, вычитание, умножение матриц, умножение матрицы на число. */

public class SquareMatrix
{
    // Размерность матрицы
    private int _n;

    public int N
    {
        get => _n;
        set
        {
            if (value <= 0)
                throw new Exception("Размерность матрицы должна быть больше 0");
            _n = value;
        }
    }

    // Список содержащий элементы матрицы
    private List<List<int>> _matrixList = null!;

    public List<List<int>> MatrixList
    {
        get => _matrixList;
        set
        {
            if (value.Count != N || value[0].Count != N)
                throw new Exception("Вводимая матрица неподходит по размерности");
            _matrixList = value;
        }
    }

    public List<int> this[int i]
    {
        get { return MatrixList[i]; }
        set
        {
            if (value.Count != N)
                throw new Exception("Вводимая строка неподходит по размерности");
            MatrixList[i] = value;
        }
    }

    public SquareMatrix(int n)
    {
        N = n;
        var matrixList = new List<List<int>>();
        for (int i = 0; i < n; i++)
        {
            matrixList.Add(new List<int>());
            for (int j = 0; j < n; j++)
            {
                matrixList.Last().Add(0);
            }
        }

        MatrixList = matrixList;
    }

    public SquareMatrix(int n, List<List<int>> matrixList)
    {
        N = n;
        MatrixList = matrixList;
    }

    public override string ToString()
    {
        string output = "[\n";
        foreach (var list in MatrixList)
        {
            output += '\t' + String.Join('\t', list) + '\n';
        }

        output += "]";
        return output;
    }

    // Это верхняя треугольная матрица?
    public bool IsUpperTriangular()
    {
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (MatrixList[i][j] != 0)
                    return false;
            }
        }

        return true;
    }

    // Это нижняя треугольная матрица?
    public bool IsBottomTriangular()
    {
        for (int i = 0; i < N; i++)
        {
            for (int j = N - 1; j > i; j--)
            {
                if (MatrixList[i][j] != 0)
                    return false;
            }
        }

        return true;
    }

    // Сложение матриц
    public static SquareMatrix operator +(SquareMatrix squareMatrix, SquareMatrix squareMatrix2)
    {
        if (squareMatrix2.N != squareMatrix.N)
            throw new Exception("Матрицы не совпадают по размерности");
        var newMatrix = new SquareMatrix(squareMatrix.N);
        for (int i = 0; i < squareMatrix.N; i++)
        {
            for (int j = 0; j < squareMatrix.N; j++)
                newMatrix[i][j] = squareMatrix[i][j] + squareMatrix2[i][j];
        }

        return newMatrix;
    }

    // Вычитание матриц
    public static SquareMatrix operator -(SquareMatrix squareMatrix, SquareMatrix squareMatrix2)
    {
        if (squareMatrix2.N != squareMatrix.N)
            throw new Exception("Матрицы не совпадают по размерности");
        var newMatrix = new SquareMatrix(squareMatrix.N);
        for (int i = 0; i < squareMatrix.N; i++)
        {
            for (int j = 0; j < squareMatrix.N; j++)
                newMatrix[i][j] = squareMatrix[i][j] - squareMatrix2[i][j];
        }

        return newMatrix;
    }

    // Умножение матрицы на число
    public static SquareMatrix operator *(SquareMatrix squareMatrix, int n)
    {
        var newMatrix = new SquareMatrix(squareMatrix.N);
        for (int i = 0; i < squareMatrix.N; i++)
        {
            for (int j = 0; j < squareMatrix.N; j++)
                newMatrix[i][j] = squareMatrix[i][j] * n;
        }

        return newMatrix;
    }

    // Перемножение матриц
    public static SquareMatrix operator *(SquareMatrix squareMatrix, SquareMatrix squareMatrix2)
    {
        if (squareMatrix2.N != squareMatrix.N)
            throw new Exception("Матрицы не совпадают по размерности");
        var newMatrix = new SquareMatrix(squareMatrix.N);
        for (int i = 0; i < squareMatrix.N; i++)
        {
            for (int j = 0; j < squareMatrix.N; j++)
            {
                int cellValue = 0;
                for (int j1 = 0; j1 < squareMatrix.N; j1++)
                {
                    cellValue += squareMatrix[i][j1] * squareMatrix2[j1][j];
                }

                newMatrix[i][j] = cellValue;
            }
        }

        return newMatrix;
    }
}