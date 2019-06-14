using System;
namespace Lab13
{
    /// <summary>
    /// Класс реализует студента
    /// </summary>
    public class Student : Person
    {
        static int count = 0;
        readonly static Random random = new Random();
        /// <summary>
        /// Получает курс студента
        /// </summary>
        /// <value>The course.</value>
        public int Course { get; private set; } = 1;
        /// <summary>
        /// Получает <see cref="T:System.String"/> которая представляет <see cref="T:Lab13.Student"/>.
        /// </summary>
        /// <returns><see cref="T:System.String"/> которая представляет <see cref="T:Lab13.Student"/>.</returns>
        public override string ToString()
        {
            return base.ToString() + $", курс: {Course}";
        }
        /// <summary>
        /// Генерирует оьъект студента
        /// </summary>
        /// <returns>Студента</returns>
        public static Student GenerateStudent()
        {
            count++;
            return new Student($"Студент №{count}", random.Next(1,3), random.Next(1,5));
        }
        /// <summary>
        /// Инициализирует представление класса <see cref="T:Lab13.Student"/>
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="gender">Гендер</param>
        /// <param name="course">Курс</param>
        public Student(string name = "default", int gender = 1, int course = 1) : base (name, gender)
        {
            Course = course;
        }
    }
}
