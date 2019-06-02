using System;
namespace Lab10
{
    /// <summary>
    /// Класс поределяет терминал в университете, а также методы работы с ним
    /// Используется паттерн проектирования Singlenton
    /// </summary>
    public class UnivercityTerminal
    {
        private static UnivercityTerminal instance;
        public static UnivercityTerminal GetInstance()
        {
            if (instance == null)
                instance = new UnivercityTerminal();
            return instance;
        }
        public string GetString(string message ="")
        {
            Console.WriteLine($"Введите пожалуйста {message}");
            return Console.ReadLine();
        }
        /// <summary>
        /// Получает целое число из введенной пользователем строки.
        /// </summary>
        /// <returns>Число, введенное пользователем</returns>
        /// <param name="message">Сообщение пользователю</param>
        public int GetInt(string message = "")
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
        public int ShowMenu()
        {
            int result;

            Console.WriteLine("Терминал университета");
            Console.WriteLine("1 - Вывести список работников университета");
            Console.WriteLine("2 - Добавить работника");
            Console.WriteLine("3 - Удалить работника");
            Console.WriteLine("4 - Изменить информацию о работнике");
            Console.WriteLine("5 - Вывести список студентов");
            Console.WriteLine("6 - Вывести имена студентов указанного курса");
            Console.WriteLine("7 - Вывести имена и должность преподавателя с указанной кафедры");
            Console.WriteLine("8 - Вывести имена всех лиц мужского пола");
            Console.WriteLine("9 - Отсортировать список работников");
            Console.WriteLine("10 - Найти работника в списке");
            Console.WriteLine("11 - Клонировать работника");
            Console.WriteLine("0 - Выход");


            result = GetInt("необходимый пункт меню");

            while (result < 0 || result > 11)
            {
                Console.WriteLine("Выбранного пункта меню не существует, повторите ввод");
                result = GetInt();
            }

            return result;
        }
        public void Clear()
        {
            Console.Clear();
        }
        public void Print(string output ="")
        {
            Console.WriteLine(output);
        }
        private UnivercityTerminal() {
            Console.WriteLine("Добро пожаловать в меню лучшего университета!");
        }
    }
}
