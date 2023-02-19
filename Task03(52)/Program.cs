// Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.

using System;
using static System.Console;

// Заполнение двумерного массива
int[,] GetMatrix(int m, int n, int minVal, int maxVal)
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
            if (arr[i, j] >= 0)
                Write(" ");
            Write($"{arr[i, j]} \t");
        }
        WriteLine();
    }
}

// Подсчет среднего арифметического по столбцам
double[] GetColumnAverages(int[,] array)
{
    double[] res = new double[array.GetLength(1)];

    for (int j = 0; j < array.GetLength(1); j++)
    {
        double sum = 0;

        for (int i = 0; i < array.GetLength(0); i++)
            sum += array[i, j];

        res[j] = sum / array.GetLength(0);
    }
    return res;
}

// Вывод одномерного массива
void PrintArray(double[] arr)
{
    foreach (double i in arr)
        Write($"{i:f1}\t");
}


Clear();
int[,] matrix = GetMatrix(3, 4, 0, 10); // Массив 3 строки, 4 столбца, рандом [0; 10]
PrintMatrix(matrix);
double[] averages = GetColumnAverages(matrix);
WriteLine("Среднее арифметическое каждого столбца:");
PrintArray(averages);