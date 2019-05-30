//
//  Point.cs
//  Point
//
//  Created by Сорокин Дмитрий on 23/05/2019.
//  Copyright © 2019 Сорокин Дмитрий. All rights reserved.
//
using System;

namespace Lab6
{
    class MainClass
    {
        #region Model
        //Одномерный массив чисел
        static int[] array;
        //Текст, представленный массивом слов
        static string[] text;
        #endregion
        #region View
        /// <summary>
        /// Получает целое число из введенной пользователем строки.
        /// </summary>
        /// <returns>Число, введенное пользователем</returns>
        /// <param name="message">Сообщение пользователю</param>
        public static int GetInt(string message = "")
        {
            int input;
            Console.WriteLine($"Введите пожалуйста {message}");
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Не удалось распознать число, повторите ввод");
            }
            return input;
        }
        /// <summary>
        /// Вызывает список команд меню и реализует взаимодействие с ним
        /// </summary>
        /// <returns>Выбранный пункт меню</returns>
        static int Menu()
        {
            int result;

            Console.WriteLine("Что-то очень нужное");
            Console.WriteLine("1 - Сформировать одномерный массив");
            Console.WriteLine("2 - Отсортировать по убыванию четные элементы");
            Console.WriteLine("3 - Сформировать новую строку");
            Console.WriteLine("4 - Перевернуть каждое нечетное предложение");
            Console.WriteLine("0 - Выход");

            result = GetInt("необходимый пункт меню");

            while (result < 0 || result > 4)
            {
                Console.WriteLine("Выбранного пункта меню не существует, повторите ввод");
                result = GetInt();
            }

            return result;
        }
        /// <summary>
        /// Выводит на экран массив
        /// </summary>
        /// <param name="array">Массив</param>
        static void PrintArray(int[] array)
        {
            foreach (int element in array)
                Console.Write($"{element} ");
            Console.WriteLine();
        }
        /// <summary>
        /// Выводит на экран текст с подстветкой предложений
        /// </summary>
        /// <param name="text">Текст</param>
        static void PrintText(string[] text)
        {
            foreach (string element in text)
            {
                Console.Write($"{element}");
                if (element.EndsWith(".", StringComparison.CurrentCultureIgnoreCase)
                     || element.EndsWith("!", StringComparison.CurrentCultureIgnoreCase)
                     || element.EndsWith("?", StringComparison.CurrentCultureIgnoreCase))
                    switch (Console.ForegroundColor)
                    {
                        case ConsoleColor.White:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case ConsoleColor.Blue:
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case ConsoleColor.Green:
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
        #endregion
        #region Controller
        /// <summary>
        /// Создает новый одномерный массив
        /// </summary>
        /// <returns>Одномерный массив чисел</returns>
        /// <param name="mode">0 - ввод чисел с клавиатуры, 1 - ДСЧ</param>
        /// <param name="length">Длина создаваемого массива</param>
        static int[] CreateNewArray(int mode = 1, int length = 0)
        {
            int[] array = new int[length];
            var random = new Random();

            switch (mode)
            {
                case 0:
                    for (int i = 0; i < array.Length; i++)
                        array[i] = GetInt($"элемент массива номер {i}");
                    break;
                case 1:
                    for (int i = 0; i < array.Length; i++)
                        array[i] = random.Next(1, 9);
                    break;
                default:
                    array = null;
                    break;
            }

            return array;
        }
        /// <summary>
        /// Сортирует четные элементы в массиве по убыванию, оставляя нечетные на своих местах
        /// </summary>
        /// <returns>Отсортированный массив</returns>
        /// <param name="array">Сортируемый массив</param>
        static int[] SortEvenInArray(int[] array)
        {
            int countOfEven = 0;
            int[] evenElements;
            int[] indexofEven;

            foreach (int element in array)
                if (element % 2 == 0)
                    countOfEven++;

            evenElements = new int[countOfEven];
            indexofEven = new int[countOfEven];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    evenElements[countOfEven - 1] = array[i];
                    indexofEven[countOfEven - 1] = i;
                    countOfEven--;
                }
            }

            Array.Sort(evenElements);
            //#PrintArray(evenElements);

            for (int i = 0; i < indexofEven.Length; i++) {
                array[indexofEven[i]] = evenElements[evenElements.Length-1-i];
            }

            return array;
        }
        /// <summary>
        /// Получает разбитый на предложения текст
        /// </summary>
        /// <returns>Разбитый на предложения текст</returns>
        /// <param name="input">Введенная строка</param>
        public static string[] GetSentence(string input)
        {
            string[] sentence = input.Split(' ');

            for (int i = 0; i < sentence.Length; i++)
            {
                sentence[i] = " " + sentence[i];
            }

            return sentence;
        }
        /// <summary>
        /// Переворачивает нечетные предложения в тексте
        /// </summary>
        /// <returns>Измененный текст</returns>
        /// <param name="text">Текст</param>
        static string[] MirrorNotEvenSentences(string[] text)
        {
            //Счетчик предложений
            int currentSentence = 0;
            //Позиция начала данного предложения
            int startOfCurrentSentence = 0;
            //Позиция конца данного предложения
            int endOfCurrentSentence = 0;

            //С каждым словом из этого текста
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].EndsWith(".", StringComparison.CurrentCultureIgnoreCase)
                     || text[i].EndsWith("!", StringComparison.CurrentCultureIgnoreCase)
                     || text[i].EndsWith("?", StringComparison.CurrentCultureIgnoreCase))
                {
                    //Увеличиваем счетчик предложений
                    currentSentence++;
                    //Теперь мы знаем позицию конца предложения
                    endOfCurrentSentence = i;
                    //Если предложение по счету нечетное
                    if (currentSentence % 2 != 0)
                    {
                        //Счетчик цикла
                        int count = -1;
                        //То переворачиваем
                        for (int j = startOfCurrentSentence; j < endOfCurrentSentence - (endOfCurrentSentence - startOfCurrentSentence)/2; j++)
                        {
                            //Увеличиваем счетчик прокруток цикла
                            count++;
                            //Сохраняем значение j-того элемента
                            string temporaryString = text[j];
                            //Меняем местами два зеркально стоящих элемента
                            text[j] = text[endOfCurrentSentence - count];
                            //Присваиваем сохраненное ранее значение
                            text[endOfCurrentSentence - count] = temporaryString;
                        }
                    }
                    //Разбираемся со знаками препинания
                    //Сохраняем знак
                    char sign = text[startOfCurrentSentence][text[startOfCurrentSentence].Length - 1];
                    //Из бывшего конца (сейчас - начала) убираем знак препинания
                    text[startOfCurrentSentence] = text[startOfCurrentSentence].Remove(text[startOfCurrentSentence].Length-1);
                    //В бывшее начало (сейчас - конец) ставим убранный знак
                    text[endOfCurrentSentence] += sign;
                    //Начало следующего предложения
                    startOfCurrentSentence = endOfCurrentSentence + 1;
                }
            }
            return text;
        }
        #endregion
        public static void Main(string[] args)
        {
            int input = Menu();
            while (input != 0)
            {
                switch (input)
                {
                    case 1:
                        int mode = GetInt("способ заполнения элементов массива. 0 - с клавиатуры, 1 - датчиком случайных чисел");
                        int length = GetInt("длину массива");

                        array = CreateNewArray(mode, length);

                        Console.WriteLine("Одномерный массив успешно создан");
                        PrintArray(array);
                        Console.ReadKey();
                        break;
                    case 2:
                        array = SortEvenInArray(array);

                        Console.WriteLine("Массив успешно отсортирован");
                        PrintArray(array);
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Введите пожалуйста строку с несколькими предложениями");
                        var str = Console.ReadLine();
                        text = GetSentence(str);

                        Console.WriteLine("Строка успешно сформирована");
                        PrintText(text);
                        Console.ReadKey();
                        break;
                    case 4:
                        text = MirrorNotEvenSentences(text);

                        Console.WriteLine("Нечетные предложения успешно перевернуты");
                        PrintText(text);
                        Console.ReadKey();
                        break;
                }
                input = Menu();
            }
        }
    }
}
