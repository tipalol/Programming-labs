using System;
namespace Lab13
{
    /// <summary>
    /// Класс реализует меню и метод работы с ним
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Получает элементы меню
        /// </summary>
        /// <value>The elements.</value>
        public string[] Elements { get; private set; }
        /// <summary>
        /// Получает кол-во элементов меню
        /// </summary>
        /// <value>The size.</value>
        public int Size
        {
            get
            {
                return Elements.Length;
            }
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
        /// Получает от пользователя строку
        /// </summary>
        /// <returns>The string.</returns>
        /// <param name="str">String.</param>
        public string GetString(string str)
        {
            Console.WriteLine($"Введите пожалуйста {str}");
            return Console.ReadLine();
        }
        /// <summary>
        /// Выводит меню на экран
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < Size; i++)
            {
                Console.WriteLine($"{i + 1}. {Elements[i]}");
            }
            Console.WriteLine("0. Выход");
        }
        /// <summary>
        /// Получает выбранный пользователем пункт меню
        /// </summary>
        /// <returns>The choose.</returns>
        public int GetChoose()
        {
            Print();
            int result = GetInt("необходимый пункт меню");
            while (result < 0 || result > Size)
            {
                Console.WriteLine("Такого пункта не существует");
                result = GetInt("необходимый пункт меню");
            }

            return result;
        }
        /// <summary>
        /// Создает новую сущность класса <see cref="T:Lab12.Menu"/>
        /// </summary>
        /// <param name="elements">Elements.</param>
        public Menu(string[] elements)
        {
            Elements = elements;
        }
    }
}
