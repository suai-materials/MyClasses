using System;
using System.Collections.Generic;
using System.Linq;

namespace MyClasses;

/* Создать класс квадратная матрица, поля класса – размерность и элементы матрицы.
 Методы класса: проверка, является ли матрица верхнетреугольной или нижнетреугольной, вывод матрицы. 
 В классе предусмотреть методы: сложение, вычитание, умножение матриц, умножение матрицы на число. */

public class Matrix
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

    public Matrix(int n)
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

    public Matrix(int n, List<List<int>> matrixList)
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
    public static Matrix operator +(Matrix matrix, Matrix matrix2)
    {
        if (matrix2.N != matrix.N)
            throw new Exception("Матрицы не совпадают по размерности");
        var newMatrix = new Matrix(matrix.N);
        for (int i = 0; i < matrix.N; i++)
        {
            for (int j = 0; j < matrix.N; j++)
                newMatrix[i][j] = matrix[i][j] + matrix2[i][j];
        }

        return newMatrix;
    }
    
    // Вычитание матриц
    public static Matrix operator -(Matrix matrix, Matrix matrix2)
    {
        if (matrix2.N != matrix.N)
            throw new Exception("Матрицы не совпадают по размерности");
        var newMatrix = new Matrix(matrix.N);
        for (int i = 0; i < matrix.N; i++)
        {
            for (int j = 0; j < matrix.N; j++)
                newMatrix[i][j] = matrix[i][j] - matrix2[i][j];
        }

        return newMatrix;
    }
}