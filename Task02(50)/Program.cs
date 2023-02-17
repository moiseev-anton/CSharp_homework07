// Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве,
//  и возвращает значение этого элемента или же указание, что такого элемента нет.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// [1, 7] -> такого числа в массиве нет

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
void PrintArray(int[,] arr)
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

// Метод перевода строки в целочисленный массив
int[] StringToIntArray(string stringValue)
{
    char[] separators = new char[] {' ', '.', ',',  };
    string[] stringArray = stringValue.Split(separators, System.StringSplitOptions.RemoveEmptyEntries);
    int[] result = new int[stringArray.Length];

    for (int i = 0; i < stringArray.Length; i++)
        result[i] = Convert.ToInt32(stringArray[i]) - 1; // Вычитаем 1 чтобы пользователь считал строки и столбцы матрицы начиная с 1, а не с 0

    return result;
}

// Метод проверяет не выходит ли заданная позиция за размеры массива
bool CheckPosition(int[] nums, int[,] arr)
{
    if (nums[0] > arr.GetLength(0) - 1
     || nums[1] > arr.GetLength(1) - 1
     || nums[0] < 0
     || nums[1] < 0) return false;
    else return true;
}


Clear();
int[,] array = GetArray(3, 4, -10, 10); // Массив 3 строки, 4 столбца, рандом [-10; 10]
PrintArray(array);
Write("Введите координаты элемента: ");
string coordinates = ReadLine()!;
int[] position = StringToIntArray(coordinates);

if (position.Length < 2) // Если введено меньше 2 чисел, то ошибка, если больше, взяты будут только первые 2
    WriteLine("Координаты введены не корректно");
else if (CheckPosition(position, array))
    WriteLine(array[position[0], position[1]]);
else
    WriteLine("Такого числа в массиве нет");