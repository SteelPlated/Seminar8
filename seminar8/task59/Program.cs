/*Задача 59: Задайтедвумерный массив из целых чисел.
Напишите программу, которая удалит строку и столбец, на
пересечении которых расположен наименьший элемент
массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Наименьший элемент - 1, на выходе получим
следующий массив:
9 4 2
2 2 6
3 4 7
*/
int[,] GetArray(int a, int b)
{
    int[,] array = new int[a, b];
    Random rndNum = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = rndNum.Next(10);
        }
    }
    return array;
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
}

int[] Min(int[,] array)
{
    int min = 0;
    int indexI = 0;
    int indexJ = 0;

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (min > array[i, j])
            {
                min = array[i, j];
                indexI = i;
                indexJ = j;
            }
        }
    }
    return new int[] { indexI, indexJ, min };
}

int[,] ResultMatrix(int[,] matrix, int[] idxs)
{
    int flagI = 0;
    int flagJ = 0;
    int[,] newMatrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
    for (int i = 0; i < matrix.GetLength(0) - 1; i++)
    {
        for (int j = 0; j < matrix.GetLength(1) - 1; j++)
        {
            if (i >= idxs[0]) { flagI = 1; }
            else { flagI = 0; }
            if (i >= idxs[1]) { flagJ = 1; }
            else { flagJ = 0; }
            newMatrix[i, j] = matrix[i + flagI, j + flagJ];
        }
    }
    return newMatrix;
}

int[,] matrix = GetArray(5, 5);
PrintArray(matrix);
Console.WriteLine();
int[] indexes = Min(matrix);
Console.WriteLine($"Min = {indexes[2]}");
int[,] resultArray = ResultMatrix(matrix, indexes);
PrintArray(resultArray);