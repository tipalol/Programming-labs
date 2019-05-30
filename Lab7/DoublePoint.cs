using System;
namespace Lab7
{
    /// <summary>
    /// Класс <see cref="DoublePoint"/> реализует двунаправленный список
    /// с типом информационного поля <see cref="int"/>
    /// </summary>
    public class DoublePoint
    {
        #region Модель
        /// <summary>
        /// Ссылка на следующий элемент списка
        /// </summary>
        /// <value>Следующий элемент списка</value>
        public DoublePoint Next { get; set; }
        /// <summary>
        /// Информационное поле
        /// </summary>
        /// <value>Значение информационного поля</value>
        public string Info { get; set; }

        /// <summary>
        /// Возвращает <see cref="T:System.String"/> которая представляет текущий <see cref="T:Lab7.Point"/>.
        /// </summary>
        /// <returns><see cref="T:System.String"/> которая представляет текущий <see cref="T:Lab7.Point"/>.</returns>
        public override string ToString()
        {
            return Info + " ";
        }
        /// <summary>
        /// Ссылка на предыдущий элемент списка
        /// </summary>
        /// <value>Предыдущий элемент списка</value>
        public DoublePoint pred { get; set; }
        /// <summary>
        /// Конструктор <see cref="DoublePoint"/> с параметрами по умолчанию
        /// </summary>
        /// <param name="info">Информационное поле</param>
        /// <param name="to">Следующий элемент списка</param>
        /// <param name="from">Предыдущий элемент списка</param>
        public DoublePoint(string info = "",
                           DoublePoint to = null, 
                           DoublePoint from = null)
        {
            Info = info;
            Next = to;
            pred = from;
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
        /// Выводит на экран двунаправленный список <see cref="DoublePoint"/>
        /// </summary>
        /// <param name="begin">Начало списка</param>
        public static void ShowList(DoublePoint begin)
        {
            //Проверка на пустой список
            if (begin == null)
            {
                Console.WriteLine("Список пуст");
                return;
            }

            DoublePoint p = begin;
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
        /// Создает элемент однонаправленного списка <see cref="DoublePoint"/>
        /// </summary>
        /// <returns>Созданный элемент</returns>
        /// <param name="info">Информационное поле</param>
        public static DoublePoint MakePoint(int info = 0)
        {
            DoublePoint p = new DoublePoint(info);
            return p;
        }
        /// <summary>
        /// Создает двунаправленный список указанного размера
        /// </summary>
        /// <returns>Первый элемент списка</returns>
        /// <param name="size">Размер списка</param>
        public static DoublePoint MakeList(int size)
        {
            var random = new Random();
            var info = random.Next(0, 9);
            DoublePoint begin = MakePoint(info);

            begin.PrintInfo();

            for (int i = 1; i < size; i++)
            {
                info = random.Next(0, 9);
                DoublePoint p = MakePoint(info);
                p.PrintInfo();
                p.Next = begin;
                begin.pred = p;
                begin = p;
            }
            return begin;
        }
        /// <summary>
        /// Создает однонаправленный список <see cref="DoublePoint"/>
        /// и возвращает его первый элемент
        /// </summary>
        /// <returns>Первый элемент созданного списка</returns>
        /// <param name="ofSize">Размер создаваемого списка</param>
        public static DoublePoint MakeListToEnd(int ofSize)
        {
            var random = new Random();
            var info = random.Next(1, 9);

            //Создаем первый элемент списка
            DoublePoint end = MakePoint(info);
            end.PrintInfo();

            //Адресс конца списка
            DoublePoint r = end;

            for (int i = 1; i < ofSize; i++)
            {
                info = random.Next(0, 9);
                DoublePoint p = MakePoint(info);
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
        public static DoublePoint AddPoint(DoublePoint begin, int number)
        {
            var random = new Random();
            var info = random.Next(0, 9);
            DoublePoint newPoint = MakePoint(info);

            newPoint.PrintInfo();
            //Если список оказывается пустым
            if (begin == null)
            {
                begin = MakePoint(random.Next(0, 9));
                return begin;
            }
            if (number == 1)
            {
                newPoint.Next = begin;
                begin = newPoint;
                return begin;
            }
            //Вспомогательная переменная для прохода по списку
            DoublePoint p = begin;
            //Идем по списку до нужного элемента
            for (int i = 1; i < number - 1 && p != null; i++)
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
        public static DoublePoint DeleteElement(DoublePoint begin, int number)
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
            DoublePoint p = begin;
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
