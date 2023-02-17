// Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
// m = 3, n = 4.
// 0,5 7 -2 -0,2
// 1 -3,3 8 -9,9
// 8 7,8 -7,1 9

using System;
using static System.Console;

// Заполнение двумерного массива
double[,] GetArray(int m, int n, int minVal, int maxVal)
{
    double[,] result = new double[m, n];

    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().NextDouble() * (maxVal - minVal) + minVal;
        }
    }
    return result;
}

// Вывод двумерного массива
void PrintArray(double[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            if (arr[i, j] < 0) // Если число положительное, то перед ним добавим пробел(чтобы столбцы ровно выводились относительно отрицательных)
                Write($"{arr[i, j]:f1} \t");
            else
                Write($" {arr[i, j]:f1} \t");
        }
        WriteLine();
    }
}

Clear();
Write("Введите количество строк = ");
int rows = Convert.ToInt32(ReadLine());
Write("Введите количество столбцов = ");
int columns = Convert.ToInt32(ReadLine());
PrintArray(GetArray(rows, columns, -10, 10));