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
            public Months month;
            public double averageTemperature;
            public int[] dayTemperature;
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
        /// <summary>
        /// Выводит на экран всю информацию
        /// </summary>
        public void PrintData()
        {
            foreach (Data data in GetData) {
                Console.WriteLine(data);
                for (int i = 1; i <= data.dayTemperature.Length; i++)
                    Console.WriteLine($"Температура {i} дня равнялась {data.dayTemperature[i]}");
            }
        }
        #endregion
        #region Контроллер
        /// <summary>
        /// Добавляет указанный элемент в список данных
        /// </summary>
        /// <param name="data">Дата</param>
        public void Add(Data data)
        {
            GetData.Add(data);
        }
        /// <summary>
        /// Удаляет элемент с указанным индексом
        /// </summary>
        /// <param name="index">Индекс</param>
        public void RemoveAt(int index)
        {
            GetData.RemoveAt(index);
        }
        /// <summary>
        /// Меняет информацию, содержащуюся в указанной позиции
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <param name="data">Дата</param>
        public void Change(int index, Data data)
        {
            GetData[index] = data;
        }
        /// <summary>
        /// Вычисляет среднюю температуру месяца
        /// </summary>
        /// <returns>Средняя температура месяца</returns>
        /// <param name="data">Информация о месяце</param>
        public static double CalculateAverageTemperature(Data data)
        {
            int sum = 0;
            foreach (int temperature in data.dayTemperature)
                sum += temperature;
            return sum / data.dayTemperature.Length;
        }
        #endregion
    }
}
