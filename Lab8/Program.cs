using System;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab8
{
    class MainClass
    {
        #region Модель
        /// <summary>
        /// Реализует работу с данными
        /// </summary>
        static MeteoWorker meteoWorker;
        /// <summary>
        /// реализует работу с файлами
        /// </summary>
        static DatabaseWorker databaseWorker;
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

        #endregion
        public static void Main(string[] args)
        {
            int input = Menu();
            while (input != 0)
            {
                switch (input)
                {
                    case 1:

                        break;
                    case 2:
                        meteoWorker.PrintData();
                        Console.ReadKey();
                        break;
                    case 3:
                        MeteoWorker.Data addingData;
                        addingData.month = ChooseMonth();
                        addingData.averageTemperature = GetInt("среднее значение температуры в данном месяце");
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
                        MeteoWorker.Data changingData;
                        changingData.month = ChooseMonth();
                        changingData.averageTemperature = GetInt("среднее значение температуры в данном месяце");
                        meteoWorker.Change(changingIndex, changingData);
                        Console.WriteLine("Данные успешно скорректированы");
                        Console.ReadKey();
                        break;
                }
                input = Menu();
                Console.Clear();
            }

        }
    }
}
