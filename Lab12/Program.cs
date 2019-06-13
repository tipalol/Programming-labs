using System;

namespace Lab12
{
    class MainClass
    {
        /// <summary>
        /// Массив элементов меню
        /// </summary>
        readonly static string[] menuElements = {
            "Создать тестовый класс коллекций",
            "Добавить элемент",
            "Удалить элемент",
            "Найти элемент в коллекциях и измерить время поиска"
         };
        /// <summary>
        /// Основное меню
        /// </summary>
        readonly static Menu menu = new Menu(menuElements);
        /// <summary>
        /// Класс с тестовыми коллекциями
        /// </summary>
        static TestCollections testCollections;


        public static void Main()
        {

        }
    }
}
