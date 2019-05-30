//
//  Point.cs
//  Point
//
//  Created by Сорокин Дмитрий on 22/05/2019.
//  Copyright © 2019 Сорокин Дмитрий. All rights reserved.
//
using System;

namespace Lab5 {
    class MainClass {
        #region Model
        //Динамический одномерный массив
        static int[] array;// = new int[10];

        //Динамический двумерный массив
        static int[,] matrice;// = new int[10,10];

        //Динамический рванный массив
        static int[][] jagArray;// = new int[10][];

        #endregion
        #region View
        /// <summary>
        /// Получает целое число из введенной пользователем строки.
        /// </summary>
        /// <returns>Число, введенное пользователем</returns>
        /// <param name="message">Сообщение пользователю</param>
        public static int GetInt(string message = "") {
            int input;
            Console.WriteLine($"Введите пожалуйста {message}");
            while (!int.TryParse(Console.ReadLine(), out input)) {
                Console.WriteLine("Не удалось распознать число, повторите ввод");
            }
            return input;
        }
        /// <summary>
        /// Вызывает список команд меню и реализует взаимодействие с ним
        /// </summary>
        /// <returns>Выбранный пункт меню</returns>
        static int Menu() {
            int result;

            Console.WriteLine("Управление тремя массивами разных типов");
            Console.WriteLine("1 - Сформировать одномерный массив");
            Console.WriteLine("2 - Удалить первый четный элемент из одномерного массива");
            Console.WriteLine("3 - Сформировать двумерный массив");
            Console.WriteLine("4 - Добавить столбец в двумерный элемент");
            Console.WriteLine("5 - Сформировать рванный массив");
            Console.WriteLine("6 - Удалить самую длинную строку");
            Console.WriteLine("0 - Выход");

            result = GetInt("необходимый пункт меню");

            while (result < 0 || result > 6) {
                Console.WriteLine("Выбранного пункта меню не существует, повторите ввод");
                result = GetInt();
            }

            return result;
        }
        /// <summary>
        /// Выводит массив на экран
        /// </summary>
        /// <param name="array">Массив</param>
        static void PrintArray(int[] array) {
            string output = "";

            for (int i = 0; i < array.Length; i++)
                output += array[i].ToString() + " ";

            Console.WriteLine(output);
        }
        /// <summary>
        /// Выводит матрицу на экран
        /// </summary>
        /// <param name="matrice">Матрица</param>
        static void PrintMatrice(int[,] matrice) {
            for (int j = 0; j < matrice.GetLength(1); j++)
            {
                for (int i = 0; i < matrice.GetLength(0); i++)
                    Console.Write($"{matrice[i,j]} ");
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Выводит рванный массив на экран
        /// </summary>
        /// <param name="jagArray">Рванный массив</param>
        static void PrintJagArray(int[][] jagArray)
        {
            for (int i = 0; i < jagArray.Length; i++)
            {
                for (int j = 0; j < jagArray[i].Length; j++)
                    Console.Write($"{jagArray[i][j]} ");
                Console.WriteLine();
            }
        }
        #endregion
        #region Controller
        /// <summary>
        /// Создает массив
        /// </summary>
        /// <returns>Созданный массив</returns>
        /// <param name="ofSize">Размер массива</param>
        static int[] CreateArray(int ofSize = 0) {
            int[] temporaryArray = new int[ofSize];
            var random = new Random();

            for (int i = 0; i < temporaryArray.Length; i++) 
                temporaryArray[i] = random.Next(0, 9);

            return temporaryArray;
        }
        /// <summary>
        /// Удаляет первый четный элемент
        /// </summary>
        /// <returns>Возвращает измененный массив</returns>
        /// <param name="array">Массив, подлежащий изменению</param>
        static int[] DeleteFirstEven(int[] array) {
            int[] temporaryArray = new int[array.Length-1];
            int indexOfEven = -1;

            for (int i = 0; i < array.Length; i++)
                if (array[i] % 2 == 0) {
                    indexOfEven = i;
                    break;
                }

            if (indexOfEven != -1) 
                for (int i = 0; i < array.Length - 1; i++) {
                    if (i < indexOfEven)
                        temporaryArray[i] = array[i];
                    //Как только мы дошли до нужной позиции, 
                    //продолжаем копировать массив, исключив удаленный элемент
                    if (i >= indexOfEven)
                        temporaryArray[i] = array[i + 1];
                }

            return temporaryArray;
        }
        /// <summary>
        /// Создает матрицу
        /// </summary>
        /// <returns>Возвращает созданную матрицу</returns>
        /// <param name="sizeX">Кол-во строк</param>
        /// <param name="sizeY">Кол-во столбцов</param>
        static int[,] CreateMatrice(int sizeX = 0, int sizeY = 0) {
            int[,] temporaryMatrice = new int[sizeX, sizeY];
            var random = new Random();

            for (int i = 0; i < sizeX; i++)
                for (int j = 0; j < sizeY; j++)
                    temporaryMatrice[i, j] = random.Next(0,9);

            return temporaryMatrice;
        }
        /// <summary>
        /// Добавляет столбец в матрицу
        /// </summary>
        /// <returns>Изменную матрицу</returns>
        /// <param name="matrice">Матрица</param>
        /// <param name="to">Индекс столбца</param>
        static int[,] AddColumn(int[,] matrice, int to) {
            int[,] temporaryMatrice = new int[matrice.GetLength(0)+1,matrice.GetLength(1)];
            var random = new Random();
            for (int i = 0; i < temporaryMatrice.GetLength(0); i++) {
                if (i < to)
                    for (int j = 0; j < temporaryMatrice.GetLength(1); j++)
                        temporaryMatrice[i, j] = matrice[i, j];
                else if (i == to)
                    for (int j = 0; j < temporaryMatrice.GetLength(1); j++)
                        temporaryMatrice[i, j] = random.Next(0, 9);
                else
                    for (int j = 0; j < temporaryMatrice.GetLength(1); j++)
                        temporaryMatrice[i, j] = matrice[i-1, j];
            }
            return temporaryMatrice;
        }
        /// <summary>
        /// Создает рванный массив
        /// </summary>
        /// <returns>Возвращает созданный рванный массив</returns>
        /// <param name="size">Кол-во строк</param>
        static int[][] CreateJagArray(int size = 0)
        {
            int[][] temporaryJagArray = new int[3][]
            {
                new int [] {1,2,3},
                new int [] {1,2,3,4},
                new int [] {1,2,3,4,5}
            };
            var random = new Random();

            for (int i = 0; i < temporaryJagArray.Length; i++)
                for (int j = 0; j < temporaryJagArray[i].Length; j++)
                    temporaryJagArray[i][j] = random.Next(0,9);

            return temporaryJagArray;
        }
        /// <summary>
        /// Удаляет самую длинную строку
        /// </summary>
        /// <returns>Измененный рванный массив</returns>
        /// <param name="jagArray">Рванный массив</param>
        static int[][] RemoveLongestString(int[][] jagArray) {
            int[][] temporaryJagArray = new int[jagArray.Length-1][];

            //Определяем позицию самой длинной строки
            var longestPos = 0;
            var longestSum = 0;
            for (int i = 0; i < jagArray.Length; i++) {
                var sum = 0;
                foreach (int element in jagArray[i])
                    sum++;
                if (longestSum < sum) {
                    longestSum = sum;
                    longestPos = i;
                }
            }

            for (int i = 0; i <temporaryJagArray.Length; i++)
            {
                if (i < longestPos)
                for (int j = 0; j < jagArray[i].Length; j++)
                {
                        temporaryJagArray[i] = jagArray[i];
                }
                if (i >= longestPos)
                    for (int j = 0; j < jagArray[i].Length; j++)
                        temporaryJagArray[i] = jagArray[i + 1];
            }

            return temporaryJagArray;
        }
        #endregion
        public static void Main(string[] args) {
            int input = Menu();
            while (input != 0) {
                switch (input) {
                    //Формирует одномерный массив
                    case 1:
                        var size = GetInt("размерность массива");
                        array = CreateArray(ofSize: size);
                        Console.WriteLine("Массив успешно создан");
                        PrintArray(array);
                        Console.ReadKey();
                        break;
                    //Удаляет первый четный элемент
                    case 2:
                        array = DeleteFirstEven(array);
                        Console.WriteLine("Первый четный элемент успешно удален");
                        PrintArray(array);
                        Console.ReadKey();
                        break;
                    //Формирует двумерный массив
                    case 3:
                        var sizeX = GetInt("кол-во строк матрицы");
                        var sizeY = GetInt("кол-во столбцов матрицы");

                        matrice = CreateMatrice(sizeX, sizeY);

                        Console.WriteLine("Матрицы успешно создана");
                        PrintMatrice(matrice);
                        Console.ReadKey();

                        break;
                    //Добавляет столбец в указанную позицию
                    case 4:
                        matrice = AddColumn(matrice, GetInt("номер столбца"));
                        Console.WriteLine("Столбец успешно вставлен");
                        PrintMatrice(matrice);
                        Console.ReadKey();
                        break;
                    //Формирует рванный массив
                    case 5:
                        var sizeOf = 3;//GetInt("кол-во строк рванного массива");

                        jagArray = CreateJagArray(sizeOf);

                        Console.WriteLine("Рванный массив успешно создан");
                        PrintJagArray(jagArray);
                        Console.ReadKey();
                        break;
                    //Удаляет самую длинную строку
                    case 6:
                        jagArray = RemoveLongestString(jagArray);
                        Console.WriteLine("Самая длинная строка успешно удалена");
                        PrintJagArray(jagArray);
                        Console.ReadKey();
                        break;
                }
                input = Menu();
            }
        }
    }
}
