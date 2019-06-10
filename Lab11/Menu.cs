using System;
namespace Lab11
{
    /// <summary>
    /// Класс реализует меню и метод работы с ним
    /// </summary>
    public class Menu
    {
        public string[] Elements { get; private set; }
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
        public string GetString(string str)
        {
            Console.WriteLine($"Введите пожалуйста {str}");
            return Console.ReadLine();
        }
        public void Print()
        {
            for (int i = 0; i < Size; i++)
            {
                Console.WriteLine($"{i+1}. {Elements[i]}");
            }
            Console.WriteLine("0. Выход");
        }
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
        public Menu(string[] elements)
        {
            Elements = elements;
        }
    }
}
