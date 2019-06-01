using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
namespace Lab8
{
    /// <summary>
    /// Класс, реализующий работу с месяцами и
    /// информацией о их средней температуре.
    /// Используется паттерн проектирования <see langword="Singlenton"/>
    /// </summary>
    [Serializable]
    public class MeteoWorker
    {
        #region Модель
        /// <summary>
        /// Единственный объект класса
        /// </summary>
        private static MeteoWorker instance;
        /// <summary>
        /// Представление одного месяца
        /// </summary>
        [Serializable]
        public struct Data
        {
            Months month;
            int averageTemperature;
            public override string ToString()
            {
                return $"Месяц: {month} со средней температурой {averageTemperature}";
            }
        }
        /// <summary>
        /// Получает или изменяет информацию о месяцах
        /// </summary>
        /// <value>Информация о месяцах</value>
        public List<Data> GetData { get; private set; }
        /// <summary>
        /// Создает объект <see cref="T:Lab8.MeteoWorker"/>.
        /// </summary>
        private MeteoWorker() {}
        /// <summary>
        /// Возвращает единственный объект класса
        /// </summary>
        /// <returns>Единственный объект класса</returns>
        public static MeteoWorker GetInstance()
        {
            if (instance == null)
                instance = new MeteoWorker();
            return instance;
        }
        #endregion
        #region Представление
        /// <summary>
        /// Возвращает <see cref="T:System.String"/> которая представляет этот <see cref="T:Lab8.MeteoWorker"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> которая представляет этот <see cref="T:Lab8.MeteoWorker"/>.</returns>
        public override string ToString()
        {
            string result = "";

            foreach (Data data in GetData)
                result += $"{data} \n";

            return result;
        }
        #endregion
        #region Контроллер

        #endregion
    }
}
