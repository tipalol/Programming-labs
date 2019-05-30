//
//  Point.cs
//  Point
//
//  Created by Сорокин Дмитрий on 22/05/2019.
//  Copyright © 2019 Сорокин Дмитрий. All rights reserved.
//
using System;

namespace Lab4 {
    class MainClass {
        #region Model
        /// <summary>
        /// Класс <see cref="SmartArray"/> реализует массив типа <see cref="int"/>, в котором можно выполнять операции поиска,
        /// сортировки, добавления и удаления элементов массива
        /// </summary>
        class SmartArray {
            public int[] Array { get; private set; }
            public SmartArray(int ofSize) {
                Array = new int[ofSize];
                length = ofSize;
            }
            /// <summary>
            /// Кол-во элементов в массиве
            /// </summary>
            public int length;
            /// <summary>
            /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Lab4.MainClass.SmartArray"/>.
            /// </summary>
            /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Lab4.MainClass.SmartArray"/>.</returns>
            public override string ToString() {
                string output = "";

                foreach (int element in Array)
                    output += element + " ";

                return output;
            }
            /// <summary>
            /// Gets or sets the <see cref="T:Lab4.MainClass.SmartArray"/> at the specified index.
            /// </summary>
            /// <param name="index">Индекс</param>
            public int this [int index]
            {
                get { return Array[index]; }
                set { Array[index] = value; }
            }
            /// <summary>
            /// Устанавливает значение <paramref name="number"/> элемента массива в указанной позиции <paramref name="at"/>
            /// </summary>
            /// <returns>Возвращает <see langword="null"/>, если операция прошла успешно, или <see cref="Exception"/>, если произошла ошибка</returns>
            /// <param name="number">Значение</param>
            /// <param name="at">Позиция в массиве</param>
            public Exception Set(int number, int at) {
                try {
                    Array[at] = number;
                    return null;
                } catch (Exception e) {
                    return e;
                }
            }
            /// <summary>
            /// Добавляет элемент <paramref name="number"/> в указанную позицию <paramref name="at"/>
            /// </summary>
            /// <returns>Возвращает <see langword="null"/>, если произошла ошибка, или <see cref="Exception"/>, если произошла ошибка</returns>
            /// <param name="number">Number.</param>
            /// <param name="at">At.</param>
            public Exception Add(int number, int at) {
                try {
                    //Формируем временный массив
                    var temporaryArray = new int[Array.Length+1];

                    for (int i = 0; i <= Array.Length; i++) {
                        if (i == at)
                            temporaryArray[i] = number;
                        else if (i < at)
                            temporaryArray[i] = Array[i];
                        else
                            temporaryArray[i] = Array[i - 1];
                    }

                    Array = temporaryArray;
                    length++;
                    return null;
                } catch (Exception e) {
                    return e;
                }
            }
            /// <summary>
            /// Удаляет элемент  из указанной позиции <paramref name="at"/>
            /// </summary>
            /// <returns>Возвращает <see langword="null"/>, если операция прошла успешно, или <see cref="Exception"/>, если произошла ошибка</returns>
            /// <param name="at">Позиция в массиве</param>
            public Exception Remove(int at) {
                try {
                    //Формируем временный массив
                    var temporaryArray = new int[Array.Length-1];

                    for (int i = 0; i < Array.Length-1; i++) {
                        if (i < at)
                            temporaryArray[i] = Array[i];
                        //Как только мы дошли до нужной позиции, 
                        //продолжаем копировать массив, исключив удаленный элемент
                        if (i >= at)
                            temporaryArray[i] = Array[i + 1];
                    }
                    Array = temporaryArray;
                    length--;
                    return null;
                } catch (Exception e) {
                    return e;
                }
            }
            /// <summary>
            /// Находит максимальный элемент в массиве
            /// </summary>
            /// <returns>Возвращает максимальный элемент в массиве или <see langword="int.MinValue"/>, если массив пуст</returns>
            public int Max() {
                int result = int.MinValue;
                if (Array != null && Array.Length > 0) {
                    //Предполагаем, что максимальный элемент - первый
                    var max = Array[0];

                    foreach (int element in Array)
                        if (element > max)
                            max = element;

                    result = max;
                }
                return result;
            }
            /// <summary>
            /// Находит минимальный элемент в массиве
            /// </summary>
            /// <returns>Возвращает минимальный элемент в массиве или <see langword="int.MaxValue"/>, если массив пуст</returns>
            public int Min() {
                int result = int.MaxValue;
                if (Array != null && Array.Length > 0)
                {
                    //Предполагаем, что минимальный элемент - первый
                    var min = Array[0];

                    foreach (int element in Array)
                        if (element < min)
                            min = element;

                    result = min;
                }
                return result;
            }
            /// <summary>
            /// Находит первую позицию на которой находится искомое число
            /// </summary>
            /// <returns>Возвращает первую позицию на которой находится искомое число</returns>
            /// <param name="number">Искомое число</param>
            public int Find(int number)
            {
                int result = -1;
                for (int i = 0; i < Array.Length; i++)
                    if (Array[i] == number) {
                        result = i;
                        break;
                    }
                return result;
            }
        }
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
        public static int Menu()
        {
            int result;

            Console.Clear();
            Console.WriteLine("Управление массивом v1.0");
            Console.WriteLine("1 - Сформировать массив");
            Console.WriteLine("2 - Вывести массив");
            Console.WriteLine("3 - Удалить элемент");
            Console.WriteLine("4 - Добавить элемент");
            Console.WriteLine("5 - Перевернуть массив");
            Console.WriteLine("6 - Найти первый четный элемент");
            Console.WriteLine("7 - Выполнить сортировку простым обменом");
            Console.WriteLine("8 - Удалить максимальный элемент в массиве");
            Console.WriteLine("9 - Добавить К элементов в начало массива");
            Console.WriteLine("0 - Выход");

            result = GetInt("необходимый пункт меню");

            while (result < 0 || result > 9)
            {
                Console.WriteLine("Выбранного пункта меню не существует, повторите ввод");
                result = GetInt();
            }

            return result;
        }
        /// <summary>
        /// Выводит массив <see cref="SmartArray"/> на экран
        /// </summary>
        /// <param name="array">Массив</param>
        static void PrintArray(SmartArray array) {
            Console.WriteLine(array);
        }
        #endregion
        #region Controller
        /// <summary>
        /// Реализует создание нового объекта класса <see cref="SmartArray"/>
        /// </summary>
        /// <returns>Созданный объект класса <see cref="SmartArray"/></returns>
        /// <param name="size">Размер массива</param>
        static SmartArray CreateNewArray(int size) {
            var array = new SmartArray(size);
            var random = new Random();

            for (int i = 0; i < array.length; i++)
                array[i] = random.Next(0, 10);

            return array;
        }
        /// <summary>
        /// Переворачивает массив
        /// </summary>
        /// <returns>Возвращает перевернутый массив</returns>
        /// <param name="array">Массив</param>
        static SmartArray MirrorArray(SmartArray array) {
            int temporaryInt;
            for (int i = 0; i < array.length/2; i++) {
                temporaryInt = array[i];
                array[i] = array[array.length-i-1];
                array[array.length-i-1] = temporaryInt;
            }
            return array;
        }
        /// <summary>
        /// Находит первое четное число в массиве
        /// </summary>
        /// <returns>Первое четное число в массиве</returns>
        /// <param name="at">Массив</param>
        static int FindFirstEven(SmartArray at) {
            int even = 1;
            for (int i = 0; i < at.length; i++)
                if (at[i] % 2 == 0) {
                    even = at[i];
                    break;
                }

            return even;
        }
        /// <summary>
        /// Сортирует массив методом простого обмена
        /// </summary>
        /// <returns>Возвращает массив</returns>
        /// <param name="array">Сортируемый массив</param>
        static SmartArray SortArray(SmartArray array) {
            for (int i = 0; i < array.length-1; i++) {
                if (array[i] > array[i+1]) {
                    int temporaryInt = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temporaryInt;
                    i -= i+1;
                }
            }
            return array;
        }
        #endregion
        public static void Main() {
            SmartArray array = new SmartArray(0);
            int input = Menu();
            while (input != 0) {
                switch (input) {
                    //Формируем массив
                    case 1:
                        int size = GetInt("кол-во элементов массива");
                        array = CreateNewArray(size);
                        Console.WriteLine("Массив успешно сформирован");
                        PrintArray(array);
                        Console.ReadKey();
                        break;
                    //Выводим массив на экран
                    case 2:
                        PrintArray(array);
                        Console.ReadKey();
                        break;
                    //Удаляем элемент в указанном индексе
                    case 3:
                        PrintArray(array);
                        array.Remove( 
                            at: GetInt("индекс удаляемого элемента")-1
                            );
                        Console.WriteLine("Элемент успешно удален");
                        PrintArray(array);
                        Console.ReadKey();
                        break;
                    //Добавляем элемент в массив
                    case 4:
                        PrintArray(array);
                        array.Add(
                            number: GetInt("значение добавляемого элемента"),
                            at: GetInt("позицию для добавления")-1
                            );
                        Console.WriteLine("Элемент успешно добавлен в массив");
                        PrintArray(array);
                        Console.ReadKey();
                        break;
                    //Переворачиваем массив
                    case 5:
                        array = MirrorArray(array);
                        Console.WriteLine("Массив успешно перевернут");
                        PrintArray(array);
                        Console.ReadKey();
                        break;
                    //Находим первое четное число в массиве
                    case 6:
                        var even = FindFirstEven(at: array);
                        if (even == 1)
                            Console.WriteLine("В массиве отсутствуют четные числа");
                        else
                            Console.WriteLine($"Первое четное число в массиве: {even}");
                        Console.ReadKey();
                        break;
                    //Сортируем массив простым обменом
                    case 7:
                        array = SortArray(array);
                        Console.WriteLine("Массив успешно отсортирован");
                        PrintArray(array);
                        Console.ReadKey();
                        break;
                    //Удаляем максимальный элемент из массива
                    case 8:
                        array.Remove( array.Find( array.Max() ));
                        Console.WriteLine("Максимальный успешно элемент удален");
                        PrintArray(array);
                        Console.ReadKey();
                        break;
                    //Добавляем К элементов в начало массива
                    case 9:
                        int k = GetInt("кол-во добавляемых элементов");
                        int position = 1;//GetInt("позицию, в которую необходимо вставить элементы");
                        var random = new Random();

                        for (int i = 0; i < k; i++)
                            array.Add(
                                number: random.Next(0,20),
                                at: position
                                );

                        Console.WriteLine($"{k} элементов успешно добавлены");
                        PrintArray(array);
                        Console.ReadKey();
                        break;
                    case 0:
                        break;
                    default:
                        break;
                }
                input = Menu();
            }
        }
    }
}
