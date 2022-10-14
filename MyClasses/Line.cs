using System;

namespace MyClasses;

/*Задание. Создать класс с закрытыми полями, задающими координаты 2-х точек на плоскости.
 Предусмотреть вызов конструктора, инициализирующий 4 поля. 
 Доступ к полям реализовать через свойства. Создать метод, возвращающий расстояние между точками.*/

public class Line
{
    private (int x, int y) _end;
    private (int x, int y) _start;

    public Line(int x1, int y1, int x2, int y2)
    {
        _start = (x1, y1);
        _end = (x2, y2);
    }

    public (int X, int Y) Start => _start;

    public (int X, int Y) End => _end;

    public int StartX
    {
        get => _start.x;
        set => _start.x = value;
    }

    public int StartY
    {
        get => _start.y;
        set => _start.y = value;
    }

    public int EndX
    {
        get => _end.x;
        set => _end.x = value;
    }

    public int EndY
    {
        get => _end.y;
        set => _end.y = value;
    }

    public double Length => Math.Sqrt((EndX - StartX) * (EndX - StartX) + (EndY - StartY) * (EndY - StartY));

    public override string ToString() => $"({StartX}, {StartY}) -> ({EndX}, {EndY}) Length: {Length}";
    
}