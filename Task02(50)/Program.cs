// Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве,
//  и возвращает значение этого элемента или же указание, что такого элемента нет.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// [1, 7] -> такого числа в массиве нет

using System;
using static System.Console;

// Ввод строки с консоли
string Prompt(string message)
{
    Write(message);
    string result = ReadLine()!;
    return result;
}

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
void PrintMatrix(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] >= 0)
                Write(" ");
            Write($"{array[i, j]} \t");
        }
        WriteLine();
    }
}

// Перевод строки в массив
int[] StringToIntArray(string stringValue)
{
    char[] separators = new char[] { ' ', '.', ',', '[', ']' };
    string[] stringArray = stringValue.Split(separators, System.StringSplitOptions.RemoveEmptyEntries);
    int[] result = new int[stringArray.Length];

    for (int i = 0; i < stringArray.Length; i++)
        result[i] = Convert.ToInt32(stringArray[i]) - 1; // Вычитаем 1 чтобы пользователь считал строки и столбцы матрицы начиная с 1, а не с 0

    return result;
}

// Проверка не выходит ли заданная позиция за размеры массива
bool BoundCheck(int[,] arr, int[] pos)
{
    if (pos[0] > arr.GetLength(0) - 1
     || pos[1] > arr.GetLength(1) - 1
     || pos[0] < 0
     || pos[1] < 0) return false;
    else return true;
}


Clear();
int[,] matrix = GetMatrix(3, 4, 0, 10); // Массив 3 строки, 4 столбца, рандом [0; 10].
PrintMatrix(matrix);
string coordinates = Prompt("Введите координаты элемента через пробел: ");
int[] position = StringToIntArray(coordinates);

if (BoundCheck(matrix, position))
    WriteLine(matrix[position[0], position[1]]);
else
    WriteLine("Такого числа в массиве нет");