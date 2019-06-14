using System;
namespace Lab13
{
    /// <summary>
    /// Класс реализует абстрактную персону
    /// </summary>
    public abstract class Person
    {
        /// <summary>
        /// Получает имя персоны
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; } = "default";
        /// <summary>
        /// Получает гендер персоны
        /// </summary>
        /// <value>The gender.</value>
        public int Gender { get; private set; } = 2;
        /// <summary>
        /// Получает <see cref="T:System.String"/> которая представляет <see cref="T:Lab13.Person"/>
        /// </summary>
        /// <returns><see cref="T:System.String"/> которая представляет <see cref="T:Lab13.Person"/></returns>
        public override string ToString()
        {
            return $"Имя: {Name}, Пол: {Gender}";
        }
        /// <summary>
        /// Создает новое представление класса <see cref="T:Lab13.Person"/>
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="gender">Гендер</param>
        public Person(string name = "default", int gender = 1)
        {
            Name = name;
            Gender = gender;
        }
    }
}
