using System;
namespace Lab7
{
    /// <summary>
    /// Класс <see cref="Tree"/> реализует бинарное дерево
    /// </summary>
    public class Tree
    {
        #region Модель
        /// <summary>
        /// Информационное поле
        /// </summary>
        /// <value>Информаицонное поле</value>
        public char Data { get; set; }
        /// <summary>
        /// Левая ветка дерева
        /// </summary>
        /// <value>Левая ветка дерева</value>
        public Tree Left { get; set; }
        /// <summary>
        /// Правая ветка дерева
        /// </summary>
        /// <value>Правая ветка дерева</value>
        public Tree Right { get; set; }
        /// <summary>
        /// Генератор случайных чисел
        /// </summary>
        static Random random = new Random();
        /// <summary>
        /// Создает новую сущность <see cref="T:Lab7.Tree"/>.
        /// </summary>
        /// <param name="data">Информаицонное поле</param>
        /// <param name="left">Левая ветка дерева</param>
        /// <param name="right">Правая ветка дерева</param>
        public Tree(char data = ' ', Tree left = null, Tree right = null)
        {
            Data = data;
            Left = left;
            Right = right;
        }
        /// <summary>
        /// Возвращает <see cref="T:System.String"/> которая представляет <see cref="T:Lab7.Tree"/>.
        /// </summary>
        /// <returns><see cref="T:System.String"/> которая представляет <see cref="T:Lab7.Tree"/>.</returns>
        public override string ToString()
        {
            return Data + " ";
        }
        #endregion
        #region Представление
        /// <summary>
        /// Выводит на экран бинарное дерево
        /// </summary>
        /// <param name="tree">Дерево</param>
        /// <param name="length">Длина</param>
        public static void ShowTree(Tree p, int l)
        {
            if (p != null)
            {
                ShowTree(p.Left, l + 3);//переход к левому поддереву
                for (int i = 0; i < l; i++) Console.Write(" ");
                Console.WriteLine(p.Data);
                ShowTree(p.Right, l + 3);//переход к правому поддереву
            }
        }
        #endregion
        #region Контроллер
        /// <summary>
        /// Создает узел дерева с указанным информационным полем
        /// </summary>
        /// <returns>Полученный узел</returns>
        /// <param name="d">Информационное поле</param>
        public static Tree First(char d)
        {
            Tree tree = new Tree(d);
            return tree;
        }
        /// <summary>
        /// Возвращает случайное значение информационного поля
        /// </summary>
        /// <returns>Значение информационного поля</returns>
        static char GetInfo()
        {
            int info_ = random.Next(0, 6);
            char info;

            switch (info_)
            {
                case 0:
                    info = 'a';
                    break;
                case 1:
                    info = 'b';
                    break;
                case 2:
                    info = 'c';
                    break;
                case 3:
                    info = 'd';
                    break;
                case 4:
                    info = 'e';
                    break;
                case 5:
                    info = 'f';
                    break;
                case 6:
                    info = 'g';
                    break;
                default:
                    info = 'h';
                    break;
            }

            Console.WriteLine($"Элемент {info} добавлен");
            return info;
        }
        /// <summary>
        /// Добавляет узел с указанным информационным полем в указанное дерево
        /// </summary>
        /// <returns>Корень полученного дерева</returns>
        /// <param name="root">Корень</param>
        /// <param name="d">Информационное поле</param>
        public static Tree Add(Tree root, char d)
        {
            Tree p = root;
            Tree r = null;

            bool ok = false;
            while (p != null && !ok)
            {
                r = p;
                if (d == p.Data) ok = true;
                else if (d < p.Data) p = p.Left;
                else p = p.Right;
            }
            //Элемент найден, новый не добавляем
            if (ok) return p;
            Tree newPoint = new Tree(d);

            if (d < r.Data) r.Left = newPoint;
            else r.Right = newPoint;

            return newPoint;
        }
        /// <summary>
        /// Строит идеальное дерево указанного размера
        /// </summary>
        /// <returns>Корень полученного дерева</returns>
        /// <param name="size">Размер</param>
        /// <param name="t">Дерево</param>
        public static Tree IdealTree(int size, Tree p)
        {
            Tree r;
            int nl, nr;
            if (size == 0) { p = null; return p; }
            nl = size / 2;
            nr = size - nl - 1;
            char d = GetInfo();
            r = new Tree(d);
            r.Left = IdealTree(nl, r.Left);
            r.Right = IdealTree(nr, r.Right);
            p = r;
            return p;
        }
        #endregion
    }
}
