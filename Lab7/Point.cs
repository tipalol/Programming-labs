//
//  Point.cs
//  Point
//
//  Created by Сорокин Дмитрий on 23/05/2019.
//  Copyright © 2019 Сорокин Дмитрий. All rights reserved.
//
using System;
namespace Lab7
{
    /// <summary>
    /// Класс <see cref="Point"/> реализует однонаправленный список с типом информационного поля <see cref="int"/>
    /// </summary>
    public class Point
    {
        #region Модель
        /// <summary>
        /// Ссылка на следующий элемент списка
        /// </summary>
        /// <value>Следующий элемент списка</value>
        public Point Next { get; set; }
        /// <summary>
        /// Информационное поле
        /// </summary>
        /// <value>Значение информационного поля</value>
        public int Info { get; set; }

        /// <summary>
        /// Возвращает <see cref="T:System.String"/> которая представляет текущий <see cref="T:Lab7.Point"/>.
        /// </summary>
        /// <returns><see cref="T:System.String"/> которая представляет текущий <see cref="T:Lab7.Point"/>.</returns>
        public override string ToString()
        {
            return Info + " ";
        }

        /// <summary>
        /// Конструктор <see cref="Point"/> с параметрами по умолчанию
        /// </summary>
        /// <param name="p">Следующий элемент списка</param>
        /// <param name="info">Информационное поле</param>
        public Point(int info = 0, Point to = null)
        {
            Next = to;
            Info = info;
        }
        #endregion
        #region Представление
        /// <summary>
        /// Выводит на экран информацию о данном элементе списка
        /// </summary>
        public void PrintInfo()
        {
            Console.WriteLine($"Точка со значением {Info}");
        }
        /// <summary>
        /// Выводит на экран однонаправленный список <see cref="Point"/>
        /// </summary>
        /// <param name="begin">Начало списка</param>
        public static void ShowList(Point begin) 
        {
            //Проверка на пустой список
            if (begin == null)
            {
                Console.WriteLine("Список пуст");
                return;
            }

            Point p = begin;
            while (p != null)
            {
                Console.Write(p);
                p = p.Next;
            }
            Console.WriteLine();
        }
        #endregion
        #region Контроллер
        /// <summary>
        /// Создает элемент однонаправленного списка <see cref="Point"/>
        /// </summary>
        /// <returns>Созданный элемент</returns>
        /// <param name="info">Информационное поле</param>
        public static Point MakePoint(int info = 0)
        {
            Point p = new Point(info);
            return p;
        }
        /// <summary>
        /// Создает однонаправленный список <see cref="Point"/>
        /// и возвращает его первый элемент
        /// </summary>
        /// <returns>Первый элемент созданного списка</returns>
        /// <param name="ofSize">Кол-во элементов списка</param>
        public static Point MakeList(int ofSize)
        {
            var random = new Random();
            var info = random.Next(1, 9);

            Console.WriteLine("Началось составление списка. Добавляются точки..");

            //Создаем первый элемент списка
            Point start = MakePoint(info);
            start.PrintInfo();

            //Создаем оставшиеся элементы
            for (int i = 1; i < ofSize; i++)
            {
                info = random.Next(1, 9);
                Point p = MakePoint(info);
                p.PrintInfo();
                p.Next = start;
                start = p;
            }

            return start;
        }
        /// <summary>
        /// Создает однонаправленный список <see cref="Point"/>
        /// и возвращает его первый элемент
        /// </summary>
        /// <returns>Первый элемент созданного списка</returns>
        /// <param name="ofSize">Размер создаваемого списка</param>
        public static Point MakeListToEnd(int ofSize)
        {
            var random = new Random();
            var info = random.Next(1, 9);

            //Создаем первый элемент списка
            Point end = MakePoint(info);
            end.PrintInfo();

            //Адресс конца списка
            Point r = end;

            for (int i = 1; i < ofSize; i++)
            {
                info = random.Next(0, 9);
                Point p = MakePoint(info);
                p.PrintInfo();
                r.Next = p;
                r = p;
            }

            return null;
        }
        /// <summary>
        /// Добавляет точку в однонаправленный список
        /// </summary>
        /// <returns>Начало списка</returns>
        /// <param name="begin">Начало списка</param>
        /// <param name="number">Позиция вставляемого элемента</param>
        public static Point AddPoint(Point begin, int number)
        {
            var random = new Random();
            var info = random.Next(0, 9);
            Point newPoint = MakePoint(info);

            newPoint.PrintInfo();
            //Если список оказывается пустым
            if (begin == null)
            {
                begin = MakePoint(random.Next(0,9));
                return begin;
            }
            if (number == 1)
            {
                newPoint.Next = begin;
                begin = newPoint;
                return begin;
            }
            //Вспомогательная переменная для прохода по списку
            Point p = begin;
            //Идем по списку до нужного элемента
            for (int i = 1; i < number-1 && p != null; i++)
                p = p.Next;
            if (p == null)
            {
                Console.WriteLine("Размер списка меньше указанной позиции");
                return begin;
            }
            //Добавляем новый элемент
            newPoint.Next = p.Next;
            p.Next = newPoint;
            return begin;
        }
        /// <summary>
        /// Удаляет элемент с указанным номером из списка
        /// </summary>
        /// <returns>Начало списка</returns>
        /// <param name="begin">Начало списка</param>
        /// <param name="number">Номер удаляемого элемента</param>
        public static Point DeleteElement(Point begin, int number)
        {
            //Если список пуст
            if (begin == null)
            {
                Console.WriteLine("Список пуст");
                return begin;
            }
            //Если удаляем первый элемент
            if (number == 1)
            {
                begin = begin.Next;
                return begin;
            }
            Point p = begin;
            //Ищем элемент для удаления и встаем на предыдущий
            for (int i = 1; i < number - 1 && p != null; i++)
                p = p.Next;
            //Если элемент не найден
            if (p == null)
            {
                Console.WriteLine("Размер списка меньше позиции удаляемого элемента");
                return begin;
            }
            //Исключаем элемент из списка
            p.Next = p.Next.Next;
            return begin;
        }
        #endregion
    }
}
