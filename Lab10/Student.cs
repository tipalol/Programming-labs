using System;
namespace Lab10
{
    /// <summary>
    /// Класс определяет студента
    /// </summary>
    public class Student : Person
    {
        /// <summary>
        /// Создает новый объект класса <see cref="T:Lab10.Student"/>
        /// </summary>
        /// <param name="name">Имя объекта</param>
        /// <param name="gender">Пол объекта</param>
        public Student(string name, int gender) : base (name, gender)
        {
        }
    }
}
