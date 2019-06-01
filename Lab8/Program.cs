//
//  Program.cs
//  Program
//
//  Created by Сорокин Дмитрий on 01/06/2019.
//  Copyright © 2019 Сорокин Дмитрий. All rights reserved.
//
using System;
using System.Collections.Generic;

namespace Lab8
{
    class MainClass
    {
        #region Модель
        /// <summary>
        /// Реализует работу с данными
        /// </summary>
        static MeteoWorker meteoWorker = MeteoWorker.GetInstance();
        /// <summary>
        /// Реализует работу с файлами
        /// </summary>
        static DatabaseWorker databaseWorker = DatabaseWorker.GetInstance();
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

            Console.WriteLine("База данных метеостанции");
            Console.WriteLine("1 - Подключиться к базе данных");
            Console.WriteLine("2 - Просмотреть записи в базе данных");
            Console.WriteLine("3 - Добавить запись в базу данных");
            Console.WriteLine("4 - Удалить запись из базы данных");
            Console.WriteLine("5 - Скорректировать запись в базе данных");
            Console.WriteLine("6 - Найти дни, в которые температура поднималась выше средней");
            Console.WriteLine("7 - Найти самый длинный отрезок между днями с отрицательной температурой");
            Console.WriteLine("0 - Выход");

            result = GetInt("необходимый пункт меню");

            while (result < 0 || result > 7)
            {
                Console.WriteLine("Выбранного пункта меню не существует, повторите ввод");
                result = GetInt();
            }

            return result;
        }
        #endregion
        #region Контроллер
        /// <summary>
        /// Позволяет пользователю выбрать месяц
        /// </summary>
        /// <returns>Выбранный месяц</returns>
        static Months ChooseMonth()
        {
            Months month;
            int monthNumber = GetInt("необходимый месяц (от 1 до 12)");

            switch (monthNumber)
            {
                case 1:
                    month = Months.January;
                    break;
                case 2:
                    month = Months.February;
                    break;
                case 3:
                    month = Months.March;
                    break;
                case 4:
                    month = Months.April;
                    break;
                case 5:
                    month = Months.May;
                    break;
                case 6:
                    month = Months.June;
                    break;
                case 7:
                    month = Months.July;
                    break;
                case 8:
                    month = Months.August;
                    break;
                case 9:
                    month = Months.September;
                    break;
                case 10:
                    month = Months.October;
                    break;
                case 11:
                    month = Months.November;
                    break;
                case 12:
                    month = Months.December;
                    break;
                default:
                    Console.WriteLine("Выбранного месяца не существует. Выбран декабрь");
                    month = Months.December;
                    break;
            }

            return month;
        }
        /// <summary>
        /// Создает массив данных о днях в месяце
        /// с помощью генератора случайных чисел
        /// </summary>
        /// <returns>Массив данных о днях</returns>
        /// <param name="month">Месяц</param>
        static int[] CreateDaysInfo(Months month)
        {
            int daysCount = 31;
            int[] result;
            var random = new Random();
            switch (month)
            {
                case Months.January:
                    daysCount = 31;
                    break;
                case Months.February:
                    daysCount = 28;
                    break;
                case Months.March:
                    daysCount = 31;
                    break;
                case Months.April:
                    daysCount = 30;
                    break;
                case Months.May:
                    daysCount = 31;
                    break;
                case Months.June:
                    daysCount = 30;
                    break;
                case Months.July:
                    daysCount = 31;
                    break;
                case Months.August:
                    daysCount = 31;
                    break;
                case Months.September:
                    daysCount = 30;
                    break;
                case Months.October:
                    daysCount = 31;
                    break;
                case Months.November:
                    daysCount = 30;
                    break;
                case Months.December:
                    daysCount = 31;
                    break;
            }
            result = new int[daysCount];
            for (int i = 0; i < daysCount; i++)
            {
                result[i] = random.Next(-10, 20);
            }
            return result;
        }
        /// <summary>
        /// находит теплые дни
        /// </summary>
        /// <returns>Теплые дни</returns>
        /// <param name="mw">Метео работник</param>
        /// <param name="month">Месяц</param>
        static Dictionary<MeteoWorker.Data, List<int>> FindWormDays(MeteoWorker mw, Months month)
        {
            var datas = mw.GetCurrentMonths(month);
            Dictionary<MeteoWorker.Data, List<int>> result = new Dictionary<MeteoWorker.Data, List<int>>();
            List<int> tempDays;

            foreach (var data in datas)
            {
                tempDays = new List<int>();
                for (int i = 0; i < data.dayTemperature.Length; i++)
                    if (data.dayTemperature[i] > data.averageTemperature)
                        tempDays.Add(i);
                result.Add(data, tempDays);
            }

            return result;
        }
        static int FindLongestSpaceBetweenMinusDays(List<MeteoWorker.Data> datas)
        {
            //Окончательное максимальное расстояние
            int result = 0;
            //Временное максимальное расстояние
            int tempMax = 0;
            //Сохраненный знак числа
            int sign = 0;

            foreach (var data in datas)
            {
                foreach (var day in data.dayTemperature)
                {
                    //Если попали на неотрицательное число
                    if ( Math.Sign(day) > -1 )
                    {
                        //Если знак предыдущего числа был отрицательным или 
                        //если отрицательное уже было встречено до этого
                        if (sign < 0 || tempMax > 0)
                            tempMax++;

                        //Изменяем сохраненный знак числа
                        sign = Math.Sign(day);
                    }
                    //Если попали на отрицательное число
                    else if ( Math.Sign(day) == -1 )
                    {
                        //Если превысили уже имеющееся масимальное расстояние
                        if (tempMax > result)
                            result = tempMax;
                        //Обнуляем временное расстояние между отрицательными
                        //начинаем подсчет заново
                        tempMax = 0;
                        //Изменяем временный знак числа
                        sign = Math.Sign(day);
                    }
                }
            }

            return result;
        }
        #endregion
        public static void Main(string[] args)
        {
            //Измените на 0, если не хотите, чтобы изменения сохранялись
            const int AUTO_SAVE = 1;
            int input = Menu();
            while (input != 0)
            {
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Введите путь к файлу, либо же его имя, если он находится в корневой папке");
                        string path = Console.ReadLine();
                        databaseWorker.SetPath(path);
                        if (databaseWorker.IsThereDatabase())
                        {
                            meteoWorker = databaseWorker.GetData();
                            Console.WriteLine("База данных успешно загружена");
                        } else
                        {
                            Console.WriteLine("База данных по указанному пути не найдена");
                            Console.WriteLine("Создать новую? (1 - да, 0 - нет");
                            if (GetInt("выбранную опцию") == 1)
                            {
                                databaseWorker.SaveData(meteoWorker);
                                Console.WriteLine("База данных успешно создана");
                            }
                        }
                        break;
                    case 2:
                        meteoWorker.PrintData();
                        Console.ReadKey();
                        break;
                    case 3:
                        MeteoWorker.Data addingData = new MeteoWorker.Data();
                        addingData.month = ChooseMonth();
                        addingData.dayTemperature = CreateDaysInfo(addingData.month);
                        addingData.averageTemperature = MeteoWorker.CalculateAverageTemperature(addingData);
                        meteoWorker.Add(addingData);
                        Console.WriteLine("Данные успешно добавлены");
                        Console.ReadKey();
                        break;
                    case 4:
                        int removingIndex = GetInt("индекс удаляемого элемента");
                        meteoWorker.RemoveAt(removingIndex);
                        Console.WriteLine("Элемент успешно удален");
                        Console.ReadKey();
                        break;
                    case 5:
                        int changingIndex = GetInt("номер корректируемого элемента");
                        Console.WriteLine("Сейчас введите данные скорректированного элемента..");
                        MeteoWorker.Data changingData = new MeteoWorker.Data();
                        changingData.month = ChooseMonth();
                        changingData.dayTemperature = CreateDaysInfo(changingData.month);
                        changingData.averageTemperature = MeteoWorker.CalculateAverageTemperature(changingData);
                        meteoWorker.Change(changingIndex, changingData);
                        Console.WriteLine("Данные успешно скорректированы");
                        Console.ReadKey();
                        break;
                    case 6:
                        Months month_ = ChooseMonth();

                        var wormDays = FindWormDays(meteoWorker, month_);

                        foreach (KeyValuePair<MeteoWorker.Data, List<int>> pair in wormDays)
                        {
                            Console.WriteLine("Новый год..");
                            foreach (int day in pair.Value)
                                Console.WriteLine($"Число теплого дня: {day}");
                        }

                        Console.ReadKey();
                        break;
                    case 7:
                        int lsbmd = FindLongestSpaceBetweenMinusDays(meteoWorker.GetData);
                        Console.WriteLine($"{lsbmd}");
                        Console.ReadKey();
                        break;
                }
                if (AUTO_SAVE == 1)
                    databaseWorker.SaveData(meteoWorker);
                input = Menu();
                Console.Clear();
            }

        }
    }
}
