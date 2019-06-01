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
        #region Модель
        /// <summary>
        /// Кол-во созданных объектов данного класса
        /// </summary>
        static int count;
        /// <summary>
        /// Кол-во секунд
        /// </summary>
        private int seconds;
        /// <summary>
        /// Кол-во минут
        /// </summary>
        private int minutes;
        /// <summary>
        /// Кол-во часов
        /// </summary>
        private int hours;
        public int Seconds { 
            get
            {
                return seconds;
            }
            set
            {
                if (value < 0)
                    throw new Exception("невозможно присвоить кол-ву секунд отрицательное значение.");
                else if (value > 59)
                    throw new Exception("значение секунд не может превышать 59.");
                else
                    minutes = value;
            }
        }
        /// <summary>
        /// Получает и устанавливает минуты на часах
        /// </summary>
        /// <value>Минуты</value>
        public int Minutes { 
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
        public int Hours { 
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
        public Time(int hours = 0, int minutes = 0, int seconds = 0)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
            count++;
        }
        /// <summary>
        /// Создает нвоый объект класса <see cref="T:Lab9.Time"/>
        /// </summary>
        /// <param name="dateTime">Дата</param>
        public Time(DateTime dateTime)
        {
            Hours = dateTime.Hour;
            Minutes = dateTime.Minute;
            Seconds = dateTime.Second;
            count++;
        }
        #endregion
        #region Представление
        /// <summary>
        /// Возвращает <see cref="T:System.String"/> которая представляет <see cref="T:Lab9.Time"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> которая представляет <see cref="T:Lab9.Time"/>.</returns>
        public override string ToString()
        {
            return $"Часы: {Hours}, минуты: {Minutes}, секунды: {Seconds}";
        }
        #endregion
        #region Контроллер
        /// <summary>
        /// Добавляет секунды к текущему времени
        /// </summary>
        /// <param name="countOfSeconds">Кол-во секунд</param>
        public void AddSeconds(int countOfSeconds)
        {
            //Если укладываемся в возможное кол-во секунд
            if (Seconds + countOfSeconds < 60 && Seconds + countOfSeconds > -1)
                Seconds += countOfSeconds;
            //Если нет, то
            else
            {
                //Вычисляем сколько можно получить минут из введенного числа
                int countOfMinutes = countOfSeconds / 60;

                //Если хотя бы минута нашлась
                if (countOfMinutes > 0)
                    AddMinutes(countOfMinutes);

                //Если оставшееся число секунд можно прибавить
                if (Seconds + (countOfSeconds % 60) < 60 && Seconds + (countOfSeconds % 60) > -1)
                    Seconds += countOfSeconds % 60;
                //Иначе, если выходит отрицательное число секунд
                else if (Seconds + (countOfSeconds % 60) < 0)
                {
                    //Убавляем минуту
                    AddMinutes(-1);
                    //Отнимаем от 60 получившееся число
                    Seconds = 60 + (Seconds + (countOfSeconds % 60));
                }
                //Иначе, если выходит положительное, но выходящее за рамки число секунд
                else
                {
                    //Прибавляем минуту
                    AddMinutes(1);
                    Seconds += (countOfSeconds % 60) - 60;
                }
            }
        }
        /// <summary>
        /// Добавляет минуты к текущему времени
        /// </summary>
        /// <param name="countOfMinutes">Кол-во минут</param>
        public void AddMinutes(int countOfMinutes)
        {
            //Если укладываемся в возможное кол-во минут
            if (Minutes + countOfMinutes < 60 && Minutes + countOfMinutes > -1)
                Minutes += countOfMinutes;
            //Если нет, то..
            else
            {
                //Вычисляем, сколько можно получить часов из введенного числа
                int countOfHours = countOfMinutes / 60;

                //Если хотя бы один час нашелся
                if (countOfHours > 0)
                    AddHours(countOfHours);

                //Если оставшееся число минут можно прибавить
                if (Minutes + (countOfMinutes % 60) < 60 && Minutes + (countOfMinutes % 60) > -1)
                    Minutes += countOfMinutes % 60;
                //Иначе, если выходит отрицательное число минут
                else if (Minutes + (countOfMinutes % 60) < 0)
                {
                    //Убавляем час
                    AddHours(-1);
                    //Отнимаем от 60 получившееся число
                    Minutes += 60 + (countOfMinutes % 60);
                }
                //Иначе, если выходит положительное, но выходящее за рамки число минут
                else
                {
                    //Прибавляем час
                    AddHours(1);
                    Minutes += (countOfMinutes % 60) - 60;
                }
            }
        }
        /// <summary>
        /// Добавляет часы к текущему времени
        /// </summary>
        /// <param name="countOfHours">Кол-во часов</param>
        public void AddHours(int countOfHours)
        {
            //Если укладываемся в возможное кол-во часов
            if (Hours + countOfHours < 24 && Hours + countOfHours > -1)
                Hours += countOfHours;
            else
            {
                //Получаем кол-во "лишних" часов
                int estimatedHours = countOfHours % 24;
                //Если укладываемся в возможное кол-во часов
                if (Hours + estimatedHours > -1 && Hours + estimatedHours < 24)
                    Hours += estimatedHours;
                //Если получаем отрицательное число
                else if (Hours + estimatedHours < 0)
                    Hours = 24 - (Hours + estimatedHours);
                //Если получаем положительно, выходящее за рамки
                else
                    Hours += estimatedHours - 24;
            }
        }
        #endregion
    }
}
