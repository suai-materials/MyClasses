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
    public uint N;

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

    public Matrix(uint n)
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

    public Matrix(uint n, List<List<int>> matrixList)
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
}