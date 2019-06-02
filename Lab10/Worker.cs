using System;
namespace Lab10
{
    /// <summary>
    /// Класс определяет стандартного работника
    /// </summary>
    public abstract class Worker : Person
    {
        /// <summary>
        /// Создает новый объект класса <see cref="T:Lab10.Worker"/>
        /// </summary>
        /// <param name="name">Имя объекта</param>
        /// <param name="gender">Пол объекта</param>
        protected Worker(string name, int gender) : base (name, gender)
        {
        }
    }
}
