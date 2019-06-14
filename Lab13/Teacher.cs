using System;
namespace Lab13
{
    /// <summary>
    /// Реализует класс учителя
    /// </summary>
    public class Teacher : Person
    {
        static int count = 0;
        readonly static Random random = new Random();
        /// <summary>
        /// Получает факультет
        /// </summary>
        /// <value>Факультет</value>
        public string Faculty { get; private set; } = "default";
        /// <summary>
        /// Получает <see cref="T:System.String"/> которая представляет <see cref="T:Lab13.Teacher"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> которая представляет <see cref="T:Lab13.Teacher"/>.</returns>
        public override string ToString()
        {
            return base.ToString() + $", факультет: {Faculty}";
        }
        /// <summary>
        /// Генерирует объект учителя
        /// </summary>
        /// <returns>Учителя</returns>
        public static Teacher GenerateTeacher() 
        {
            count++;
            return new Teacher($"Учитель №{count}", random.Next(1,3), $"Кафедра №{random.Next(1,5)}");
        }
        /// <summary>
        /// Инициализирует новое представление класса <see cref="T:Lab13.Teacher"/>
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="gender">Гендер</param>
        /// <param name="faculty">Факультет</param>
        public Teacher(string name = "default", int gender = 1, string faculty = "default") : base (name, gender)
        {
            Faculty = faculty;
        }
    }
}
