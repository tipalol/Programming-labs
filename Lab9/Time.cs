//
//  Time.cs
//  Time
//
//  Created by Сорокин Дмитрий on 01/06/2019.
//  Copyright © 2019 Сорокин Дмитрий. All rights reserved.
//
using System;
namespace Lab9
{
    /// <summary>
    /// Класс реализует представление времени и методы работы с ним
    /// </summary>
    public class Time
    {
        /// <summary>
        /// Кол-во созданных объектов данного класса
        /// </summary>
        static int count;
        private int minutes;
        private int hours;
        /// <summary>
        /// Получает и устанавливает минуты на часах
        /// </summary>
        /// <value>Минуты</value>
        private int Minutes { 
            get
            {
                return minutes;
            }
            set
            {
                if (value < 0)
                    throw new Exception("невозможно присвоить кол-ву минут отрицательное значение.");
                else if (value > 59)
                    throw new Exception("значение минут не может превышать 59.");
                else
                    minutes = value;
            }
        }
        /// <summary>
        /// Получает и устанавливает кол-во часов    
        /// </summary>
        /// <value>Часы</value>
        private int Hours { 
            get
            {
                return hours;
            }
            set
            {
                if (value < 0)
                    throw new Exception("невозможно присвоить кол-ву часов отрицательное значение.");
                else if (value > 23)
                    throw new Exception("значение часов не может превышать 23.");
            }
          }
        /// <summary>
        /// Создает нвоый объект класса <see cref="T:Lab9.Time"/>
        /// </summary>
        /// <param name="hours">Кол-во часов</param>
        /// <param name="minutes">Кол-во минут</param>
        public Time(int hours = 0, int minutes = 0)
        {
            Hours = hours;
            Minutes = minutes;
        }
    }
}
