//
//  TimeArray.cs
//  TimeArray
//
//  Created by Сорокин Дмитрий on 01/06/2019.
//  Copyright © 2019 Сорокин Дмитрий. All rights reserved.
//
using System;
namespace Lab9
{
    /// <summary>
    /// Класс для работы с массивом объектов класса <see cref="Time"/>
    /// </summary>
    public class TimeArray
    {
        #region Модель
        const int default_size = 5;
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
        public TimeArray(int mode = 0, int size = default_size)
        {
            Times = new Time[size+1];
            for (int i = 0; i < size; i++)
                Times[i] = new Time();
            Size = size;

            switch (mode)
            {
                case 0:
                    var random = new Random();
                    for (int i = 0; i < size; i++)
                    {
                        Times[i].AddSeconds( random.Next(0, 300) );
                        Times[i].AddMinutes(random.Next(0, 540));
                        Times[i].AddHours(random.Next(0, 16));
                    }
                    break;
                case 1:
                    for (int i = 0; i < size; i++)
                    {
                        Times[i].AddSeconds( MainClass.GetInt("Введите добавляемое кол-во секунд") );
                        Times[i].AddMinutes(MainClass.GetInt("Введите добавляемое кол-во минут"));
                        Times[i].AddHours(MainClass.GetInt("Введите добавляемое кол-во часов"));
                    }
                    break;
                default:
                    throw new Exception("незвестный режим создания массива");
            }
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
