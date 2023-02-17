// Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.

using System;
using static System.Console;

// Заполнение двумерного массива
int[,] GetArray(int m, int n, int minVal, int maxVal)
{
    int[,] result = new int[m, n];

    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(minVal, maxVal + 1);
        }
    }
    return result;
}

// Вывод двумерного массива
void PrintMatrix(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            if (arr[i, j] >= 0) // Если число положительное, то перед ним добавим пробел(чтобы в столбцах ровно выводились относительно отрицательных)
                Write(" ");
            Write($"{arr[i, j]} \t");
        }
        WriteLine();
    }
}

// Метод подстчета среднего арифметического по столбцам
double[] AverageInColumn(int[,] array)
{
    double[] res = new double[array.GetLength(1)];

    for (int j = 0; j < array.GetLength(1); j++)
    {
        double sum = 0;
        for (int i = 0; i < array.GetLength(0); i++)
            sum += array[i,j];

    res[j] = Math.Round(sum / array.GetLength(0), 1); // Среднее сразу огкругляем до 1 знака после запятой
    }
    return res;
}


Clear();
int[,] matrix = GetArray(3, 4, 0, 10); // Массив 3 строки, 4 столбца, рандом [0; 10]
PrintMatrix(matrix);
double[] averages = AverageInColumn(matrix);
WriteLine("Среднее арифметическое каждого столбца:");
WriteLine(String.Join(";  ", averages));