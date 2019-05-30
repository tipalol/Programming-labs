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
        static void ShowTree(Tree tree, int length)
        {
            if (tree != null)
            {
                ShowTree(tree.Left, length + 3);

                for (int i = 0; i < length; i++)
                    Console.Write(" ");
                Console.WriteLine(tree.Data);
                ShowTree(tree.Right, length + 3);
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
        public static Tree IdealTree(int size, Tree t)
        {

        }
        #endregion
    }
}
