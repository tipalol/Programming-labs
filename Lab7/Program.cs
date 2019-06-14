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
    class MainClass
    {
        #region Модель
        //Однонаправленный список
        static Point point;
        //Двунаправленный список
        static DoublePoint doublePoint;
        //Бинарное дерево
        static Tree tree;
        #endregion
        #region Представление
        /// <summary>
        /// Получает целое число из введенной пользователем строки.
        /// </summary>
        /// <returns>Число, введенное пользователем</returns>
        /// <param name="message">Сообщение пользователю</param>
        public static int GetInt(string message = "")
        {
            int input;
            Console.WriteLine($"Введите пожалуйста {message}");
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Не удалось распознать число, повторите ввод");
            }
            return input;
        }
        /// <summary>
        /// Вызывает список команд меню и реализует взаимодействие с ним
        /// </summary>
        /// <returns>Выбранный пункт меню</returns>
        static int Menu()
        {
            int result;

            Console.WriteLine("Работа со структурами данных");
            Console.WriteLine("1 - Сформировать однонаправленный список");
            Console.WriteLine("2 - Удалить элементы с четными информационными полями");
            Console.WriteLine("3 - Сформировать двунаправленный список");
            Console.WriteLine("4 - Добавить в список элемент");
            Console.WriteLine("5 - Сформировать идеально сбалансированное бинарное дерево");
            Console.WriteLine("6 - Найти кол-во элементов с заданным ключом");
            Console.WriteLine("0 - Выход");

            result = GetInt("необходимый пункт меню");

            while (result < 0 || result > 6)
            {
                Console.WriteLine("Выбранного пункта меню не существует, повторите ввод");
                result = GetInt();
            }

            return result;
        }
        #endregion
        #region Контроллер
        static Point DeletePointWithEvenInfo(Point begin)
        {
            if (begin == null)
            {
                Console.WriteLine("Список пуст");
                return begin;
            }

            while (begin.Info % 2 == 0)
                begin = begin.Next;

            Point p = begin;

            while (p.Next != null && p != null)
            {
                if (p.Next.Info % 2 == 0)
                {
                    p.Next = p.Next.Next;
                } else
                p = p.Next;
            }

            return begin;
        }
        static int CountOfThis(Tree t, char someChar)
        {
            int result = 0;

            if (t == null)
            {
                Console.WriteLine("Дерево пустое");
            } else
            {
                result += CountOfThis(t.Left, someChar);
                if (t.Data == someChar) result++;
                result += CountOfThis(t.Right, someChar);
            }

            return result;
        }
        #endregion
        public static void Main(string[] args)
        {
            int input = Menu();
            while (input != 0)
            {
                switch (input)
                {
                    case 1:
                        int size = GetInt("размер создаваемого списка");
                        while (size < 1)
                        {
                            Console.WriteLine("Неа");
                            size = GetInt("размер создаваемого списка");
                        }
                        point = Point.MakeList(size);
                        Point.ShowList(point);
                        break;
                    case 2:
                        point = DeletePointWithEvenInfo(point);
                        Point.ShowList(point);
                        break;
                    case 3:
                        int doubleSize = GetInt("размер создаваемого списка");
                        while (doubleSize < 1)
                        {
                            Console.WriteLine("неа");
                            doubleSize = GetInt("размер создаваемого списка");
                        }
                        doublePoint = DoublePoint.MakeList(doubleSize);
                        DoublePoint.ShowList(doublePoint);
                        break;
                    case 4:
                        int position = GetInt("позицию добавляемого элемента");
                        while (position < 0 )
                        {
                            Console.WriteLine("Неа");
                            position = GetInt("позицию добавляемого элемента");
                        }
                        doublePoint = DoublePoint.AddPoint(doublePoint, position);
                        DoublePoint.ShowList(doublePoint);
                        break;
                    case 5:
                        int treeSize = GetInt("размер создаваемого дерева");
                        while (treeSize < 1)
                        {
                            Console.WriteLine("Неа");
                            treeSize = GetInt("размер создаваемого дерева");
                        }
                        tree = Tree.IdealTree(treeSize, tree);

                        Tree.ShowTree(tree, treeSize);
                        
                        break;
                    case 6:
                        int countOfThis;
                        Console.WriteLine("Введите искомый символ");
                        char someChar = Console.ReadLine()[0];

                        countOfThis = CountOfThis(tree, someChar);

                        Console.WriteLine($"Кол-во элементов {someChar}: {countOfThis}");
                        break;
                }
                input = Menu();
                Console.Clear();
            }

        }
    }
}
