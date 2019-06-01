using System;
using System.IO;

namespace Lab8
{
    /// <summary>
    /// Реализует работу с файлами
    /// Используется паттер проектирования <see langword="Singlenton"/>
    /// </summary>
    public class DatabaseWorker
    {
        #region Модель
        /// <summary>
        /// Единственный объект класса
        /// </summary>
        private static DatabaseWorker instance;
        /// <summary>
        /// Создает нвоый объект <see cref="T:Lab8.DatabaseWorker"/>
        /// </summary>
        private DatabaseWorker() { }
        /// <summary>
        /// Возвращает единственный объект класса
        /// </summary>
        /// <returns>Единственный объект класса</returns>
        public static DatabaseWorker GetInstance()
        {
            if (instance == null)
                instance = new DatabaseWorker();
            return instance;
        }
        #endregion
        #region Контроллер

        #endregion
    }
}
