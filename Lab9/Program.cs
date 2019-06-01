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
        static Time exampleTime = new Time(6, 20, 0);
        static Time anotherTime = new Time(16, 45, 55);
        static Time currentTime = new Time(DateTime.Now);
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
            Console.WriteLine("0 - Выход");

            Console.WriteLine();

            Console.WriteLine($"Пример времени: {exampleTime}");
            Console.WriteLine($"Другое время: {anotherTime}");
            Console.WriteLine($"Время прямо сейчас: {currentTime}");

            result = GetInt("необходимый пункт меню");

            while (result < 0 || result > 8)
            {
                Console.WriteLine("Выбранного пункта меню не существует, повторите ввод");
                result = GetInt();
            }

            return result;
        }
        #endregion
        #region Контроллер

        #endregion
        public static void Main(string[] args)
        {
            int input = Menu();
            while (input != 0)
            {
                switch (input)
                {
                    case 1:
                        int currentTime_ = GetInt("время, с которым нужно работать (1, 2 или 3)");
                        switch (currentTime_)
                        {
                            case 1:
                                exampleTime.AddSeconds(GetInt("кол-во добавляемых секунд"));
                                break;
                            case 2:
                                anotherTime.AddSeconds(GetInt("кол-во добавляемых секунд"));
                                break;
                            case 3:
                                currentTime.AddSeconds(GetInt("кол-во добавляемых секунд"));
                                break;
                            default:
                                Console.WriteLine("Такого варианта не было, выберите варианты от 1 до 3");
                                break;
                        }
                        Console.WriteLine("Время успешно добавлено");
                        Console.ReadKey();
                        break;
                    case 2:
                        int currentTimeToAddOneMinute = GetInt("время, с которым нужно работать (1, 2 или 3)");
                        switch (currentTimeToAddOneMinute)
                        {
                            case 1:
                                exampleTime++;
                                break;
                            case 2:
                                anotherTime++;
                                break;
                            case 3:
                                currentTime++;
                                break;
                            default:
                                Console.WriteLine("Такого варианта не было, выберите варианты от 1 до 3");
                                break;
                        }
                        Console.WriteLine("Время успешно увеличено на 1 минуту");
                        Console.ReadKey();
                        break;
                    case 3:
                        int currentTimeToMinusOneMinute = GetInt("время, с которым нужно работать (1, 2 или 3)");
                        switch (currentTimeToMinusOneMinute)
                        {
                            case 1:
                                exampleTime--;
                                break;
                            case 2:
                                anotherTime--;
                                break;
                            case 3:
                                currentTime--;
                                break;
                            default:
                                Console.WriteLine("Такого варианта не было, выберите варианты от 1 до 3");
                                break;
                        }
                        Console.WriteLine("Время успешно уменьшено на 1 минуту");
                        Console.ReadKey();
                        break;
                    case 4:
                        int currentTimeToInt = GetInt("время, с которым нужно работать (1, 2 или 3)");
                        switch (currentTimeToInt)
                        {
                            case 1:
                                Console.WriteLine($"Явное приведение к int: {(int) exampleTime}");
                                break;
                            case 2:
                                Console.WriteLine($"Явное приведение к int: {(int)anotherTime}");
                                break;
                            case 3:
                                Console.WriteLine($"Явное приведение к int: {(int)currentTime}");
                                break;
                            default:
                                Console.WriteLine("Такого варианта не было, выберите варианты от 1 до 3");
                                break;
                        }
                        Console.ReadKey();
                        break;
                    case 5:
                        int currentTimeToBool = GetInt("время, с которым нужно работать (1, 2 или 3)");
                        switch (currentTimeToBool)
                        {
                            case 1:
                                Console.WriteLine($"Неявное приведение к bool: {false || exampleTime}");
                                break;
                            case 2:
                                Console.WriteLine($"Неявное приведение к bool: {false || anotherTime}");
                                break;
                            case 3:
                                Console.WriteLine($"Неявное приведение к bool: {false || currentTime}");
                                break;
                            default:
                                Console.WriteLine("Такого варианта не было, выберите варианты от 1 до 3");
                                break;
                        }
                        Console.ReadKey();
                        break;
                    case 6:
                        int firstTimeToPlus = GetInt("первое слагаемое");
                        int secondTimeToPlus = GetInt("второе слагаемое");

                        break;
                }
                input = Menu();
                Console.Clear();
            }
        }   
    }
}
