using System;
namespace Lab9
{
    /// <summary>
    /// Класс для работы с массивом объектов класса <see cref="Time"/>
    /// </summary>
    public class TimeArray
    {
        #region Модель
        /// <summary>
        /// Массив времен
        /// </summary>
        /// <value>Времена</value>
        public Time[] Times { get; set; }
        /// <summary>
        /// Размер массива <see cref="Time"/>
        /// </summary>
        /// <value>Размер</value>
        public int Size { get; set; }
        /// <summary>
        /// Создает новый объект класса <see cref="T:Lab9.TimeArray"/>
        /// </summary>
        /// <param name="times">Времена</param>
        public TimeArray(Time[] times)
        {
            Times = times;
            Size = times.Length;
        }
        public Time this[int index]
        {
            get
            {
                return Times[index];
            }
            set
            {
                Times[index] = value;
            }
        }
        #endregion
        #region Контроллер
        
        #endregion
    }
}
