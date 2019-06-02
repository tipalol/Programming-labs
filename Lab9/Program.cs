//
//  Program.cs
//  Program
//
//  Created by Сорокин Дмитрий on 01/06/2019.
//  Copyright © 2019 Сорокин Дмитрий. All rights reserved.
//
using System;

namespace Lab9
{
    class MainClass
    {
        #region Модель
        static Time[] timeList = new Time[3];
        static TimeArray timeArray;
        #endregion
        #region Представление
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

            Console.WriteLine("Управление временем");
            Console.WriteLine("1 - Добавить секунды");
            Console.WriteLine("2 - Добавить минуту");
            Console.WriteLine("3 - Вычесть минуту");
            Console.WriteLine("4 - Привести к int");
            Console.WriteLine("5 - Привести к bool");
            Console.WriteLine("6 - Сложить времена");
            Console.WriteLine("7 - Отнять времена");
            Console.WriteLine("8 - Найти среднее арифмитическое");
            Console.WriteLine("9 - Создать массив времен");
            Console.WriteLine("0 - Выход");

            Console.WriteLine();

            Console.WriteLine($"Пример времени: {timeList[0]}");
            Console.WriteLine($"Другое время: {timeList[1]}");
            Console.WriteLine($"Время прямо сейчас: {timeList[2]}");

            result = GetInt("необходимый пункт меню");

            while (result < 0 || result > 9)
            {
                Console.WriteLine("Выбранного пункта меню не существует, повторите ввод");
                result = GetInt();
            }

            return result;
        }
        #endregion
        #region Контроллер
        /// <summary>
        /// Вычисляет среднее арифмитическое по минутам
        /// </summary>
        /// <returns>Среднее арифмитическое по минутам</returns>
        /// <param name="array">Массив</param>
        static double CalculateAverage(TimeArray array)
        {
            int sum = 0;
            for (int i = 0; i < array.Size; i++)
            {
                sum += array[i].Minutes;
            }
            return sum / array.Size;
        }
        #endregion
        public static void Main(string[] args)
        {
            timeList[0] = new Time(6, 20, 0);
            timeList[1] = new Time(16, 45, 55);
            timeList[2] = new Time(DateTime.Now);
            timeArray = new TimeArray(timeList);
            int input = Menu();
            while (input != 0)
            {
                switch (input)
                {
                    case 1:
                        int currentTime_ = GetInt("время, с которым нужно работать (1, 2 или 3)")+1;
                        if (currentTime_ > 0 && currentTime_ < 4)
                        {
                            timeList[currentTime_-1].AddSeconds(GetInt("кол-во добавляемых секунд"));
                            Console.WriteLine("Время успешно добавлено");
                        } else
                            Console.WriteLine("Такого времени нет. Возможные варианты были: 1, 2 или 3");
                        Console.ReadKey();
                        break;
                    case 2:
                        int currentTimeToAddOneMinute = GetInt("время, с которым нужно работать (1, 2 или 3)");
                        if (currentTimeToAddOneMinute > 0 && currentTimeToAddOneMinute < 4)
                        {
                            timeList[currentTimeToAddOneMinute-1]++;
                            Console.WriteLine("Минута успешно добавлена");
                        }
                        else
                            Console.WriteLine("Такого времени нет. Возможные варианты были: 1, 2 или 3");
                        Console.ReadKey();
                        break;
                    case 3:
                        int currentTimeToMinusOneMinute = GetInt("время, с которым нужно работать (1, 2 или 3)");
                        if (currentTimeToMinusOneMinute > 0 && currentTimeToMinusOneMinute < 4)
                        {
                            timeList[currentTimeToMinusOneMinute-1]--;
                            Console.WriteLine("Минута успешно убавлена");
                        }
                        else
                            Console.WriteLine("Такого времени нет. Возможные варианты были: 1, 2 или 3");
                        Console.ReadKey();
                        break;
                    case 4:
                        int currentTimeToInt = GetInt("время, с которым нужно работать (1, 2 или 3)");
                        if (currentTimeToInt > 0 && currentTimeToInt < 4)
                        {
                            Console.WriteLine($"Приведенное к int время{(int) timeList[currentTimeToInt-1]}");
                        }
                        else
                            Console.WriteLine("Такого времени нет. Возможные варианты были: 1, 2 или 3");
                        Console.ReadKey();
                        break;
                    case 5:
                        int currentTimeToBool = GetInt("время, с которым нужно работать (1, 2 или 3)");
                        if (currentTimeToBool > 0 && currentTimeToBool < 4)
                        {
                            Console.WriteLine($"Приведенное к bool время{false || timeList[currentTimeToBool-1]}");
                        }
                        else
                            Console.WriteLine("Такого времени нет. Возможные варианты были: 1, 2 или 3");
                        Console.ReadKey();
                        break;
                    case 6:
                        int firstTimeToPlus = GetInt("первое слагаемое");
                        if (firstTimeToPlus > 0 && firstTimeToPlus < 4)
                        {
                            int secondTimeToPlus = GetInt("второе слагаемое");
                            if (secondTimeToPlus > 0 && secondTimeToPlus < 4)
                            {
                                Console.WriteLine($"Результат сложения: {timeList[firstTimeToPlus-1] + timeList[secondTimeToPlus-1]}");
                            } else
                                Console.WriteLine("Такого времени нет. Возможные варианты были: 1, 2 или 3");
                        } else Console.WriteLine("Такого времени нет. Возможные варианты были: 1, 2 или 3");
                        Console.ReadKey();
                        break;
                    case 7:
                        int firstTimeToMinus = GetInt("первое слагаемое");
                        if (firstTimeToMinus > 0 && firstTimeToMinus < 4)
                        {
                            int secondTimeToPlus = GetInt("второе слагаемое");
                            if (secondTimeToPlus > 0 && secondTimeToPlus < 4)
                            {
                                Console.WriteLine($"Результат вычитания: {timeList[firstTimeToMinus-1] - timeList[secondTimeToPlus-1]}");
                            }
                            else
                                Console.WriteLine("Такого времени нет. Возможные варианты были: 1, 2 или 3");
                        }
                        else Console.WriteLine("Такого времени нет. Возможные варианты были: 1, 2 или 3");
                        Console.ReadKey();
                        break;
                    case 8:
                        Console.WriteLine($"Среднее арифмитическое минут: {CalculateAverage(timeArray)}");
                        Console.ReadKey();
                        break;
                    case 9:
                        int mode = GetInt("способ создания (0 - генератор случайных чисел, 1 - с клавиатуры");
                        int size = GetInt("размер создаваемого массива");
                        try
                        {
                            timeArray = new TimeArray(mode, size);
                            Console.WriteLine("Массив успешно создан");
                        } catch (Exception exception)
                        {
                            Console.WriteLine($"Произошла ошибка: {exception.Message}");
                        }
                        Console.ReadKey();
                        break;
                }
                input = Menu();
                Console.Clear();
            }
        }   
    }
}
