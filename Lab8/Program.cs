using System;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab8
{
    class MainClass
    {
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
        public static void Main(string[] args)
        {

        }
    }
}
