using System;
namespace Lab10
{
    /// <summary>
    /// Класс определяет учителя
    /// </summary>
    public class Teacher : Worker
    {
        /// <summary>
        /// Создает новый объект класса <see cref="T:Lab10.Teacher"/>
        /// </summary>
        /// <param name="name">Имя объекта</param>
        /// <param name="gender">Пол объекта</param>
        public Teacher(string name, int gender) : base (name, gender)
        {
        }
    }
}
